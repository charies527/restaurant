using System;
using System.Data;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace RestaurantSystem
{
    /// <summary>
    /// 기존 ADOForm 샘플과 같은 OracleDataAdapter + DataSet 방식입니다.
    /// </summary>
    public class DbHelper
    {
        public const string ConnectionString =
            "User Id=hong1; Password=1111; Data Source=(DESCRIPTION =   (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))   (CONNECT_DATA =     (SERVER = DEDICATED)     (SERVICE_NAME = xe)   ) );";

        public OracleDataAdapter MenuAdapter;
        public OracleDataAdapter IngAdapter;
        public OracleDataAdapter RecipeAdapter;
        public OracleDataAdapter OrderAdapter;
        public OracleDataAdapter DetailAdapter;
        public OracleCommandBuilder MenuBuilder;
        public OracleCommandBuilder IngBuilder;
        public OracleCommandBuilder OrderBuilder;
        public OracleCommandBuilder DetailBuilder;
        public DataSet DS = new DataSet();
        public bool Connected;

        public void Open()
        {
            try
            {
                MenuAdapter = new OracleDataAdapter("select * from menu order by menu_id", ConnectionString);
                MenuBuilder = new OracleCommandBuilder(MenuAdapter);
                IngAdapter = new OracleDataAdapter("select * from ingredient order by ing_id", ConnectionString);
                IngBuilder = new OracleCommandBuilder(IngAdapter);
                RecipeAdapter = new OracleDataAdapter("select * from menu_ingredient", ConnectionString);
                OrderAdapter = new OracleDataAdapter("select * from orders order by order_id", ConnectionString);
                OrderBuilder = new OracleCommandBuilder(OrderAdapter);
                DetailAdapter = new OracleDataAdapter("select * from order_detail order by detail_id", ConnectionString);
                DetailBuilder = new OracleCommandBuilder(DetailAdapter);
                FillAll();
                Connected = true;
            }
            catch (Exception ex)
            {
                Connected = false;
                EnsureLocalSchema();
                SeedLocal();
                MessageBox.Show(
                    "Oracle 연결에 실패하여 화면 샘플 데이터로 실행합니다.\n" +
                    "restaurant.sql을 hong1 계정에서 실행한 뒤 다시 시작하면 DB에 저장됩니다.\n\n" +
                    ex.Message,
                    "DB 연결",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        public void FillAll()
        {
            if (!Connected && MenuAdapter == null)
            {
                EnsureLocalSchema();
                return;
            }

            DS.Clear();
            MenuAdapter.Fill(DS, "Menu");
            IngAdapter.Fill(DS, "Ingredient");
            RecipeAdapter.Fill(DS, "Recipe");
            OrderAdapter.Fill(DS, "Orders");
            DetailAdapter.Fill(DS, "OrderDetail");
            SetKeys();
        }

        public DataTable Menu { get { return Table("Menu"); } }
        public DataTable Ingredient { get { return Table("Ingredient"); } }
        public DataTable Recipe { get { return Table("Recipe"); } }
        public DataTable Orders { get { return Table("Orders"); } }
        public DataTable OrderDetail { get { return Table("OrderDetail"); } }

        public void SaveMenu()
        {
            if (!Connected) return;
            MenuAdapter.Update(DS, "Menu");
            DS.Tables["Menu"].AcceptChanges();
        }

        public void SaveIngredient()
        {
            if (!Connected) return;
            IngAdapter.Update(DS, "Ingredient");
            DS.Tables["Ingredient"].AcceptChanges();
        }

        public void SaveOrders()
        {
            if (!Connected) return;
            DataSet changed = DS.GetChanges();
            if (changed == null) return;
            if (changed.Tables.Contains("Orders"))
                OrderAdapter.Update(changed, "Orders");
            if (changed.Tables.Contains("OrderDetail"))
                DetailAdapter.Update(changed, "OrderDetail");
            if (changed.Tables.Contains("Ingredient"))
                IngAdapter.Update(changed, "Ingredient");
            DS.AcceptChanges();
        }

        public int NextOrderId()
        {
            return NextId(Orders, "ORDER_ID");
        }

        public int NextDetailId()
        {
            return NextId(OrderDetail, "DETAIL_ID");
        }

        public string NextMenuId()
        {
            int max = 0;
            foreach (DataRow row in Menu.Rows)
            {
                if (row.RowState == DataRowState.Deleted) continue;
                string id = Convert.ToString(row["MENU_ID"]);
                if (id.StartsWith("M") && id.Length > 1)
                {
                    int n;
                    if (int.TryParse(id.Substring(1), out n) && n > max) max = n;
                }
            }
            return "M" + (max + 1).ToString("000");
        }

        private DataTable Table(string name)
        {
            if (!DS.Tables.Contains(name))
                EnsureLocalSchema();
            return DS.Tables[name];
        }

        private void SetKeys()
        {
            SetPk("Menu", "MENU_ID");
            SetPk("Ingredient", "ING_ID");
            SetPk("Orders", "ORDER_ID");
            SetPk("OrderDetail", "DETAIL_ID");
        }

        private void SetPk(string table, string column)
        {
            DataTable t = DS.Tables[table];
            if (t.PrimaryKey == null || t.PrimaryKey.Length == 0)
                t.PrimaryKey = new DataColumn[] { t.Columns[column] };
        }

        private int NextId(DataTable table, string column)
        {
            int max = 0;
            foreach (DataRow row in table.Rows)
            {
                object v = row.RowState == DataRowState.Deleted
                    ? row[column, DataRowVersion.Original]
                    : row[column];
                int n = Convert.ToInt32(v);
                if (n > max) max = n;
            }
            return max + 1;
        }

        private void EnsureLocalSchema()
        {
            if (!DS.Tables.Contains("Menu"))
            {
                DataTable menu = new DataTable("Menu");
                menu.Columns.Add("MENU_ID", typeof(string));
                menu.Columns.Add("MENU_NAME", typeof(string));
                menu.Columns.Add("PRICE", typeof(decimal));
                menu.Columns.Add("STATUS", typeof(string));
                menu.PrimaryKey = new DataColumn[] { menu.Columns["MENU_ID"] };
                DS.Tables.Add(menu);
            }
            if (!DS.Tables.Contains("Ingredient"))
            {
                DataTable ing = new DataTable("Ingredient");
                ing.Columns.Add("ING_ID", typeof(string));
                ing.Columns.Add("ING_NAME", typeof(string));
                ing.Columns.Add("CURRENT_QTY", typeof(decimal));
                ing.Columns.Add("MIN_QTY", typeof(decimal));
                ing.Columns.Add("UNIT", typeof(string));
                ing.PrimaryKey = new DataColumn[] { ing.Columns["ING_ID"] };
                DS.Tables.Add(ing);
            }
            if (!DS.Tables.Contains("Recipe"))
            {
                DataTable rec = new DataTable("Recipe");
                rec.Columns.Add("MENU_ID", typeof(string));
                rec.Columns.Add("ING_ID", typeof(string));
                rec.Columns.Add("USE_QTY", typeof(decimal));
                DS.Tables.Add(rec);
            }
            if (!DS.Tables.Contains("Orders"))
            {
                DataTable orders = new DataTable("Orders");
                orders.Columns.Add("ORDER_ID", typeof(int));
                orders.Columns.Add("CUSTOMER_NAME", typeof(string));
                orders.Columns.Add("ORDER_DT", typeof(string));
                orders.Columns.Add("TOTAL_AMT", typeof(decimal));
                orders.Columns.Add("STATUS", typeof(string));
                orders.PrimaryKey = new DataColumn[] { orders.Columns["ORDER_ID"] };
                DS.Tables.Add(orders);
            }
            if (!DS.Tables.Contains("OrderDetail"))
            {
                DataTable det = new DataTable("OrderDetail");
                det.Columns.Add("DETAIL_ID", typeof(int));
                det.Columns.Add("ORDER_ID", typeof(int));
                det.Columns.Add("MENU_ID", typeof(string));
                det.Columns.Add("MENU_NAME", typeof(string));
                det.Columns.Add("QTY", typeof(int));
                det.Columns.Add("UNIT_PRICE", typeof(decimal));
                det.Columns.Add("AMOUNT", typeof(decimal));
                det.PrimaryKey = new DataColumn[] { det.Columns["DETAIL_ID"] };
                DS.Tables.Add(det);
            }
        }

        private void SeedLocal()
        {
            if (Menu.Rows.Count > 0) return;
            Menu.Rows.Add("M001", "김치찌개", 9000, "판매중");
            Menu.Rows.Add("M002", "불고기덮밥", 10000, "판매중");
            Menu.Rows.Add("M003", "비빔밥", 9000, "판매중");
            Menu.Rows.Add("M004", "냉면", 10000, "판매중");
            Ingredient.Rows.Add("I001", "돼지고기", 800, 1000, "kg");
            Ingredient.Rows.Add("I002", "김치", 5000, 1000, "kg");
            Ingredient.Rows.Add("I003", "쌀", 20000, 5000, "kg");
            Ingredient.Rows.Add("I004", "야채", 3000, 1000, "kg");
            Recipe.Rows.Add("M001", "I001", 0.15m);
            Recipe.Rows.Add("M001", "I002", 0.20m);
            Recipe.Rows.Add("M002", "I001", 0.12m);
            Recipe.Rows.Add("M002", "I003", 0.15m);
            Recipe.Rows.Add("M003", "I003", 0.15m);
            Recipe.Rows.Add("M003", "I004", 0.10m);
            Recipe.Rows.Add("M004", "I003", 0.10m);
            Recipe.Rows.Add("M004", "I004", 0.08m);
            Menu.AcceptChanges();
            Ingredient.AcceptChanges();
            Recipe.AcceptChanges();
        }
    }
}
