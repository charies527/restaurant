namespace RestaurantSystem
{
    partial class MainForm
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
            this.pnlTabs = new System.Windows.Forms.Panel();
            this.btnTabOrder = new System.Windows.Forms.Button();
            this.btnTabMenu = new System.Windows.Forms.Button();
            this.btnTabStock = new System.Windows.Forms.Button();
            this.pnlOrder = new System.Windows.Forms.Panel();
            this.pnlOrderHead = new System.Windows.Forms.Panel();
            this.lblOrderHead = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.lblOrderDt = new System.Windows.Forms.Label();
            this.dtpOrder = new System.Windows.Forms.DateTimePicker();
            this.lblMenuPick = new System.Windows.Forms.Label();
            this.cboMenu = new System.Windows.Forms.ComboBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.nudQty = new System.Windows.Forms.NumericUpDown();
            this.btnAddLine = new System.Windows.Forms.Button();
            this.lblOrderLines = new System.Windows.Forms.Label();
            this.grdOrder = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnOrderSave = new System.Windows.Forms.Button();
            this.btnOrderEdit = new System.Windows.Forms.Button();
            this.btnOrderCancel = new System.Windows.Forms.Button();
            this.btnOrderList = new System.Windows.Forms.Button();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.pnlMenuHead = new System.Windows.Forms.Panel();
            this.lblMenuHead = new System.Windows.Forms.Label();
            this.lblMenuSearch = new System.Windows.Forms.Label();
            this.txtMenuSearch = new System.Windows.Forms.TextBox();
            this.btnMenuSearch = new System.Windows.Forms.Button();
            this.grdMenu = new System.Windows.Forms.DataGridView();
            this.btnMenuAdd = new System.Windows.Forms.Button();
            this.btnMenuEdit = new System.Windows.Forms.Button();
            this.btnMenuDel = new System.Windows.Forms.Button();
            this.pnlStock = new System.Windows.Forms.Panel();
            this.pnlStockHead = new System.Windows.Forms.Panel();
            this.lblStockHead = new System.Windows.Forms.Label();
            this.grdStock = new System.Windows.Forms.DataGridView();
            this.lblInbound = new System.Windows.Forms.Label();
            this.txtInbound = new System.Windows.Forms.TextBox();
            this.btnInbound = new System.Windows.Forms.Button();
            this.pnlTabs.SuspendLayout();
            this.pnlOrder.SuspendLayout();
            this.pnlOrderHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrder)).BeginInit();
            this.pnlMenu.SuspendLayout();
            this.pnlMenuHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMenu)).BeginInit();
            this.pnlStock.SuspendLayout();
            this.pnlStockHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStock)).BeginInit();
            this.SuspendLayout();
            //
            // pnlTabs
            //
            this.pnlTabs.BackColor = System.Drawing.Color.FromArgb(232, 239, 247);
            this.pnlTabs.Controls.Add(this.btnTabOrder);
            this.pnlTabs.Controls.Add(this.btnTabMenu);
            this.pnlTabs.Controls.Add(this.btnTabStock);
            this.pnlTabs.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTabs.Location = new System.Drawing.Point(0, 0);
            this.pnlTabs.Name = "pnlTabs";
            this.pnlTabs.Padding = new System.Windows.Forms.Padding(12, 10, 12, 6);
            this.pnlTabs.Size = new System.Drawing.Size(1184, 56);
            this.pnlTabs.TabIndex = 0;
            //
            // btnTabOrder
            //
            this.btnTabOrder.BackColor = System.Drawing.Color.FromArgb(70, 145, 219);
            this.btnTabOrder.FlatAppearance.BorderSize = 0;
            this.btnTabOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabOrder.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.btnTabOrder.ForeColor = System.Drawing.Color.White;
            this.btnTabOrder.Location = new System.Drawing.Point(12, 10);
            this.btnTabOrder.Name = "btnTabOrder";
            this.btnTabOrder.Size = new System.Drawing.Size(150, 38);
            this.btnTabOrder.TabIndex = 0;
            this.btnTabOrder.Text = "🍴  주문 관리";
            this.btnTabOrder.UseVisualStyleBackColor = false;
            this.btnTabOrder.Click += new System.EventHandler(this.btnTabOrder_Click);
            //
            // btnTabMenu
            //
            this.btnTabMenu.BackColor = System.Drawing.Color.FromArgb(53, 110, 168);
            this.btnTabMenu.FlatAppearance.BorderSize = 0;
            this.btnTabMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabMenu.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.btnTabMenu.ForeColor = System.Drawing.Color.White;
            this.btnTabMenu.Location = new System.Drawing.Point(168, 10);
            this.btnTabMenu.Name = "btnTabMenu";
            this.btnTabMenu.Size = new System.Drawing.Size(150, 38);
            this.btnTabMenu.TabIndex = 1;
            this.btnTabMenu.Text = "🍳  메뉴 관리";
            this.btnTabMenu.UseVisualStyleBackColor = false;
            this.btnTabMenu.Click += new System.EventHandler(this.btnTabMenu_Click);
            //
            // btnTabStock
            //
            this.btnTabStock.BackColor = System.Drawing.Color.FromArgb(53, 110, 168);
            this.btnTabStock.FlatAppearance.BorderSize = 0;
            this.btnTabStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabStock.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.btnTabStock.ForeColor = System.Drawing.Color.White;
            this.btnTabStock.Location = new System.Drawing.Point(324, 10);
            this.btnTabStock.Name = "btnTabStock";
            this.btnTabStock.Size = new System.Drawing.Size(150, 38);
            this.btnTabStock.TabIndex = 2;
            this.btnTabStock.Text = "📦  재고 관리";
            this.btnTabStock.UseVisualStyleBackColor = false;
            this.btnTabStock.Click += new System.EventHandler(this.btnTabStock_Click);
            //
            // pnlOrder
            //
            this.pnlOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlOrder.BackColor = System.Drawing.Color.White;
            this.pnlOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOrder.Controls.Add(this.btnOrderList);
            this.pnlOrder.Controls.Add(this.btnOrderCancel);
            this.pnlOrder.Controls.Add(this.btnOrderEdit);
            this.pnlOrder.Controls.Add(this.btnOrderSave);
            this.pnlOrder.Controls.Add(this.lblTotal);
            this.pnlOrder.Controls.Add(this.grdOrder);
            this.pnlOrder.Controls.Add(this.lblOrderLines);
            this.pnlOrder.Controls.Add(this.btnAddLine);
            this.pnlOrder.Controls.Add(this.nudQty);
            this.pnlOrder.Controls.Add(this.lblQty);
            this.pnlOrder.Controls.Add(this.cboMenu);
            this.pnlOrder.Controls.Add(this.lblMenuPick);
            this.pnlOrder.Controls.Add(this.dtpOrder);
            this.pnlOrder.Controls.Add(this.lblOrderDt);
            this.pnlOrder.Controls.Add(this.txtCustomer);
            this.pnlOrder.Controls.Add(this.lblCustomer);
            this.pnlOrder.Controls.Add(this.pnlOrderHead);
            this.pnlOrder.Location = new System.Drawing.Point(12, 64);
            this.pnlOrder.Name = "pnlOrder";
            this.pnlOrder.Size = new System.Drawing.Size(560, 612);
            this.pnlOrder.TabIndex = 1;
            //
            // pnlOrderHead
            //
            this.pnlOrderHead.BackColor = System.Drawing.Color.FromArgb(53, 110, 168);
            this.pnlOrderHead.Controls.Add(this.lblOrderHead);
            this.pnlOrderHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOrderHead.Location = new System.Drawing.Point(0, 0);
            this.pnlOrderHead.Name = "pnlOrderHead";
            this.pnlOrderHead.Size = new System.Drawing.Size(558, 40);
            this.pnlOrderHead.TabIndex = 0;
            //
            // lblOrderHead
            //
            this.lblOrderHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOrderHead.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblOrderHead.ForeColor = System.Drawing.Color.White;
            this.lblOrderHead.Location = new System.Drawing.Point(0, 0);
            this.lblOrderHead.Name = "lblOrderHead";
            this.lblOrderHead.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblOrderHead.Size = new System.Drawing.Size(558, 40);
            this.lblOrderHead.TabIndex = 0;
            this.lblOrderHead.Text = "🛒   주문 관리";
            this.lblOrderHead.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblCustomer
            //
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(18, 58);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(54, 17);
            this.lblCustomer.TabIndex = 1;
            this.lblCustomer.Text = "주문자";
            //
            // txtCustomer
            //
            this.txtCustomer.Location = new System.Drawing.Point(86, 54);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(120, 25);
            this.txtCustomer.TabIndex = 2;
            this.txtCustomer.Text = "김학생";
            //
            // lblOrderDt
            //
            this.lblOrderDt.AutoSize = true;
            this.lblOrderDt.Location = new System.Drawing.Point(230, 58);
            this.lblOrderDt.Name = "lblOrderDt";
            this.lblOrderDt.Size = new System.Drawing.Size(62, 17);
            this.lblOrderDt.TabIndex = 3;
            this.lblOrderDt.Text = "주문일시";
            //
            // dtpOrder
            //
            this.dtpOrder.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpOrder.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOrder.Location = new System.Drawing.Point(298, 54);
            this.dtpOrder.Name = "dtpOrder";
            this.dtpOrder.Size = new System.Drawing.Size(160, 25);
            this.dtpOrder.TabIndex = 4;
            //
            // lblMenuPick
            //
            this.lblMenuPick.AutoSize = true;
            this.lblMenuPick.Location = new System.Drawing.Point(18, 100);
            this.lblMenuPick.Name = "lblMenuPick";
            this.lblMenuPick.Size = new System.Drawing.Size(62, 17);
            this.lblMenuPick.TabIndex = 5;
            this.lblMenuPick.Text = "메뉴 선택";
            //
            // cboMenu
            //
            this.cboMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMenu.FormattingEnabled = true;
            this.cboMenu.Location = new System.Drawing.Point(86, 96);
            this.cboMenu.Name = "cboMenu";
            this.cboMenu.Size = new System.Drawing.Size(140, 25);
            this.cboMenu.TabIndex = 6;
            //
            // lblQty
            //
            this.lblQty.AutoSize = true;
            this.lblQty.Location = new System.Drawing.Point(244, 100);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(37, 17);
            this.lblQty.TabIndex = 7;
            this.lblQty.Text = "수량";
            //
            // nudQty
            //
            this.nudQty.Location = new System.Drawing.Point(287, 96);
            this.nudQty.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudQty.Name = "nudQty";
            this.nudQty.Size = new System.Drawing.Size(60, 25);
            this.nudQty.TabIndex = 8;
            this.nudQty.Value = new decimal(new int[] { 1, 0, 0, 0 });
            //
            // btnAddLine
            //
            this.btnAddLine.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.btnAddLine.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(196, 210, 224);
            this.btnAddLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddLine.Location = new System.Drawing.Point(368, 94);
            this.btnAddLine.Name = "btnAddLine";
            this.btnAddLine.Size = new System.Drawing.Size(70, 30);
            this.btnAddLine.TabIndex = 9;
            this.btnAddLine.Text = "추가";
            this.btnAddLine.UseVisualStyleBackColor = false;
            this.btnAddLine.Click += new System.EventHandler(this.btnAddLine_Click);
            //
            // lblOrderLines
            //
            this.lblOrderLines.AutoSize = true;
            this.lblOrderLines.Location = new System.Drawing.Point(18, 140);
            this.lblOrderLines.Name = "lblOrderLines";
            this.lblOrderLines.Size = new System.Drawing.Size(87, 17);
            this.lblOrderLines.TabIndex = 10;
            this.lblOrderLines.Text = "주문 상세 내역";
            //
            // grdOrder
            //
            this.grdOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdOrder.Location = new System.Drawing.Point(18, 162);
            this.grdOrder.Name = "grdOrder";
            this.grdOrder.RowTemplate.Height = 27;
            this.grdOrder.Size = new System.Drawing.Size(522, 332);
            this.grdOrder.TabIndex = 11;
            this.grdOrder.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdOrder_CellClick);
            //
            // lblTotal
            //
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(230, 504);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(310, 32);
            this.lblTotal.TabIndex = 12;
            this.lblTotal.Text = "총 금액 : 0원";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // btnOrderSave
            //
            this.btnOrderSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOrderSave.BackColor = System.Drawing.Color.FromArgb(70, 145, 219);
            this.btnOrderSave.FlatAppearance.BorderSize = 0;
            this.btnOrderSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderSave.ForeColor = System.Drawing.Color.White;
            this.btnOrderSave.Location = new System.Drawing.Point(18, 552);
            this.btnOrderSave.Name = "btnOrderSave";
            this.btnOrderSave.Size = new System.Drawing.Size(120, 38);
            this.btnOrderSave.TabIndex = 13;
            this.btnOrderSave.Text = "주문 등록";
            this.btnOrderSave.UseVisualStyleBackColor = false;
            this.btnOrderSave.Click += new System.EventHandler(this.btnOrderSave_Click);
            //
            // btnOrderEdit
            //
            this.btnOrderEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOrderEdit.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.btnOrderEdit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(196, 210, 224);
            this.btnOrderEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderEdit.Location = new System.Drawing.Point(148, 552);
            this.btnOrderEdit.Name = "btnOrderEdit";
            this.btnOrderEdit.Size = new System.Drawing.Size(120, 38);
            this.btnOrderEdit.TabIndex = 14;
            this.btnOrderEdit.Text = "주문 수정";
            this.btnOrderEdit.UseVisualStyleBackColor = false;
            this.btnOrderEdit.Click += new System.EventHandler(this.btnOrderEdit_Click);
            //
            // btnOrderCancel
            //
            this.btnOrderCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOrderCancel.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.btnOrderCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(196, 210, 224);
            this.btnOrderCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderCancel.Location = new System.Drawing.Point(278, 552);
            this.btnOrderCancel.Name = "btnOrderCancel";
            this.btnOrderCancel.Size = new System.Drawing.Size(120, 38);
            this.btnOrderCancel.TabIndex = 15;
            this.btnOrderCancel.Text = "주문 취소";
            this.btnOrderCancel.UseVisualStyleBackColor = false;
            this.btnOrderCancel.Click += new System.EventHandler(this.btnOrderCancel_Click);
            //
            // btnOrderList
            //
            this.btnOrderList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOrderList.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.btnOrderList.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(196, 210, 224);
            this.btnOrderList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderList.Location = new System.Drawing.Point(408, 552);
            this.btnOrderList.Name = "btnOrderList";
            this.btnOrderList.Size = new System.Drawing.Size(132, 38);
            this.btnOrderList.TabIndex = 16;
            this.btnOrderList.Text = "주문 내역 조회";
            this.btnOrderList.UseVisualStyleBackColor = false;
            this.btnOrderList.Click += new System.EventHandler(this.btnOrderList_Click);
            //
            // pnlMenu
            //
            this.pnlMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMenu.BackColor = System.Drawing.Color.White;
            this.pnlMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMenu.Controls.Add(this.btnMenuDel);
            this.pnlMenu.Controls.Add(this.btnMenuEdit);
            this.pnlMenu.Controls.Add(this.btnMenuAdd);
            this.pnlMenu.Controls.Add(this.grdMenu);
            this.pnlMenu.Controls.Add(this.btnMenuSearch);
            this.pnlMenu.Controls.Add(this.txtMenuSearch);
            this.pnlMenu.Controls.Add(this.lblMenuSearch);
            this.pnlMenu.Controls.Add(this.pnlMenuHead);
            this.pnlMenu.Location = new System.Drawing.Point(584, 64);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(588, 330);
            this.pnlMenu.TabIndex = 2;
            //
            // pnlMenuHead
            //
            this.pnlMenuHead.BackColor = System.Drawing.Color.FromArgb(53, 110, 168);
            this.pnlMenuHead.Controls.Add(this.lblMenuHead);
            this.pnlMenuHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenuHead.Location = new System.Drawing.Point(0, 0);
            this.pnlMenuHead.Name = "pnlMenuHead";
            this.pnlMenuHead.Size = new System.Drawing.Size(586, 40);
            this.pnlMenuHead.TabIndex = 0;
            //
            // lblMenuHead
            //
            this.lblMenuHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMenuHead.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblMenuHead.ForeColor = System.Drawing.Color.White;
            this.lblMenuHead.Location = new System.Drawing.Point(0, 0);
            this.lblMenuHead.Name = "lblMenuHead";
            this.lblMenuHead.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblMenuHead.Size = new System.Drawing.Size(586, 40);
            this.lblMenuHead.TabIndex = 0;
            this.lblMenuHead.Text = "🍳   메뉴 관리";
            this.lblMenuHead.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblMenuSearch
            //
            this.lblMenuSearch.AutoSize = true;
            this.lblMenuSearch.Location = new System.Drawing.Point(16, 56);
            this.lblMenuSearch.Name = "lblMenuSearch";
            this.lblMenuSearch.Size = new System.Drawing.Size(82, 17);
            this.lblMenuSearch.TabIndex = 1;
            this.lblMenuSearch.Text = "메뉴명 검색 :";
            //
            // txtMenuSearch
            //
            this.txtMenuSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMenuSearch.Location = new System.Drawing.Point(104, 52);
            this.txtMenuSearch.Name = "txtMenuSearch";
            this.txtMenuSearch.Size = new System.Drawing.Size(362, 25);
            this.txtMenuSearch.TabIndex = 2;
            //
            // btnMenuSearch
            //
            this.btnMenuSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMenuSearch.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.btnMenuSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(196, 210, 224);
            this.btnMenuSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuSearch.Location = new System.Drawing.Point(478, 50);
            this.btnMenuSearch.Name = "btnMenuSearch";
            this.btnMenuSearch.Size = new System.Drawing.Size(90, 30);
            this.btnMenuSearch.TabIndex = 3;
            this.btnMenuSearch.Text = "검색";
            this.btnMenuSearch.UseVisualStyleBackColor = false;
            this.btnMenuSearch.Click += new System.EventHandler(this.btnMenuSearch_Click);
            //
            // grdMenu
            //
            this.grdMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMenu.Location = new System.Drawing.Point(16, 90);
            this.grdMenu.Name = "grdMenu";
            this.grdMenu.RowTemplate.Height = 27;
            this.grdMenu.Size = new System.Drawing.Size(448, 220);
            this.grdMenu.TabIndex = 4;
            this.grdMenu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdMenu_CellClick);
            //
            // btnMenuAdd
            //
            this.btnMenuAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMenuAdd.BackColor = System.Drawing.Color.FromArgb(70, 145, 219);
            this.btnMenuAdd.FlatAppearance.BorderSize = 0;
            this.btnMenuAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuAdd.ForeColor = System.Drawing.Color.White;
            this.btnMenuAdd.Location = new System.Drawing.Point(478, 90);
            this.btnMenuAdd.Name = "btnMenuAdd";
            this.btnMenuAdd.Size = new System.Drawing.Size(90, 42);
            this.btnMenuAdd.TabIndex = 5;
            this.btnMenuAdd.Text = "추가";
            this.btnMenuAdd.UseVisualStyleBackColor = false;
            this.btnMenuAdd.Click += new System.EventHandler(this.btnMenuAdd_Click);
            //
            // btnMenuEdit
            //
            this.btnMenuEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMenuEdit.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.btnMenuEdit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(196, 210, 224);
            this.btnMenuEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuEdit.Location = new System.Drawing.Point(478, 140);
            this.btnMenuEdit.Name = "btnMenuEdit";
            this.btnMenuEdit.Size = new System.Drawing.Size(90, 42);
            this.btnMenuEdit.TabIndex = 6;
            this.btnMenuEdit.Text = "수정";
            this.btnMenuEdit.UseVisualStyleBackColor = false;
            this.btnMenuEdit.Click += new System.EventHandler(this.btnMenuEdit_Click);
            //
            // btnMenuDel
            //
            this.btnMenuDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMenuDel.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.btnMenuDel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(196, 210, 224);
            this.btnMenuDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuDel.Location = new System.Drawing.Point(478, 190);
            this.btnMenuDel.Name = "btnMenuDel";
            this.btnMenuDel.Size = new System.Drawing.Size(90, 42);
            this.btnMenuDel.TabIndex = 7;
            this.btnMenuDel.Text = "삭제";
            this.btnMenuDel.UseVisualStyleBackColor = false;
            this.btnMenuDel.Click += new System.EventHandler(this.btnMenuDel_Click);
            //
            // pnlStock
            //
            this.pnlStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlStock.BackColor = System.Drawing.Color.White;
            this.pnlStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStock.Controls.Add(this.btnInbound);
            this.pnlStock.Controls.Add(this.txtInbound);
            this.pnlStock.Controls.Add(this.lblInbound);
            this.pnlStock.Controls.Add(this.grdStock);
            this.pnlStock.Controls.Add(this.pnlStockHead);
            this.pnlStock.Location = new System.Drawing.Point(584, 404);
            this.pnlStock.Name = "pnlStock";
            this.pnlStock.Size = new System.Drawing.Size(588, 272);
            this.pnlStock.TabIndex = 3;
            //
            // pnlStockHead
            //
            this.pnlStockHead.BackColor = System.Drawing.Color.FromArgb(53, 110, 168);
            this.pnlStockHead.Controls.Add(this.lblStockHead);
            this.pnlStockHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStockHead.Location = new System.Drawing.Point(0, 0);
            this.pnlStockHead.Name = "pnlStockHead";
            this.pnlStockHead.Size = new System.Drawing.Size(586, 40);
            this.pnlStockHead.TabIndex = 0;
            //
            // lblStockHead
            //
            this.lblStockHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStockHead.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblStockHead.ForeColor = System.Drawing.Color.White;
            this.lblStockHead.Location = new System.Drawing.Point(0, 0);
            this.lblStockHead.Name = "lblStockHead";
            this.lblStockHead.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblStockHead.Size = new System.Drawing.Size(586, 40);
            this.lblStockHead.TabIndex = 0;
            this.lblStockHead.Text = "📦   재고 관리";
            this.lblStockHead.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // grdStock
            //
            this.grdStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdStock.Location = new System.Drawing.Point(16, 52);
            this.grdStock.Name = "grdStock";
            this.grdStock.RowTemplate.Height = 27;
            this.grdStock.Size = new System.Drawing.Size(552, 164);
            this.grdStock.TabIndex = 1;
            this.grdStock.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdStock_CellFormatting);
            //
            // lblInbound
            //
            this.lblInbound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInbound.AutoSize = true;
            this.lblInbound.Location = new System.Drawing.Point(16, 232);
            this.lblInbound.Name = "lblInbound";
            this.lblInbound.Size = new System.Drawing.Size(112, 17);
            this.lblInbound.TabIndex = 2;
            this.lblInbound.Text = "식자재 입고 수량 :";
            //
            // txtInbound
            //
            this.txtInbound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtInbound.Location = new System.Drawing.Point(134, 228);
            this.txtInbound.Name = "txtInbound";
            this.txtInbound.Size = new System.Drawing.Size(180, 25);
            this.txtInbound.TabIndex = 3;
            //
            // btnInbound
            //
            this.btnInbound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInbound.BackColor = System.Drawing.Color.FromArgb(70, 145, 219);
            this.btnInbound.FlatAppearance.BorderSize = 0;
            this.btnInbound.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInbound.ForeColor = System.Drawing.Color.White;
            this.btnInbound.Location = new System.Drawing.Point(454, 222);
            this.btnInbound.Name = "btnInbound";
            this.btnInbound.Size = new System.Drawing.Size(114, 36);
            this.btnInbound.TabIndex = 4;
            this.btnInbound.Text = "입고 등록";
            this.btnInbound.UseVisualStyleBackColor = false;
            this.btnInbound.Click += new System.EventHandler(this.btnInbound_Click);
            //
            // MainForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(232, 239, 247);
            this.ClientSize = new System.Drawing.Size(1184, 688);
            this.Controls.Add(this.pnlStock);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlOrder);
            this.Controls.Add(this.pnlTabs);
            this.Font = new System.Drawing.Font("맑은 고딕", 9.5F);
            this.MinimumSize = new System.Drawing.Size(1100, 680);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "음식점 통합 관리 시스템";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlTabs.ResumeLayout(false);
            this.pnlOrder.ResumeLayout(false);
            this.pnlOrder.PerformLayout();
            this.pnlOrderHead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrder)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.pnlMenuHead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMenu)).EndInit();
            this.pnlStock.ResumeLayout(false);
            this.pnlStock.PerformLayout();
            this.pnlStockHead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdStock)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTabs;
        private System.Windows.Forms.Button btnTabOrder;
        private System.Windows.Forms.Button btnTabMenu;
        private System.Windows.Forms.Button btnTabStock;
        private System.Windows.Forms.Panel pnlOrder;
        private System.Windows.Forms.Panel pnlOrderHead;
        private System.Windows.Forms.Label lblOrderHead;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label lblOrderDt;
        private System.Windows.Forms.DateTimePicker dtpOrder;
        private System.Windows.Forms.Label lblMenuPick;
        private System.Windows.Forms.ComboBox cboMenu;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.NumericUpDown nudQty;
        private System.Windows.Forms.Button btnAddLine;
        private System.Windows.Forms.Label lblOrderLines;
        private System.Windows.Forms.DataGridView grdOrder;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnOrderSave;
        private System.Windows.Forms.Button btnOrderEdit;
        private System.Windows.Forms.Button btnOrderCancel;
        private System.Windows.Forms.Button btnOrderList;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlMenuHead;
        private System.Windows.Forms.Label lblMenuHead;
        private System.Windows.Forms.Label lblMenuSearch;
        private System.Windows.Forms.TextBox txtMenuSearch;
        private System.Windows.Forms.Button btnMenuSearch;
        private System.Windows.Forms.DataGridView grdMenu;
        private System.Windows.Forms.Button btnMenuAdd;
        private System.Windows.Forms.Button btnMenuEdit;
        private System.Windows.Forms.Button btnMenuDel;
        private System.Windows.Forms.Panel pnlStock;
        private System.Windows.Forms.Panel pnlStockHead;
        private System.Windows.Forms.Label lblStockHead;
        private System.Windows.Forms.DataGridView grdStock;
        private System.Windows.Forms.Label lblInbound;
        private System.Windows.Forms.TextBox txtInbound;
        private System.Windows.Forms.Button btnInbound;
    }
}
