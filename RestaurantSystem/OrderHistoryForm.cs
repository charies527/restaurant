using System;
using System.Data;
using System.Windows.Forms;

namespace RestaurantSystem
{
    public partial class OrderHistoryForm : Form
    {
        private readonly DbHelper db;
        public int SelectedOrderId { get; private set; }

        public OrderHistoryForm(DbHelper helper)
        {
            db = helper;
            InitializeComponent();
        }

        private void OrderHistoryForm_Load(object sender, EventArgs e)
        {
            UiStyle.ApplyGrid(grdOrders);
            UiStyle.ApplyGrid(grdLines);
            BindOrders(txtSearch.Text);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindOrders(txtSearch.Text);
        }

        private void BindOrders(string keyword)
        {
            string filter = "STATUS <> '취소'";
            if (!string.IsNullOrWhiteSpace(keyword))
                filter += " AND CUSTOMER_NAME like '%" + keyword.Replace("'", "''") + "%'";

            DataRow[] rows = db.Orders.Select(filter, "ORDER_ID DESC");
            DataTable t = db.Orders.Clone();
            foreach (DataRow r in rows) t.ImportRow(r);
            grdOrders.DataSource = t;
            if (grdOrders.Columns.Contains("ORDER_ID")) grdOrders.Columns["ORDER_ID"].HeaderText = "주문번호";
            if (grdOrders.Columns.Contains("CUSTOMER_NAME")) grdOrders.Columns["CUSTOMER_NAME"].HeaderText = "주문자";
            if (grdOrders.Columns.Contains("ORDER_DT")) grdOrders.Columns["ORDER_DT"].HeaderText = "주문일시";
            if (grdOrders.Columns.Contains("TOTAL_AMT"))
            {
                grdOrders.Columns["TOTAL_AMT"].HeaderText = "총금액";
                grdOrders.Columns["TOTAL_AMT"].DefaultCellStyle.Format = "#,0";
            }
            if (grdOrders.Columns.Contains("STATUS")) grdOrders.Columns["STATUS"].HeaderText = "상태";
        }

        private void grdOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            SelectedOrderId = Convert.ToInt32(grdOrders.Rows[e.RowIndex].Cells["ORDER_ID"].Value);
            DataRow[] lines = db.OrderDetail.Select("ORDER_ID = " + SelectedOrderId);
            DataTable t = db.OrderDetail.Clone();
            foreach (DataRow r in lines) t.ImportRow(r);
            grdLines.DataSource = t;
            if (grdLines.Columns.Contains("DETAIL_ID")) grdLines.Columns["DETAIL_ID"].Visible = false;
            if (grdLines.Columns.Contains("ORDER_ID")) grdLines.Columns["ORDER_ID"].Visible = false;
            if (grdLines.Columns.Contains("MENU_ID")) grdLines.Columns["MENU_ID"].HeaderText = "메뉴번호";
            if (grdLines.Columns.Contains("MENU_NAME")) grdLines.Columns["MENU_NAME"].HeaderText = "메뉴명";
            if (grdLines.Columns.Contains("QTY")) grdLines.Columns["QTY"].HeaderText = "수량";
            if (grdLines.Columns.Contains("UNIT_PRICE"))
            {
                grdLines.Columns["UNIT_PRICE"].HeaderText = "단가";
                grdLines.Columns["UNIT_PRICE"].DefaultCellStyle.Format = "#,0";
            }
            if (grdLines.Columns.Contains("AMOUNT"))
            {
                grdLines.Columns["AMOUNT"].HeaderText = "금액";
                grdLines.Columns["AMOUNT"].DefaultCellStyle.Format = "#,0";
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (SelectedOrderId <= 0)
            {
                MessageBox.Show("불러올 주문을 선택하세요.");
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            MoveRow(-1);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            MoveRow(1);
        }

        private void MoveRow(int delta)
        {
            if (grdOrders.CurrentRow == null) return;
            int idx = grdOrders.CurrentRow.Index + delta;
            if (idx < 0)
            {
                MessageBox.Show("이곳은 레코드의 처음입니다.");
                return;
            }
            if (idx >= grdOrders.Rows.Count)
            {
                MessageBox.Show("이곳은 레코드의 마지막입니다.");
                return;
            }
            grdOrders.ClearSelection();
            grdOrders.Rows[idx].Selected = true;
            grdOrders.CurrentCell = grdOrders.Rows[idx].Cells[0];
            grdOrders_CellClick(grdOrders, new DataGridViewCellEventArgs(0, idx));
        }
    }
}
