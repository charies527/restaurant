namespace RestaurantSystem
{
    partial class OrderHistoryForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.grdOrders = new System.Windows.Forms.DataGridView();
            this.grdLines = new System.Windows.Forms.DataGridView();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblOrders = new System.Windows.Forms.Label();
            this.lblLines = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLines)).BeginInit();
            this.SuspendLayout();
            //
            // lblSearch
            //
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(18, 20);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(102, 17);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "주문자로 찾기";
            //
            // txtSearch
            //
            this.txtSearch.Location = new System.Drawing.Point(126, 16);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(160, 25);
            this.txtSearch.TabIndex = 1;
            //
            // btnSearch
            //
            this.btnSearch.Location = new System.Drawing.Point(298, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(84, 30);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "찾기";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            //
            // lblOrders
            //
            this.lblOrders.AutoSize = true;
            this.lblOrders.Location = new System.Drawing.Point(18, 56);
            this.lblOrders.Name = "lblOrders";
            this.lblOrders.Size = new System.Drawing.Size(62, 17);
            this.lblOrders.TabIndex = 3;
            this.lblOrders.Text = "주문 목록";
            //
            // grdOrders
            //
            this.grdOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdOrders.Location = new System.Drawing.Point(18, 78);
            this.grdOrders.Name = "grdOrders";
            this.grdOrders.RowTemplate.Height = 27;
            this.grdOrders.Size = new System.Drawing.Size(760, 210);
            this.grdOrders.TabIndex = 4;
            this.grdOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdOrders_CellClick);
            //
            // lblLines
            //
            this.lblLines.AutoSize = true;
            this.lblLines.Location = new System.Drawing.Point(18, 302);
            this.lblLines.Name = "lblLines";
            this.lblLines.Size = new System.Drawing.Size(87, 17);
            this.lblLines.TabIndex = 5;
            this.lblLines.Text = "주문 상세 내역";
            //
            // grdLines
            //
            this.grdLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLines.Location = new System.Drawing.Point(18, 324);
            this.grdLines.Name = "grdLines";
            this.grdLines.RowTemplate.Height = 27;
            this.grdLines.Size = new System.Drawing.Size(760, 170);
            this.grdLines.TabIndex = 6;
            //
            // btnUp
            //
            this.btnUp.Location = new System.Drawing.Point(18, 512);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(84, 33);
            this.btnUp.TabIndex = 7;
            this.btnUp.Text = "위로";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            //
            // btnDown
            //
            this.btnDown.Location = new System.Drawing.Point(114, 512);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(84, 33);
            this.btnDown.TabIndex = 8;
            this.btnDown.Text = "아래로";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            //
            // btnLoad
            //
            this.btnLoad.BackColor = System.Drawing.Color.FromArgb(70, 145, 219);
            this.btnLoad.FlatAppearance.BorderSize = 0;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.Location = new System.Drawing.Point(534, 510);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(120, 36);
            this.btnLoad.TabIndex = 9;
            this.btnLoad.Text = "주문 불러오기";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            //
            // btnClose
            //
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(664, 510);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(114, 36);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "닫기";
            this.btnClose.UseVisualStyleBackColor = true;
            //
            // OrderHistoryForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 248, 252);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(798, 562);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.grdLines);
            this.Controls.Add(this.lblLines);
            this.Controls.Add(this.grdOrders);
            this.Controls.Add(this.lblOrders);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Font = new System.Drawing.Font("맑은 고딕", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderHistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "주문 내역 조회";
            this.Load += new System.EventHandler(this.OrderHistoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView grdOrders;
        private System.Windows.Forms.DataGridView grdLines;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblOrders;
        private System.Windows.Forms.Label lblLines;
    }
}
