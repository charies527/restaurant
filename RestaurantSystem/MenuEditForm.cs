using System;
using System.Windows.Forms;

namespace RestaurantSystem
{
    public partial class MenuEditForm : Form
    {
        public string MenuId { get { return txtId.Text.Trim(); } }
        public string MenuName { get { return txtName.Text.Trim(); } }
        public decimal Price { get; private set; }
        public string SaleStatus { get { return cboStatus.Text; } }
        public bool IdReadOnly
        {
            set { txtId.ReadOnly = value; }
        }

        public MenuEditForm(string id, string name, decimal price, string status)
        {
            InitializeComponent();
            txtId.Text = id;
            txtName.Text = name;
            txtPrice.Text = price == 0 ? "" : price.ToString("0");
            cboStatus.SelectedItem = string.IsNullOrEmpty(status) ? "판매중" : status;
            if (cboStatus.SelectedIndex < 0) cboStatus.SelectedIndex = 0;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text) || string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("메뉴번호와 메뉴명을 입력하세요.");
                return;
            }
            decimal p;
            if (!decimal.TryParse(txtPrice.Text.Replace(",", ""), out p) || p < 0)
            {
                MessageBox.Show("가격을 숫자로 입력하세요.");
                return;
            }
            Price = p;
            DialogResult = DialogResult.OK;
        }
    }
}
