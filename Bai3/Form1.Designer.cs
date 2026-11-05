namespace Bai3;

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
        lblStatusOrders = new ToolStripStatusLabel();
        toolStripStatusLabelSeparator = new ToolStripStatusLabel();
        lblStatusTotalCost = new ToolStripStatusLabel();
        pnlContainer = new Panel();
        grpList = new GroupBox();
        dgvOrders = new DataGridView();
        pnlSearchFilter = new Panel();
        btnResetFilter = new Button();
        cboFilterStatus = new ComboBox();
        lblFilterStatus = new Label();
        txtSearch = new TextBox();
        lblSearch = new Label();
        pnlLeftScroll = new Panel();
        grpInput = new GroupBox();
        pnlButtons = new FlowLayoutPanel();
        btnThem = new Button();
        btnCapNhat = new Button();
        btnXoa = new Button();
        btnLamMoi = new Button();
        btnXoaAnh = new Button();
        btnChonAnh = new Button();
        picDevice = new PictureBox();
        lblImage = new Label();
        txtIssueDescription = new TextBox();
        lblIssueDescription = new Label();
        cboStatus = new ComboBox();
        lblStatus = new Label();
        txtEstimatedCost = new TextBox();
        lblEstimatedCost = new Label();
        dtpReceivedDate = new DateTimePicker();
        lblReceivedDate = new Label();
        cboDeviceType = new ComboBox();
        lblDeviceType = new Label();
        txtPhoneNumber = new TextBox();
        lblPhoneNumber = new Label();
        txtCustomerName = new TextBox();
        lblCustomerName = new Label();
        txtOrderId = new TextBox();
        lblOrderId = new Label();
        errorProvider1 = new ErrorProvider(components);
        openFileDialog1 = new OpenFileDialog();
        saveFileDialog1 = new SaveFileDialog();

        menuStripMain.SuspendLayout();
        statusStripMain.SuspendLayout();
        pnlContainer.SuspendLayout();
        grpList.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
        pnlSearchFilter.SuspendLayout();
        pnlLeftScroll.SuspendLayout();
        grpInput.SuspendLayout();
        pnlButtons.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)picDevice).BeginInit();
        ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
        SuspendLayout();

        // 
        // menuStripMain
        // 
        menuStripMain.Items.AddRange(new ToolStripItem[] { menuFile });
        menuStripMain.Location = new Point(0, 0);
        menuStripMain.Name = "menuStripMain";
        menuStripMain.Size = new Size(1200, 24);
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
        statusStripMain.Items.AddRange(new ToolStripItem[] { lblStatusOrders, toolStripStatusLabelSeparator, lblStatusTotalCost });
        statusStripMain.Location = new Point(0, 699);
        statusStripMain.Name = "statusStripMain";
        statusStripMain.Size = new Size(1200, 22);
        statusStripMain.TabIndex = 1;

        // 
        // lblStatusOrders
        // 
        lblStatusOrders.Name = "lblStatusOrders";
        lblStatusOrders.Size = new Size(121, 17);
        lblStatusOrders.Text = "Số đơn hiển thị: 0";

        // 
        // toolStripStatusLabelSeparator
        // 
        toolStripStatusLabelSeparator.Name = "toolStripStatusLabelSeparator";
        toolStripStatusLabelSeparator.Size = new Size(12, 17);
        toolStripStatusLabelSeparator.Text = " | ";

        // 
        // lblStatusTotalCost
        // 
        lblStatusTotalCost.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        lblStatusTotalCost.ForeColor = Color.DarkBlue;
        lblStatusTotalCost.Name = "lblStatusTotalCost";
        lblStatusTotalCost.Size = new Size(245, 17);
        lblStatusTotalCost.Text = "Tổng chi phí chưa hoàn tất: 0 VNĐ";

        // 
        // pnlContainer
        // 
        pnlContainer.Controls.Add(grpList);
        pnlContainer.Controls.Add(pnlLeftScroll);
        pnlContainer.Dock = DockStyle.Fill;
        pnlContainer.Location = new Point(0, 24);
        pnlContainer.Name = "pnlContainer";
        pnlContainer.Padding = new Padding(10);
        pnlContainer.Size = new Size(1200, 675);
        pnlContainer.TabIndex = 2;

        // 
        // grpList
        // 
        grpList.Controls.Add(dgvOrders);
        grpList.Controls.Add(pnlSearchFilter);
        grpList.Dock = DockStyle.Fill;
        grpList.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
        grpList.Location = new Point(430, 10);
        grpList.Name = "grpList";
        grpList.Padding = new Padding(10);
        grpList.Size = new Size(760, 655);
        grpList.TabIndex = 1;
        grpList.TabStop = false;
        grpList.Text = "Danh sách đơn sửa chữa";

        // 
        // dgvOrders
        // 
        dgvOrders.AllowUserToAddRows = false;
        dgvOrders.AllowUserToDeleteRows = false;
        dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvOrders.BackgroundColor = SystemColors.Window;
        dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvOrders.Dock = DockStyle.Fill;
        dgvOrders.Location = new Point(10, 80);
        dgvOrders.MultiSelect = false;
        dgvOrders.Name = "dgvOrders";
        dgvOrders.ReadOnly = true;
        dgvOrders.RowHeadersVisible = false;
        dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvOrders.Size = new Size(740, 565);
        dgvOrders.TabIndex = 1;

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
        pnlSearchFilter.Size = new Size(740, 53);
        pnlSearchFilter.TabIndex = 0;

        // 
        // btnResetFilter
        // 
        btnResetFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnResetFilter.Location = new Point(650, 11);
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
        cboFilterStatus.Location = new Point(485, 13);
        cboFilterStatus.Name = "cboFilterStatus";
        cboFilterStatus.Size = new Size(155, 24);
        cboFilterStatus.TabIndex = 3;

        // 
        // lblFilterStatus
        // 
        lblFilterStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblFilterStatus.AutoSize = true;
        lblFilterStatus.Location = new Point(410, 17);
        lblFilterStatus.Name = "lblFilterStatus";
        lblFilterStatus.Size = new Size(69, 17);
        lblFilterStatus.TabIndex = 2;
        lblFilterStatus.Text = "Trạng thái:";

        // 
        // txtSearch
        // 
        txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtSearch.Location = new Point(75, 13);
        txtSearch.Name = "txtSearch";
        txtSearch.PlaceholderText = "Nhập Mã đơn, Tên KH hoặc SĐT...";
        txtSearch.Size = new Size(320, 24);
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
        // pnlLeftScroll
        // 
        pnlLeftScroll.AutoScroll = true;
        pnlLeftScroll.Controls.Add(grpInput);
        pnlLeftScroll.Dock = DockStyle.Left;
        pnlLeftScroll.Location = new Point(10, 10);
        pnlLeftScroll.Name = "pnlLeftScroll";
        pnlLeftScroll.Size = new Size(420, 655);
        pnlLeftScroll.TabIndex = 0;

        // 
        // grpInput
        // 
        grpInput.Controls.Add(pnlButtons);
        grpInput.Controls.Add(btnXoaAnh);
        grpInput.Controls.Add(btnChonAnh);
        grpInput.Controls.Add(picDevice);
        grpInput.Controls.Add(lblImage);
        grpInput.Controls.Add(txtIssueDescription);
        grpInput.Controls.Add(lblIssueDescription);
        grpInput.Controls.Add(cboStatus);
        grpInput.Controls.Add(lblStatus);
        grpInput.Controls.Add(txtEstimatedCost);
        grpInput.Controls.Add(lblEstimatedCost);
        grpInput.Controls.Add(dtpReceivedDate);
        grpInput.Controls.Add(lblReceivedDate);
        grpInput.Controls.Add(cboDeviceType);
        grpInput.Controls.Add(lblDeviceType);
        grpInput.Controls.Add(txtPhoneNumber);
        grpInput.Controls.Add(lblPhoneNumber);
        grpInput.Controls.Add(txtCustomerName);
        grpInput.Controls.Add(lblCustomerName);
        grpInput.Controls.Add(txtOrderId);
        grpInput.Controls.Add(lblOrderId);
        grpInput.Dock = DockStyle.Fill;
        grpInput.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
        grpInput.Location = new Point(0, 0);
        grpInput.Name = "grpInput";
        grpInput.Size = new Size(420, 655);
        grpInput.TabIndex = 0;
        grpInput.TabStop = false;
        grpInput.Text = "Thông tin đơn sửa chữa";

        // 
        // pnlButtons
        // 
        pnlButtons.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        pnlButtons.Controls.Add(btnThem);
        pnlButtons.Controls.Add(btnCapNhat);
        pnlButtons.Controls.Add(btnXoa);
        pnlButtons.Controls.Add(btnLamMoi);
        pnlButtons.Location = new Point(15, 610);
        pnlButtons.Name = "pnlButtons";
        pnlButtons.Size = new Size(385, 40);
        pnlButtons.TabIndex = 20;

        // 
        // btnThem
        // 
        btnThem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        btnThem.Location = new Point(3, 3);
        btnThem.Name = "btnThem";
        btnThem.Size = new Size(85, 32);
        btnThem.TabIndex = 0;
        btnThem.Text = "Thêm";
        btnThem.UseVisualStyleBackColor = true;

        // 
        // btnCapNhat
        // 
        btnCapNhat.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        btnCapNhat.Location = new Point(94, 3);
        btnCapNhat.Name = "btnCapNhat";
        btnCapNhat.Size = new Size(85, 32);
        btnCapNhat.TabIndex = 1;
        btnCapNhat.Text = "Cập nhật";
        btnCapNhat.UseVisualStyleBackColor = true;

        // 
        // btnXoa
        // 
        btnXoa.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        btnXoa.Location = new Point(185, 3);
        btnXoa.Name = "btnXoa";
        btnXoa.Size = new Size(85, 32);
        btnXoa.TabIndex = 2;
        btnXoa.Text = "Xóa";
        btnXoa.UseVisualStyleBackColor = true;

        // 
        // btnLamMoi
        // 
        btnLamMoi.Location = new Point(276, 3);
        btnLamMoi.Name = "btnLamMoi";
        btnLamMoi.Size = new Size(85, 32);
        btnLamMoi.TabIndex = 3;
        btnLamMoi.Text = "Làm mới";
        btnLamMoi.UseVisualStyleBackColor = true;

        // 
        // btnXoaAnh
        // 
        btnXoaAnh.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        btnXoaAnh.Location = new Point(275, 565);
        btnXoaAnh.Name = "btnXoaAnh";
        btnXoaAnh.Size = new Size(90, 28);
        btnXoaAnh.TabIndex = 19;
        btnXoaAnh.Text = "Bỏ ảnh";
        btnXoaAnh.UseVisualStyleBackColor = true;

        // 
        // btnChonAnh
        // 
        btnChonAnh.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        btnChonAnh.Location = new Point(130, 565);
        btnChonAnh.Name = "btnChonAnh";
        btnChonAnh.Size = new Size(135, 28);
        btnChonAnh.TabIndex = 18;
        btnChonAnh.Text = "Chọn ảnh...";
        btnChonAnh.UseVisualStyleBackColor = true;

        // 
        // picDevice
        // 
        picDevice.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        picDevice.BackColor = Color.FromArgb(245, 245, 245);
        picDevice.BorderStyle = BorderStyle.FixedSingle;
        picDevice.Location = new Point(130, 425);
        picDevice.Name = "picDevice";
        picDevice.Size = new Size(250, 134);
        picDevice.SizeMode = PictureBoxSizeMode.Zoom;
        picDevice.TabIndex = 17;
        picDevice.TabStop = false;

        // 
        // lblImage
        // 
        lblImage.AutoSize = true;
        lblImage.Location = new Point(12, 430);
        lblImage.Name = "lblImage";
        lblImage.Size = new Size(79, 17);
        lblImage.TabIndex = 16;
        lblImage.Text = "Ảnh thiết bị:";

        // 
        // txtIssueDescription
        // 
        txtIssueDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtIssueDescription.Location = new Point(130, 325);
        txtIssueDescription.Multiline = true;
        txtIssueDescription.Name = "txtIssueDescription";
        txtIssueDescription.ScrollBars = ScrollBars.Vertical;
        txtIssueDescription.Size = new Size(250, 85);
        txtIssueDescription.TabIndex = 15;

        // 
        // lblIssueDescription
        // 
        lblIssueDescription.AutoSize = true;
        lblIssueDescription.Location = new Point(12, 328);
        lblIssueDescription.Name = "lblIssueDescription";
        lblIssueDescription.Size = new Size(81, 17);
        lblIssueDescription.TabIndex = 14;
        lblIssueDescription.Text = "Mô tả lỗi *:";

        // 
        // cboStatus
        // 
        cboStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        cboStatus.FormattingEnabled = true;
        cboStatus.Location = new Point(130, 280);
        cboStatus.Name = "cboStatus";
        cboStatus.Size = new Size(250, 24);
        cboStatus.TabIndex = 13;

        // 
        // lblStatus
        // 
        lblStatus.AutoSize = true;
        lblStatus.Location = new Point(12, 283);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(69, 17);
        lblStatus.TabIndex = 12;
        lblStatus.Text = "Trạng thái:";

        // 
        // txtEstimatedCost
        // 
        txtEstimatedCost.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtEstimatedCost.Location = new Point(130, 235);
        txtEstimatedCost.Name = "txtEstimatedCost";
        txtEstimatedCost.Size = new Size(250, 24);
        txtEstimatedCost.TabIndex = 11;
        txtEstimatedCost.Text = "0";

        // 
        // lblEstimatedCost
        // 
        lblEstimatedCost.AutoSize = true;
        lblEstimatedCost.Location = new Point(12, 238);
        lblEstimatedCost.Name = "lblEstimatedCost";
        lblEstimatedCost.Size = new Size(111, 17);
        lblEstimatedCost.TabIndex = 10;
        lblEstimatedCost.Text = "Chi phí dự kiến *:";

        // 
        // dtpReceivedDate
        // 
        dtpReceivedDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        dtpReceivedDate.CustomFormat = "dd/MM/yyyy";
        dtpReceivedDate.Format = DateTimePickerFormat.Custom;
        dtpReceivedDate.Location = new Point(130, 190);
        dtpReceivedDate.Name = "dtpReceivedDate";
        dtpReceivedDate.Size = new Size(250, 24);
        dtpReceivedDate.TabIndex = 9;

        // 
        // lblReceivedDate
        // 
        lblReceivedDate.AutoSize = true;
        lblReceivedDate.Location = new Point(12, 193);
        lblReceivedDate.Name = "lblReceivedDate";
        lblReceivedDate.Size = new Size(110, 17);
        lblReceivedDate.TabIndex = 8;
        lblReceivedDate.Text = "Ngày tiếp nhận *:";

        // 
        // cboDeviceType
        // 
        cboDeviceType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        cboDeviceType.DropDownStyle = ComboBoxStyle.DropDownList;
        cboDeviceType.FormattingEnabled = true;
        cboDeviceType.Location = new Point(130, 145);
        cboDeviceType.Name = "cboDeviceType";
        cboDeviceType.Size = new Size(250, 24);
        cboDeviceType.TabIndex = 7;

        // 
        // lblDeviceType
        // 
        lblDeviceType.AutoSize = true;
        lblDeviceType.Location = new Point(12, 148);
        lblDeviceType.Name = "lblDeviceType";
        lblDeviceType.Size = new Size(86, 17);
        lblDeviceType.TabIndex = 6;
        lblDeviceType.Text = "Loại thiết bị:";

        // 
        // txtPhoneNumber
        // 
        txtPhoneNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtPhoneNumber.Location = new Point(130, 105);
        txtPhoneNumber.Name = "txtPhoneNumber";
        txtPhoneNumber.Size = new Size(250, 24);
        txtPhoneNumber.TabIndex = 5;

        // 
        // lblPhoneNumber
        // 
        lblPhoneNumber.AutoSize = true;
        lblPhoneNumber.Location = new Point(12, 108);
        lblPhoneNumber.Name = "lblPhoneNumber";
        lblPhoneNumber.Size = new Size(95, 17);
        lblPhoneNumber.TabIndex = 4;
        lblPhoneNumber.Text = "Số điện thoại *:";

        // 
        // txtCustomerName
        // 
        txtCustomerName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtCustomerName.Location = new Point(130, 65);
        txtCustomerName.Name = "txtCustomerName";
        txtCustomerName.Size = new Size(250, 24);
        txtCustomerName.TabIndex = 3;

        // 
        // lblCustomerName
        // 
        lblCustomerName.AutoSize = true;
        lblCustomerName.Location = new Point(12, 68);
        lblCustomerName.Name = "lblCustomerName";
        lblCustomerName.Size = new Size(110, 17);
        lblCustomerName.TabIndex = 2;
        lblCustomerName.Text = "Tên khách hàng *:";

        // 
        // txtOrderId
        // 
        txtOrderId.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtOrderId.Location = new Point(130, 25);
        txtOrderId.Name = "txtOrderId";
        txtOrderId.Size = new Size(250, 24);
        txtOrderId.TabIndex = 1;

        // 
        // lblOrderId
        // 
        lblOrderId.AutoSize = true;
        lblOrderId.Location = new Point(12, 28);
        lblOrderId.Name = "lblOrderId";
        lblOrderId.Size = new Size(65, 17);
        lblOrderId.TabIndex = 0;
        lblOrderId.Text = "Mã đơn *:";

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
        ClientSize = new Size(1200, 721);
        Controls.Add(pnlContainer);
        Controls.Add(statusStripMain);
        Controls.Add(menuStripMain);
        MainMenuStrip = menuStripMain;
        MinimumSize = new Size(1000, 600);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Repair Service Tracker - Quản lý đơn đăng ký dịch vụ sửa chữa";
        menuStripMain.ResumeLayout(false);
        menuStripMain.PerformLayout();
        statusStripMain.ResumeLayout(false);
        statusStripMain.PerformLayout();
        pnlContainer.ResumeLayout(false);
        grpList.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
        pnlSearchFilter.ResumeLayout(false);
        pnlSearchFilter.PerformLayout();
        pnlLeftScroll.ResumeLayout(false);
        grpInput.ResumeLayout(false);
        grpInput.PerformLayout();
        pnlButtons.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)picDevice).EndInit();
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
    private ToolStripStatusLabel lblStatusOrders;
    private ToolStripStatusLabel toolStripStatusLabelSeparator;
    private ToolStripStatusLabel lblStatusTotalCost;
    private Panel pnlContainer;
    private Panel pnlLeftScroll;
    private GroupBox grpInput;
    private GroupBox grpList;
    private Label lblOrderId;
    private TextBox txtOrderId;
    private Label lblCustomerName;
    private TextBox txtCustomerName;
    private Label lblPhoneNumber;
    private TextBox txtPhoneNumber;
    private Label lblDeviceType;
    private ComboBox cboDeviceType;
    private Label lblReceivedDate;
    private DateTimePicker dtpReceivedDate;
    private Label lblEstimatedCost;
    private TextBox txtEstimatedCost;
    private Label lblStatus;
    private ComboBox cboStatus;
    private Label lblIssueDescription;
    private TextBox txtIssueDescription;
    private Label lblImage;
    private PictureBox picDevice;
    private Button btnChonAnh;
    private Button btnXoaAnh;
    private FlowLayoutPanel pnlButtons;
    private Button btnThem;
    private Button btnCapNhat;
    private Button btnXoa;
    private Button btnLamMoi;
    private Panel pnlSearchFilter;
    private Label lblSearch;
    private TextBox txtSearch;
    private Label lblFilterStatus;
    private ComboBox cboFilterStatus;
    private Button btnResetFilter;
    private DataGridView dgvOrders;
    private ErrorProvider errorProvider1;
    private OpenFileDialog openFileDialog1;
    private SaveFileDialog saveFileDialog1;
}
