using System.Drawing;
using System.Windows.Forms;

namespace RestaurantSystem
{
    internal static class UiStyle
    {
        public static readonly Color PageBack = Color.FromArgb(232, 239, 247);
        public static readonly Color Header = Color.FromArgb(53, 110, 168);
        public static readonly Color TabOn = Color.FromArgb(70, 145, 219);
        public static readonly Color TabOff = Color.FromArgb(53, 110, 168);
        public static readonly Color GridSelect = Color.FromArgb(46, 134, 222);
        public static readonly Color LowStock = Color.FromArgb(255, 214, 214);
        public static readonly Color LowStockText = Color.FromArgb(214, 48, 49);
        public static readonly Color Card = Color.White;
        public static readonly Color Line = Color.FromArgb(196, 210, 224);

        public static readonly Font UiFont = new Font("맑은 고딕", 9.5F);
        public static readonly Font TitleFont = new Font("맑은 고딕", 12F, FontStyle.Bold);
        public static readonly Font HeaderFont = new Font("맑은 고딕", 11F, FontStyle.Bold);
        public static readonly Font TotalFont = new Font("맑은 고딕", 14F, FontStyle.Bold);

        public static void ApplyGrid(DataGridView grid)
        {
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.FixedSingle;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(50, 60, 70);
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("맑은 고딕", 9.5F, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.ColumnHeadersHeight = 32;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.DefaultCellStyle.Font = UiFont;
            grid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.DefaultCellStyle.SelectionBackColor = GridSelect;
            grid.DefaultCellStyle.SelectionForeColor = Color.White;
            grid.RowTemplate.Height = 28;
            grid.RowHeadersVisible = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.ReadOnly = true;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public static Button MakeTab(string text, bool selected)
        {
            var btn = new Button();
            btn.Text = text;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("맑은 고딕", 10F, FontStyle.Bold);
            btn.ForeColor = Color.White;
            btn.BackColor = selected ? TabOn : TabOff;
            btn.Cursor = Cursors.Hand;
            btn.Height = 40;
            return btn;
        }

        public static Button MakeAction(string text, bool primary)
        {
            var btn = new Button();
            btn.Text = text;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = primary ? TabOn : Line;
            btn.FlatAppearance.BorderSize = 1;
            btn.BackColor = primary ? TabOn : Color.FromArgb(248, 250, 252);
            btn.ForeColor = primary ? Color.White : Color.FromArgb(60, 70, 80);
            btn.Font = new Font("맑은 고딕", 9.5F);
            btn.Cursor = Cursors.Hand;
            btn.Height = 36;
            return btn;
        }
    }
}
