using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;

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
        public List<MenuIngredientItem> Ingredients
        {
            get;
            private set;
        }

        private DbHelper db;

        public MenuEditForm(DbHelper helper, string id, string name, decimal price, string status)
        {
            InitializeComponent();

            db = helper;

            Ingredients = new List<MenuIngredientItem>();

            txtId.Text = id;
            txtName.Text = name;
            txtPrice.Text = price == 0 ? "" : price.ToString("0");

            cboStatus.SelectedItem =
                string.IsNullOrEmpty(status) ? "판매중" : status;

            if (cboStatus.SelectedIndex < 0)
                cboStatus.SelectedIndex = 0;

            LoadIngredients();

            // 식자재 선택 이벤트 연결
            dataGridView1.CurrentCellDirtyStateChanged += dataGridView1_CurrentCellDirtyStateChanged;

            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;

            // 단위는 자동으로 표시하므로 직접 수정하지 못하게 설정
            colUnit.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
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
        private void LoadIngredients()
        {
            // 식자재 목록을 DataGridView 콤보박스에 연결
            DataGridViewComboBoxColumn col =
                (DataGridViewComboBoxColumn)dataGridView1.Columns["colIndgredient"];

            col.DataSource = null;

            col.DataSource = db.Ingredient;
            col.DisplayMember = "ING_NAME";
            col.ValueMember = "ING_ID";
        }
        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(
                    DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            // 식자재 선택 컬럼이 아니면 종료
            if (e.ColumnIndex != colIndgredient.Index)
                return;

            // 선택한 식자재 번호 가져오기
            object ingredientId =dataGridView1.Rows[e.RowIndex].Cells["colIndgredient"].Value;

            if (ingredientId == null)
            {
                dataGridView1.Rows[e.RowIndex].Cells["colUnit"].Value = "";
                return;
            }

            // DB에서 해당 식자재 찾기
            DataRow ingredient = db.Ingredient.Rows.Find(ingredientId.ToString());

            if (ingredient != null)
            {
                // 단위 자동 입력
                dataGridView1.Rows[e.RowIndex].Cells["colUnit"].Value = Convert.ToString(ingredient["UNIT"]);
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;

            if(row == null || row.IsNewRow)
            {
                MessageBox.Show("삭제할 식자재를 선택하세요.");
                return;
            }
            if (MessageBox.Show("선택한 식자재를 삭제할까요?", "삭제",MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            try
            {
                // 선택한 행 삭제
                dataGridView1.Rows.Remove(row);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
