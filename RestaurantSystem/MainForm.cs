using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RestaurantSystem
{
    public partial class MainForm : Form
    {
        private readonly DbHelper db = new DbHelper();
        private DataTable cart;
        private int currentOrderId;
        private string selectedMenuId;

        public string MenuSearchText
        {
            get { return txtMenuSearch.Text; }
            set { txtMenuSearch.Text = value; }
        }

        public MainForm()
        {
            InitializeComponent();
            db.Open();
            InitCart();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UiStyle.ApplyGrid(grdOrder);
            UiStyle.ApplyGrid(grdMenu);
            UiStyle.ApplyGrid(grdStock);
            BindMenus();
            BindStock();
            SeedDemoCart();
            BindCart();
            RefreshTotal();
        }

        private void InitCart()
        {
            cart = new DataTable("Cart");
            cart.Columns.Add("MENU_ID", typeof(string));
            cart.Columns.Add("메뉴명", typeof(string));
            cart.Columns.Add("수량", typeof(int));
            cart.Columns.Add("단가", typeof(decimal));
            cart.Columns.Add("금액", typeof(decimal));
        }

        private void BindMenus()
        {
            DataTable src = db.Menu.Copy();
            grdMenu.DataSource = src;
            Rename(grdMenu, "MENU_ID", "메뉴번호");
            Rename(grdMenu, "MENU_NAME", "메뉴명");
            Rename(grdMenu, "PRICE", "가격");
            Rename(grdMenu, "STATUS", "판매상태");
            if (grdMenu.Columns.Contains("메뉴번호") == false && grdMenu.Columns.Contains("MENU_ID"))
                grdMenu.Columns["MENU_ID"].HeaderText = "메뉴번호";
            if (grdMenu.Columns.Contains("MENU_ID"))
                grdMenu.Columns["MENU_ID"].Visible = true;
            FormatMoney(grdMenu, "PRICE");
            FormatMoney(grdMenu, "가격");

            cboMenu.DisplayMember = "MENU_NAME";
            cboMenu.ValueMember = "MENU_ID";
            DataView sale = new DataView(db.Menu);
            sale.RowFilter = "STATUS = '판매중'";
            cboMenu.DataSource = sale;
        }

        private void BindStock()
        {
            DataTable view = db.Ingredient.Copy();
            view.Columns.Add("상태", typeof(string));
            foreach (DataRow row in view.Rows)
            {
                decimal cur = Convert.ToDecimal(row["CURRENT_QTY"]);
                decimal min = Convert.ToDecimal(row["MIN_QTY"]);
                row["상태"] = cur < min ? "부족" : "정상";
            }
            grdStock.DataSource = view;
            HideColumn(grdStock, "ING_ID");
            Rename(grdStock, "ING_NAME", "식자재명");
            Rename(grdStock, "CURRENT_QTY", "현재 수량");
            Rename(grdStock, "MIN_QTY", "최소 재고량");
            HideColumn(grdStock, "UNIT");
            FormatQty(grdStock, "CURRENT_QTY");
            FormatQty(grdStock, "MIN_QTY");
        }

        private void BindCart()
        {
            grdOrder.DataSource = cart;
            HideColumn(grdOrder, "MENU_ID");
            FormatMoney(grdOrder, "단가");
            FormatMoney(grdOrder, "금액");
        }

        private void SeedDemoCart()
        {
            if (cart.Rows.Count > 0) return;
            DataRow m1 = db.Menu.Rows.Find("M001");
            DataRow m2 = db.Menu.Rows.Find("M002");
            if (m1 != null)
                cart.Rows.Add("M001", Convert.ToString(m1["MENU_NAME"]), 1, Convert.ToDecimal(m1["PRICE"]), Convert.ToDecimal(m1["PRICE"]));
            if (m2 != null)
                cart.Rows.Add("M002", Convert.ToString(m2["MENU_NAME"]), 1, Convert.ToDecimal(m2["PRICE"]), Convert.ToDecimal(m2["PRICE"]));
        }

        public void RefreshAll()
        {
            if (db.Connected)
                db.FillAll();
            BindMenus();
            BindStock();
        }

        private void btnAddLine_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboMenu.SelectedValue == null)
                {
                    MessageBox.Show("메뉴를 선택하세요.");
                    return;
                }
                DataRow menu = db.Menu.Rows.Find(cboMenu.SelectedValue.ToString());
                if (menu == null)
                {
                    MessageBox.Show("메뉴 정보가 없습니다.");
                    return;
                }
                if (Convert.ToString(menu["STATUS"]) != "판매중")
                {
                    MessageBox.Show("판매 중지된 메뉴입니다.");
                    return;
                }

                string id = Convert.ToString(menu["MENU_ID"]);
                int qty = Convert.ToInt32(nudQty.Value);
                decimal price = Convert.ToDecimal(menu["PRICE"]);
                DataRow exist = null;
                foreach (DataRow r in cart.Rows)
                {
                    if (Convert.ToString(r["MENU_ID"]) == id)
                    {
                        exist = r;
                        break;
                    }
                }
                if (exist != null)
                {
                    int newQty = Convert.ToInt32(exist["수량"]) + qty;
                    exist["수량"] = newQty;
                    exist["금액"] = newQty * price;
                }
                else
                {
                    cart.Rows.Add(id, Convert.ToString(menu["MENU_NAME"]), qty, price, qty * price);
                }
                RefreshTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grdOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= cart.Rows.Count) return;
            DataRow row = cart.Rows[e.RowIndex];
            cboMenu.SelectedValue = Convert.ToString(row["MENU_ID"]);
            nudQty.Value = Convert.ToInt32(row["수량"]);
        }

        private void btnOrderSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cart.Rows.Count == 0)
                {
                    MessageBox.Show("주문 상세 내역이 없습니다.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtCustomer.Text))
                {
                    MessageBox.Show("주문자를 입력하세요.");
                    return;
                }

                DeductStock(1);
                int orderId = db.NextOrderId();
                DataRow order = db.Orders.NewRow();
                order["ORDER_ID"] = orderId;
                order["CUSTOMER_NAME"] = txtCustomer.Text.Trim();
                order["ORDER_DT"] = dtpOrder.Value.ToString("yyyy-MM-dd HH:mm");
                order["TOTAL_AMT"] = CartTotal();
                order["STATUS"] = "등록";
                db.Orders.Rows.Add(order);

                foreach (DataRow line in cart.Rows)
                {
                    DataRow d = db.OrderDetail.NewRow();
                    d["DETAIL_ID"] = db.NextDetailId();
                    d["ORDER_ID"] = orderId;
                    d["MENU_ID"] = line["MENU_ID"];
                    d["MENU_NAME"] = line["메뉴명"];
                    d["QTY"] = line["수량"];
                    d["UNIT_PRICE"] = line["단가"];
                    d["AMOUNT"] = line["금액"];
                    db.OrderDetail.Rows.Add(d);
                }

                db.SaveOrders();
                currentOrderId = orderId;
                MessageBox.Show("주문이 등록되었습니다. 주문번호: " + orderId);
                BindStock();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOrderEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdOrder.CurrentRow == null)
                {
                    MessageBox.Show("수정할 주문 행을 선택하세요.");
                    return;
                }
                int idx = grdOrder.CurrentRow.Index;
                if (idx < 0 || idx >= cart.Rows.Count) return;
                DataRow line = cart.Rows[idx];
                int qty = Convert.ToInt32(nudQty.Value);
                decimal price = Convert.ToDecimal(line["단가"]);
                line["수량"] = qty;
                line["금액"] = qty * price;
                RefreshTotal();

                if (currentOrderId > 0)
                {
                    RestoreStock(currentOrderId);
                    UpdateSavedOrder();
                    DeductStock(1);
                    db.SaveOrders();
                    BindStock();
                    MessageBox.Show("주문 번호 " + currentOrderId + "가 수정되었습니다.");
                }
                else
                {
                    MessageBox.Show("현재 주문 내역 수량을 수정했습니다. 등록 버튼을 누르면 저장됩니다.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOrderCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentOrderId > 0)
                {
                    if (MessageBox.Show("저장된 주문을 취소할까요?", "주문 취소", MessageBoxButtons.YesNo) != DialogResult.Yes)
                        return;
                    RestoreStock(currentOrderId);
                    DataRow order = db.Orders.Rows.Find(currentOrderId);
                    if (order != null) order["STATUS"] = "취소";
                    db.SaveOrders();
                    db.SaveIngredient();
                    currentOrderId = 0;
                    BindStock();
                }
                cart.Rows.Clear();
                RefreshTotal();
                MessageBox.Show("주문을 취소했습니다.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOrderList_Click(object sender, EventArgs e)
        {
            OrderHistoryForm frm = new OrderHistoryForm(db);
            frm.Owner = this;
            if (frm.ShowDialog() == DialogResult.OK)
                LoadOrder(frm.SelectedOrderId);
            frm.Dispose();
        }

        public void LoadOrder(int orderId)
        {
            DataRow order = db.Orders.Rows.Find(orderId);
            if (order == null) return;
            currentOrderId = orderId;
            txtCustomer.Text = Convert.ToString(order["CUSTOMER_NAME"]);
            DateTime dt;
            if (DateTime.TryParse(Convert.ToString(order["ORDER_DT"]), out dt))
                dtpOrder.Value = dt;
            cart.Rows.Clear();
            foreach (DataRow d in db.OrderDetail.Select("ORDER_ID = " + orderId))
            {
                cart.Rows.Add(
                    Convert.ToString(d["MENU_ID"]),
                    Convert.ToString(d["MENU_NAME"]),
                    Convert.ToInt32(d["QTY"]),
                    Convert.ToDecimal(d["UNIT_PRICE"]),
                    Convert.ToDecimal(d["AMOUNT"]));
            }
            RefreshTotal();
        }

        private void btnMenuSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow[] rows = db.Menu.Select("MENU_NAME like '%" + txtMenuSearch.Text.Replace("'", "''") + "%'");
                DataTable t = db.Menu.Clone();
                foreach (DataRow r in rows) t.ImportRow(r);
                grdMenu.DataSource = t;
                if (grdMenu.Columns.Contains("MENU_ID"))
                    grdMenu.Columns["MENU_ID"].HeaderText = "메뉴번호";
                Rename(grdMenu, "MENU_NAME", "메뉴명");
                Rename(grdMenu, "PRICE", "가격");
                Rename(grdMenu, "STATUS", "판매상태");
                FormatMoney(grdMenu, "PRICE");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grdMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            object id = grdMenu.Rows[e.RowIndex].Cells["MENU_ID"].Value;
            if (id != null)
            {
                selectedMenuId = id.ToString();
                cboMenu.SelectedValue = selectedMenuId;
            }
        }

        private void btnMenuAdd_Click(object sender, EventArgs e)
        {
            MenuEditForm dlg = new MenuEditForm(db ,db.NextMenuId(), "", 0, "판매중");
            if (dlg.ShowDialog() != DialogResult.OK) return;
            try
            {
                DataRow row = db.Menu.NewRow();
                row["MENU_ID"] = dlg.MenuId;
                row["MENU_NAME"] = dlg.MenuName;
                row["PRICE"] = dlg.Price;
                row["STATUS"] = dlg.SaleStatus;
                db.Menu.Rows.Add(row);
                db.SaveMenu();
                BindMenus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMenuEdit_Click(object sender, EventArgs e)
        {
            DataRow row = CurrentMenuRow();
            if (row == null)
            {
                MessageBox.Show("수정할 메뉴를 선택하세요.");
                return;
            }
            MenuEditForm dlg = new MenuEditForm(
                db,
                Convert.ToString(row["MENU_ID"]),
                Convert.ToString(row["MENU_NAME"]),
                Convert.ToDecimal(row["PRICE"]),
                Convert.ToString(row["STATUS"]));
            dlg.IdReadOnly = true;
            if (dlg.ShowDialog() != DialogResult.OK) return;
            try
            {
                row.BeginEdit();
                row["MENU_NAME"] = dlg.MenuName;
                row["PRICE"] = dlg.Price;
                row["STATUS"] = dlg.SaleStatus;
                row.EndEdit();
                db.SaveMenu();
                BindMenus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMenuDel_Click(object sender, EventArgs e)
        {
            DataRow row = CurrentMenuRow();
            if (row == null)
            {
                MessageBox.Show("삭제할 메뉴를 선택하세요.");
                return;
            }
            if (MessageBox.Show("선택한 메뉴를 삭제할까요?", "삭제", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
            try
            {
                row.Delete();
                db.SaveMenu();
                BindMenus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnInbound_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdStock.CurrentRow == null)
                {
                    MessageBox.Show("입고할 식자재를 선택하세요.");
                    return;
                }
                decimal addQty;
                if (!decimal.TryParse(txtInbound.Text.Replace(",", ""), out addQty) || addQty <= 0)
                {
                    MessageBox.Show("입고 수량을 숫자로 입력하세요.");
                    return;
                }
                string name = Convert.ToString(grdStock.CurrentRow.Cells["ING_NAME"].Value);
                DataRow[] found = db.Ingredient.Select("ING_NAME = '" + name.Replace("'", "''") + "'");
                if (found.Length == 0) return;
                found[0]["CURRENT_QTY"] = Convert.ToDecimal(found[0]["CURRENT_QTY"]) + addQty;
                db.SaveIngredient();
                txtInbound.Clear();
                BindStock();
                MessageBox.Show(name + " 입고가 등록되었습니다.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grdStock_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = grdStock.Rows[e.RowIndex];
            if (row.Cells["상태"] == null || row.Cells["상태"].Value == null) return;
            if (Convert.ToString(row.Cells["상태"].Value) == "부족")
            {
                row.DefaultCellStyle.BackColor = UiStyle.LowStock;
                if (grdStock.Columns[e.ColumnIndex].Name == "상태")
                {
                    e.CellStyle.ForeColor = UiStyle.LowStockText;
                    e.CellStyle.Font = new Font("맑은 고딕", 9.5F, FontStyle.Bold);
                }
            }
        }

        private void btnTabOrder_Click(object sender, EventArgs e)
        {
            SetTab(btnTabOrder);
            pnlOrder.BringToFront();
            txtCustomer.Focus();
        }

        private void btnTabMenu_Click(object sender, EventArgs e)
        {
            SetTab(btnTabMenu);
            txtMenuSearch.Focus();
        }

        private void btnTabStock_Click(object sender, EventArgs e)
        {
            SetTab(btnTabStock);
            txtInbound.Focus();
        }

        private void SetTab(Button on)
        {
            btnTabOrder.BackColor = UiStyle.TabOff;
            btnTabMenu.BackColor = UiStyle.TabOff;
            btnTabStock.BackColor = UiStyle.TabOff;
            on.BackColor = UiStyle.TabOn;
        }

        private DataRow CurrentMenuRow()
        {
            if (grdMenu.CurrentRow == null) return null;
            object id = grdMenu.CurrentRow.Cells["MENU_ID"].Value;
            if (id == null) return null;
            return db.Menu.Rows.Find(id.ToString());
        }

        private void UpdateSavedOrder()
        {
            DataRow order = db.Orders.Rows.Find(currentOrderId);
            if (order == null) return;
            order["CUSTOMER_NAME"] = txtCustomer.Text.Trim();
            order["ORDER_DT"] = dtpOrder.Value.ToString("yyyy-MM-dd HH:mm");
            order["TOTAL_AMT"] = CartTotal();
            order["STATUS"] = "등록";

            foreach (DataRow d in db.OrderDetail.Select("ORDER_ID = " + currentOrderId))
                d.Delete();

            foreach (DataRow line in cart.Rows)
            {
                DataRow d = db.OrderDetail.NewRow();
                d["DETAIL_ID"] = db.NextDetailId();
                d["ORDER_ID"] = currentOrderId;
                d["MENU_ID"] = line["MENU_ID"];
                d["MENU_NAME"] = line["메뉴명"];
                d["QTY"] = line["수량"];
                d["UNIT_PRICE"] = line["단가"];
                d["AMOUNT"] = line["금액"];
                db.OrderDetail.Rows.Add(d);
            }
        }

        private void DeductStock(int sign)
        {
            foreach (DataRow line in cart.Rows)
            {
                string menuId = Convert.ToString(line["MENU_ID"]);
                int qty = Convert.ToInt32(line["수량"]);
                DataRow[] recs = db.Recipe.Select("MENU_ID = '" + menuId.Replace("'", "''") + "'");
                foreach (DataRow rec in recs)
                {
                    DataRow ing = db.Ingredient.Rows.Find(Convert.ToString(rec["ING_ID"]));
                    if (ing == null) continue;
                    decimal use = Convert.ToDecimal(rec["USE_QTY"]) * qty * sign;
                    decimal next = Convert.ToDecimal(ing["CURRENT_QTY"]) - use;
                    if (next < 0) next = 0;
                    ing["CURRENT_QTY"] = next;
                }
            }
            db.SaveIngredient();
        }

        private void RestoreStock(int orderId)
        {
            DataTable backup = cart.Copy();
            cart.Rows.Clear();
            foreach (DataRow d in db.OrderDetail.Select("ORDER_ID = " + orderId))
            {
                if (d.RowState == DataRowState.Deleted) continue;
                cart.Rows.Add(d["MENU_ID"], d["MENU_NAME"], d["QTY"], d["UNIT_PRICE"], d["AMOUNT"]);
            }
            DeductStock(-1);
            cart.Rows.Clear();
            foreach (DataRow r in backup.Rows)
                cart.ImportRow(r);
        }

        private decimal CartTotal()
        {
            decimal sum = 0;
            foreach (DataRow r in cart.Rows)
                sum += Convert.ToDecimal(r["금액"]);
            return sum;
        }

        private void RefreshTotal()
        {
            lblTotal.Text = "총 금액 : " + CartTotal().ToString("#,0") + "원";
        }

        private static void HideColumn(DataGridView grid, string name)
        {
            if (grid.Columns.Contains(name))
                grid.Columns[name].Visible = false;
        }

        private static void Rename(DataGridView grid, string name, string header)
        {
            if (grid.Columns.Contains(name))
                grid.Columns[name].HeaderText = header;
        }

        private static void FormatMoney(DataGridView grid, string name)
        {
            if (!grid.Columns.Contains(name)) return;
            grid.Columns[name].DefaultCellStyle.Format = "#,0";
            grid.Columns[name].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private static void FormatQty(DataGridView grid, string name)
        {
            if (!grid.Columns.Contains(name)) return;
            grid.Columns[name].DefaultCellStyle.Format = "#,0 kg";
            grid.Columns[name].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
    }
}
