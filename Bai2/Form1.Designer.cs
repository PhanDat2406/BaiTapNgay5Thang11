namespace Bai2;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        menuStripMain = new MenuStrip();
        menuFile = new ToolStripMenuItem();
        menuExportCsv = new ToolStripMenuItem();
        toolStripSeparator1 = new ToolStripSeparator();
        menuExit = new ToolStripMenuItem();
        statusStripMain = new StatusStrip();
        lblStatusTotal = new ToolStripStatusLabel();
        pnlContainer = new Panel();
        grpList = new GroupBox();
        dgvBorrowRecords = new DataGridView();
        pnlSearchFilter = new Panel();
        btnResetFilter = new Button();
        cboFilterStatus = new ComboBox();
        lblFilterStatus = new Label();
        txtSearch = new TextBox();
        lblSearch = new Label();
        grpInput = new GroupBox();
        btnDanhDauDaTra = new Button();
        btnLamMoi = new Button();
        btnXoa = new Button();
        btnCapNhat = new Button();
        btnThem = new Button();
        cboStatus = new ComboBox();
        lblStatus = new Label();
        dtpReturnDate = new DateTimePicker();
        chkHasReturned = new CheckBox();
        dtpDueDate = new DateTimePicker();
        lblDueDate = new Label();
        dtpBorrowDate = new DateTimePicker();
        lblBorrowDate = new Label();
        nudQuantity = new NumericUpDown();
        lblQuantity = new Label();
        cboEquipment = new ComboBox();
        lblEquipment = new Label();
        txtStudentName = new TextBox();
        lblStudentName = new Label();
        txtStudentId = new TextBox();
        lblStudentId = new Label();
        txtBorrowId = new TextBox();
        lblBorrowId = new Label();
        errorProvider1 = new ErrorProvider(components);
        saveFileDialog1 = new SaveFileDialog();

        menuStripMain.SuspendLayout();
        statusStripMain.SuspendLayout();
        pnlContainer.SuspendLayout();
        grpList.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvBorrowRecords).BeginInit();
        pnlSearchFilter.SuspendLayout();
        grpInput.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudQuantity).BeginInit();
        ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
        SuspendLayout();

        // 
        // menuStripMain
        // 
        menuStripMain.Items.AddRange(new ToolStripItem[] { menuFile });
        menuStripMain.Location = new Point(0, 0);
        menuStripMain.Name = "menuStripMain";
        menuStripMain.Size = new Size(1150, 24);
        menuStripMain.TabIndex = 0;
        menuStripMain.Text = "menuStrip1";

        // 
        // menuFile
        // 
        menuFile.DropDownItems.AddRange(new ToolStripItem[] { menuExportCsv, toolStripSeparator1, menuExit });
        menuFile.Name = "menuFile";
        menuFile.Size = new Size(60, 20);
        menuFile.Text = "&Tệp tin";

        // 
        // menuExportCsv
        // 
        menuExportCsv.Name = "menuExportCsv";
        menuExportCsv.ShortcutKeys = Keys.Control | Keys.E;
        menuExportCsv.Size = new Size(185, 22);
        menuExportCsv.Text = "&Xuất ra CSV...";

        // 
        // toolStripSeparator1
        // 
        toolStripSeparator1.Name = "toolStripSeparator1";
        toolStripSeparator1.Size = new Size(182, 6);

        // 
        // menuExit
        // 
        menuExit.Name = "menuExit";
        menuExit.ShortcutKeys = Keys.Alt | Keys.F4;
        menuExit.Size = new Size(185, 22);
        menuExit.Text = "&Thoát";

        // 
        // statusStripMain
        // 
        statusStripMain.Items.AddRange(new ToolStripItem[] { lblStatusTotal });
        statusStripMain.Location = new Point(0, 649);
        statusStripMain.Name = "statusStripMain";
        statusStripMain.Size = new Size(1150, 22);
        statusStripMain.TabIndex = 1;

        // 
        // lblStatusTotal
        // 
        lblStatusTotal.Name = "lblStatusTotal";
        lblStatusTotal.Size = new Size(160, 17);
        lblStatusTotal.Text = "Tổng số phiếu: 0 | Quá hạn: 0";

        // 
        // pnlContainer
        // 
        pnlContainer.Controls.Add(grpList);
        pnlContainer.Controls.Add(grpInput);
        pnlContainer.Dock = DockStyle.Fill;
        pnlContainer.Location = new Point(0, 24);
        pnlContainer.Name = "pnlContainer";
        pnlContainer.Padding = new Padding(10);
        pnlContainer.Size = new Size(1150, 625);
        pnlContainer.TabIndex = 2;

        // 
        // grpList
        // 
        grpList.Controls.Add(dgvBorrowRecords);
        grpList.Controls.Add(pnlSearchFilter);
        grpList.Dock = DockStyle.Fill;
        grpList.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
        grpList.Location = new Point(390, 10);
        grpList.Name = "grpList";
        grpList.Padding = new Padding(10);
        grpList.Size = new Size(750, 605);
        grpList.TabIndex = 1;
        grpList.TabStop = false;
        grpList.Text = "Danh sách mượn trả thiết bị";

        // 
        // dgvBorrowRecords
        // 
        dgvBorrowRecords.AllowUserToAddRows = false;
        dgvBorrowRecords.AllowUserToDeleteRows = false;
        dgvBorrowRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvBorrowRecords.BackgroundColor = SystemColors.Window;
        dgvBorrowRecords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvBorrowRecords.Dock = DockStyle.Fill;
        dgvBorrowRecords.Location = new Point(10, 80);
        dgvBorrowRecords.MultiSelect = false;
        dgvBorrowRecords.Name = "dgvBorrowRecords";
        dgvBorrowRecords.ReadOnly = true;
        dgvBorrowRecords.RowHeadersVisible = false;
        dgvBorrowRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvBorrowRecords.Size = new Size(730, 515);
        dgvBorrowRecords.TabIndex = 1;

        // 
        // pnlSearchFilter
        // 
        pnlSearchFilter.Controls.Add(btnResetFilter);
        pnlSearchFilter.Controls.Add(cboFilterStatus);
        pnlSearchFilter.Controls.Add(lblFilterStatus);
        pnlSearchFilter.Controls.Add(txtSearch);
        pnlSearchFilter.Controls.Add(lblSearch);
        pnlSearchFilter.Dock = DockStyle.Top;
        pnlSearchFilter.Location = new Point(10, 27);
        pnlSearchFilter.Name = "pnlSearchFilter";
        pnlSearchFilter.Size = new Size(730, 53);
        pnlSearchFilter.TabIndex = 0;

        // 
        // btnResetFilter
        // 
        btnResetFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnResetFilter.Location = new Point(640, 11);
        btnResetFilter.Name = "btnResetFilter";
        btnResetFilter.Size = new Size(80, 28);
        btnResetFilter.TabIndex = 4;
        btnResetFilter.Text = "Bỏ lọc";
        btnResetFilter.UseVisualStyleBackColor = true;

        // 
        // cboFilterStatus
        // 
        cboFilterStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        cboFilterStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        cboFilterStatus.FormattingEnabled = true;
        cboFilterStatus.Location = new Point(480, 13);
        cboFilterStatus.Name = "cboFilterStatus";
        cboFilterStatus.Size = new Size(150, 24);
        cboFilterStatus.TabIndex = 3;

        // 
        // lblFilterStatus
        // 
        lblFilterStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblFilterStatus.AutoSize = true;
        lblFilterStatus.Location = new Point(405, 17);
        lblFilterStatus.Name = "lblFilterStatus";
        lblFilterStatus.Size = new Size(69, 17);
        lblFilterStatus.TabIndex = 2;
        lblFilterStatus.Text = "Tình trạng:";

        // 
        // txtSearch
        // 
        txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtSearch.Location = new Point(75, 13);
        txtSearch.Name = "txtSearch";
        txtSearch.PlaceholderText = "Nhập Mã SV hoặc tên thiết bị...";
        txtSearch.Size = new Size(315, 24);
        txtSearch.TabIndex = 1;

        // 
        // lblSearch
        // 
        lblSearch.AutoSize = true;
        lblSearch.Location = new Point(5, 16);
        lblSearch.Name = "lblSearch";
        lblSearch.Size = new Size(63, 17);
        lblSearch.TabIndex = 0;
        lblSearch.Text = "Tìm kiếm:";

        // 
        // grpInput
        // 
        grpInput.Controls.Add(btnDanhDauDaTra);
        grpInput.Controls.Add(btnLamMoi);
        grpInput.Controls.Add(btnXoa);
        grpInput.Controls.Add(btnCapNhat);
        grpInput.Controls.Add(btnThem);
        grpInput.Controls.Add(cboStatus);
        grpInput.Controls.Add(lblStatus);
        grpInput.Controls.Add(dtpReturnDate);
        grpInput.Controls.Add(chkHasReturned);
        grpInput.Controls.Add(dtpDueDate);
        grpInput.Controls.Add(lblDueDate);
        grpInput.Controls.Add(dtpBorrowDate);
        grpInput.Controls.Add(lblBorrowDate);
        grpInput.Controls.Add(nudQuantity);
        grpInput.Controls.Add(lblQuantity);
        grpInput.Controls.Add(cboEquipment);
        grpInput.Controls.Add(lblEquipment);
        grpInput.Controls.Add(txtStudentName);
        grpInput.Controls.Add(lblStudentName);
        grpInput.Controls.Add(txtStudentId);
        grpInput.Controls.Add(lblStudentId);
        grpInput.Controls.Add(txtBorrowId);
        grpInput.Controls.Add(lblBorrowId);
        grpInput.Dock = DockStyle.Left;
        grpInput.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
        grpInput.Location = new Point(10, 10);
        grpInput.Name = "grpInput";
        grpInput.Size = new Size(380, 605);
        grpInput.TabIndex = 0;
        grpInput.TabStop = false;
        grpInput.Text = "Thông tin phiếu mượn";

        // 
        // btnDanhDauDaTra
        // 
        btnDanhDauDaTra.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        btnDanhDauDaTra.BackColor = Color.FromArgb(230, 245, 230);
        btnDanhDauDaTra.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        btnDanhDauDaTra.ForeColor = Color.DarkGreen;
        btnDanhDauDaTra.Location = new Point(15, 420);
        btnDanhDauDaTra.Name = "btnDanhDauDaTra";
        btnDanhDauDaTra.Size = new Size(345, 34);
        btnDanhDauDaTra.TabIndex = 22;
        btnDanhDauDaTra.Text = "✔ Đánh dấu đã trả thiết bị";
        btnDanhDauDaTra.UseVisualStyleBackColor = false;

        // 
        // btnLamMoi
        // 
        btnLamMoi.Location = new Point(275, 375);
        btnLamMoi.Name = "btnLamMoi";
        btnLamMoi.Size = new Size(85, 32);
        btnLamMoi.TabIndex = 21;
        btnLamMoi.Text = "Làm mới";
        btnLamMoi.UseVisualStyleBackColor = true;

        // 
        // btnXoa
        // 
        btnXoa.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        btnXoa.Location = new Point(188, 375);
        btnXoa.Name = "btnXoa";
        btnXoa.Size = new Size(80, 32);
        btnXoa.TabIndex = 20;
        btnXoa.Text = "Xóa";
        btnXoa.UseVisualStyleBackColor = true;

        // 
        // btnCapNhat
        // 
        btnCapNhat.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        btnCapNhat.Location = new Point(101, 375);
        btnCapNhat.Name = "btnCapNhat";
        btnCapNhat.Size = new Size(80, 32);
        btnCapNhat.TabIndex = 19;
        btnCapNhat.Text = "Cập nhật";
        btnCapNhat.UseVisualStyleBackColor = true;

        // 
        // btnThem
        // 
        btnThem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        btnThem.Location = new Point(15, 375);
        btnThem.Name = "btnThem";
        btnThem.Size = new Size(80, 32);
        btnThem.TabIndex = 18;
        btnThem.Text = "Thêm";
        btnThem.UseVisualStyleBackColor = true;

        // 
        // cboStatus
        // 
        cboStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        cboStatus.FormattingEnabled = true;
        cboStatus.Location = new Point(125, 325);
        cboStatus.Name = "cboStatus";
        cboStatus.Size = new Size(235, 24);
        cboStatus.TabIndex = 17;

        // 
        // lblStatus
        // 
        lblStatus.AutoSize = true;
        lblStatus.Location = new Point(15, 328);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(71, 17);
        lblStatus.TabIndex = 16;
        lblStatus.Text = "Tình trạng:";

        // 
        // dtpReturnDate
        // 
        dtpReturnDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        dtpReturnDate.CustomFormat = "dd/MM/yyyy";
        dtpReturnDate.Enabled = false;
        dtpReturnDate.Format = DateTimePickerFormat.Custom;
        dtpReturnDate.Location = new Point(125, 288);
        dtpReturnDate.Name = "dtpReturnDate";
        dtpReturnDate.Size = new Size(235, 24);
        dtpReturnDate.TabIndex = 15;

        // 
        // chkHasReturned
        // 
        chkHasReturned.AutoSize = true;
        chkHasReturned.Location = new Point(15, 290);
        chkHasReturned.Name = "chkHasReturned";
        chkHasReturned.Size = new Size(98, 21);
        chkHasReturned.TabIndex = 14;
        chkHasReturned.Text = "Đã trả ngày:";
        chkHasReturned.UseVisualStyleBackColor = true;

        // 
        // dtpDueDate
        // 
        dtpDueDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        dtpDueDate.CustomFormat = "dd/MM/yyyy";
        dtpDueDate.Format = DateTimePickerFormat.Custom;
        dtpDueDate.Location = new Point(125, 252);
        dtpDueDate.Name = "dtpDueDate";
        dtpDueDate.Size = new Size(235, 24);
        dtpDueDate.TabIndex = 13;

        // 
        // lblDueDate
        // 
        lblDueDate.AutoSize = true;
        lblDueDate.Location = new Point(15, 255);
        lblDueDate.Name = "lblDueDate";
        lblDueDate.Size = new Size(63, 17);
        lblDueDate.TabIndex = 12;
        lblDueDate.Text = "Hạn trả *:";

        // 
        // dtpBorrowDate
        // 
        dtpBorrowDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        dtpBorrowDate.CustomFormat = "dd/MM/yyyy";
        dtpBorrowDate.Format = DateTimePickerFormat.Custom;
        dtpBorrowDate.Location = new Point(125, 216);
        dtpBorrowDate.Name = "dtpBorrowDate";
        dtpBorrowDate.Size = new Size(235, 24);
        dtpBorrowDate.TabIndex = 11;

        // 
        // lblBorrowDate
        // 
        lblBorrowDate.AutoSize = true;
        lblBorrowDate.Location = new Point(15, 219);
        lblBorrowDate.Name = "lblBorrowDate";
        lblBorrowDate.Size = new Size(88, 17);
        lblBorrowDate.TabIndex = 10;
        lblBorrowDate.Text = "Ngày mượn *:";

        // 
        // nudQuantity
        // 
        nudQuantity.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        nudQuantity.Location = new Point(125, 180);
        nudQuantity.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        nudQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudQuantity.Name = "nudQuantity";
        nudQuantity.Size = new Size(235, 24);
        nudQuantity.TabIndex = 9;
        nudQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });

        // 
        // lblQuantity
        // 
        lblQuantity.AutoSize = true;
        lblQuantity.Location = new Point(15, 182);
        lblQuantity.Name = "lblQuantity";
        lblQuantity.Size = new Size(72, 17);
        lblQuantity.TabIndex = 8;
        lblQuantity.Text = "Số lượng *:";

        // 
        // cboEquipment
        // 
        cboEquipment.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        cboEquipment.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEquipment.FormattingEnabled = true;
        cboEquipment.Location = new Point(125, 143);
        cboEquipment.Name = "cboEquipment";
        cboEquipment.Size = new Size(235, 24);
        cboEquipment.TabIndex = 7;

        // 
        // lblEquipment
        // 
        lblEquipment.AutoSize = true;
        lblEquipment.Location = new Point(15, 146);
        lblEquipment.Name = "lblEquipment";
        lblEquipment.Size = new Size(61, 17);
        lblEquipment.TabIndex = 6;
        lblEquipment.Text = "Thiết bị *:";

        // 
        // txtStudentName
        // 
        txtStudentName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtStudentName.Location = new Point(125, 107);
        txtStudentName.Name = "txtStudentName";
        txtStudentName.Size = new Size(235, 24);
        txtStudentName.TabIndex = 5;

        // 
        // lblStudentName
        // 
        lblStudentName.AutoSize = true;
        lblStudentName.Location = new Point(15, 110);
        lblStudentName.Name = "lblStudentName";
        lblStudentName.Size = new Size(95, 17);
        lblStudentName.TabIndex = 4;
        lblStudentName.Text = "Họ tên SV *:";

        // 
        // txtStudentId
        // 
        txtStudentId.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtStudentId.Location = new Point(125, 71);
        txtStudentId.Name = "txtStudentId";
        txtStudentId.Size = new Size(235, 24);
        txtStudentId.TabIndex = 3;

        // 
        // lblStudentId
        // 
        lblStudentId.AutoSize = true;
        lblStudentId.Location = new Point(15, 74);
        lblStudentId.Name = "lblStudentId";
        lblStudentId.Size = new Size(91, 17);
        lblStudentId.TabIndex = 2;
        lblStudentId.Text = "Mã sinh viên *:";

        // 
        // txtBorrowId
        // 
        txtBorrowId.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtBorrowId.Location = new Point(125, 35);
        txtBorrowId.Name = "txtBorrowId";
        txtBorrowId.Size = new Size(235, 24);
        txtBorrowId.TabIndex = 1;

        // 
        // lblBorrowId
        // 
        lblBorrowId.AutoSize = true;
        lblBorrowId.Location = new Point(15, 38);
        lblBorrowId.Name = "lblBorrowId";
        lblBorrowId.Size = new Size(72, 17);
        lblBorrowId.TabIndex = 0;
        lblBorrowId.Text = "Mã phiếu *:";

        // 
        // errorProvider1
        // 
        errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        errorProvider1.ContainerControl = this;

        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1150, 671);
        Controls.Add(pnlContainer);
        Controls.Add(statusStripMain);
        Controls.Add(menuStripMain);
        MainMenuStrip = menuStripMain;
        MinimumSize = new Size(980, 560);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Lab Equipment Checkout - Quản lý mượn trả thiết bị phòng thực hành";
        menuStripMain.ResumeLayout(false);
        menuStripMain.PerformLayout();
        statusStripMain.ResumeLayout(false);
        statusStripMain.PerformLayout();
        pnlContainer.ResumeLayout(false);
        grpList.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvBorrowRecords).EndInit();
        pnlSearchFilter.ResumeLayout(false);
        pnlSearchFilter.PerformLayout();
        grpInput.ResumeLayout(false);
        grpInput.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)nudQuantity).EndInit();
        ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private MenuStrip menuStripMain;
    private ToolStripMenuItem menuFile;
    private ToolStripMenuItem menuExportCsv;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripMenuItem menuExit;
    private StatusStrip statusStripMain;
    private ToolStripStatusLabel lblStatusTotal;
    private Panel pnlContainer;
    private GroupBox grpInput;
    private GroupBox grpList;
    private Label lblBorrowId;
    private TextBox txtBorrowId;
    private Label lblStudentId;
    private TextBox txtStudentId;
    private Label lblStudentName;
    private TextBox txtStudentName;
    private Label lblEquipment;
    private ComboBox cboEquipment;
    private Label lblQuantity;
    private NumericUpDown nudQuantity;
    private Label lblBorrowDate;
    private DateTimePicker dtpBorrowDate;
    private Label lblDueDate;
    private DateTimePicker dtpDueDate;
    private CheckBox chkHasReturned;
    private DateTimePicker dtpReturnDate;
    private Label lblStatus;
    private ComboBox cboStatus;
    private Button btnThem;
    private Button btnCapNhat;
    private Button btnXoa;
    private Button btnLamMoi;
    private Button btnDanhDauDaTra;
    private Panel pnlSearchFilter;
    private Label lblSearch;
    private TextBox txtSearch;
    private Label lblFilterStatus;
    private ComboBox cboFilterStatus;
    private Button btnResetFilter;
    private DataGridView dgvBorrowRecords;
    private ErrorProvider errorProvider1;
    private SaveFileDialog saveFileDialog1;
}
