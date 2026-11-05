namespace Bai1;

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
        lblStatusCount = new ToolStripStatusLabel();
        tlpMain = new TableLayoutPanel();
        grpInputs = new GroupBox();
        tlpInputs = new TableLayoutPanel();
        lblAppointmentId = new Label();
        txtAppointmentId = new TextBox();
        lblPatientName = new Label();
        txtPatientName = new TextBox();
        lblPhoneNumber = new Label();
        txtPhoneNumber = new TextBox();
        lblAppointmentDateTime = new Label();
        dtpAppointmentDateTime = new DateTimePicker();
        lblDoctor = new Label();
        cboDoctor = new ComboBox();
        lblStatus = new Label();
        cboStatus = new ComboBox();
        lblReason = new Label();
        txtReason = new TextBox();
        pnlButtons = new FlowLayoutPanel();
        btnThem = new Button();
        btnCapNhat = new Button();
        btnXoa = new Button();
        btnLamMoi = new Button();
        grpList = new GroupBox();
        dgvAppointments = new DataGridView();
        pnlFilter = new Panel();
        btnResetFilter = new Button();
        cboFilterStatus = new ComboBox();
        lblFilterStatus = new Label();
        dtpFilterDate = new DateTimePicker();
        chkFilterDate = new CheckBox();
        txtSearch = new TextBox();
        lblSearch = new Label();
        errorProvider1 = new ErrorProvider(components);
        saveFileDialog1 = new SaveFileDialog();

        menuStripMain.SuspendLayout();
        statusStripMain.SuspendLayout();
        tlpMain.SuspendLayout();
        grpInputs.SuspendLayout();
        tlpInputs.SuspendLayout();
        pnlButtons.SuspendLayout();
        grpList.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvAppointments).BeginInit();
        pnlFilter.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
        SuspendLayout();

        // 
        // menuStripMain
        // 
        menuStripMain.Items.AddRange(new ToolStripItem[] { menuFile });
        menuStripMain.Location = new Point(0, 0);
        menuStripMain.Name = "menuStripMain";
        menuStripMain.Size = new Size(1100, 24);
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
        statusStripMain.Items.AddRange(new ToolStripItem[] { lblStatusCount });
        statusStripMain.Location = new Point(0, 639);
        statusStripMain.Name = "statusStripMain";
        statusStripMain.Size = new Size(1100, 22);
        statusStripMain.TabIndex = 1;

        // 
        // lblStatusCount
        // 
        lblStatusCount.Name = "lblStatusCount";
        lblStatusCount.Size = new Size(137, 17);
        lblStatusCount.Text = "Tổng số lịch hẹn: 0";

        // 
        // tlpMain
        // 
        tlpMain.ColumnCount = 2;
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 380F));
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tlpMain.Controls.Add(grpInputs, 0, 0);
        tlpMain.Controls.Add(grpList, 1, 0);
        tlpMain.Dock = DockStyle.Fill;
        tlpMain.Location = new Point(0, 24);
        tlpMain.Name = "tlpMain";
        tlpMain.RowCount = 1;
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tlpMain.Size = new Size(1100, 615);
        tlpMain.TabIndex = 2;

        // 
        // grpInputs
        // 
        grpInputs.Controls.Add(tlpInputs);
        grpInputs.Dock = DockStyle.Fill;
        grpInputs.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
        grpInputs.Location = new Point(8, 8);
        grpInputs.Margin = new Padding(8);
        grpInputs.Name = "grpInputs";
        grpInputs.Padding = new Padding(10);
        grpInputs.Size = new Size(364, 599);
        grpInputs.TabIndex = 0;
        grpInputs.TabStop = false;
        grpInputs.Text = "Thông tin lịch hẹn";

        // 
        // tlpInputs
        // 
        tlpInputs.ColumnCount = 2;
        tlpInputs.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
        tlpInputs.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tlpInputs.Controls.Add(lblAppointmentId, 0, 0);
        tlpInputs.Controls.Add(txtAppointmentId, 1, 0);
        tlpInputs.Controls.Add(lblPatientName, 0, 1);
        tlpInputs.Controls.Add(txtPatientName, 1, 1);
        tlpInputs.Controls.Add(lblPhoneNumber, 0, 2);
        tlpInputs.Controls.Add(txtPhoneNumber, 1, 2);
        tlpInputs.Controls.Add(lblAppointmentDateTime, 0, 3);
        tlpInputs.Controls.Add(dtpAppointmentDateTime, 1, 3);
        tlpInputs.Controls.Add(lblDoctor, 0, 4);
        tlpInputs.Controls.Add(cboDoctor, 1, 4);
        tlpInputs.Controls.Add(lblStatus, 0, 5);
        tlpInputs.Controls.Add(cboStatus, 1, 5);
        tlpInputs.Controls.Add(lblReason, 0, 6);
        tlpInputs.Controls.Add(txtReason, 1, 6);
        tlpInputs.Controls.Add(pnlButtons, 0, 7);
        tlpInputs.Dock = DockStyle.Fill;
        tlpInputs.Location = new Point(10, 27);
        tlpInputs.Name = "tlpInputs";
        tlpInputs.RowCount = 8;
        tlpInputs.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
        tlpInputs.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
        tlpInputs.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
        tlpInputs.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
        tlpInputs.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
        tlpInputs.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
        tlpInputs.RowStyles.Add(new RowStyle(SizeType.Absolute, 85F));
        tlpInputs.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tlpInputs.Size = new Size(344, 562);
        tlpInputs.TabIndex = 0;

        // 
        // lblAppointmentId
        // 
        lblAppointmentId.Anchor = AnchorStyles.Left;
        lblAppointmentId.AutoSize = true;
        lblAppointmentId.Location = new Point(3, 9);
        lblAppointmentId.Name = "lblAppointmentId";
        lblAppointmentId.Size = new Size(82, 17);
        lblAppointmentId.TabIndex = 0;
        lblAppointmentId.Text = "Mã lịch hẹn *";

        // 
        // txtAppointmentId
        // 
        txtAppointmentId.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtAppointmentId.Location = new Point(113, 5);
        txtAppointmentId.Margin = new Padding(3, 3, 20, 3);
        txtAppointmentId.Name = "txtAppointmentId";
        txtAppointmentId.Size = new Size(211, 24);
        txtAppointmentId.TabIndex = 1;

        // 
        // lblPatientName
        // 
        lblPatientName.Anchor = AnchorStyles.Left;
        lblPatientName.AutoSize = true;
        lblPatientName.Location = new Point(3, 44);
        lblPatientName.Name = "lblPatientName";
        lblPatientName.Size = new Size(74, 17);
        lblPatientName.TabIndex = 2;
        lblPatientName.Text = "Họ tên BN *";

        // 
        // txtPatientName
        // 
        txtPatientName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtPatientName.Location = new Point(113, 40);
        txtPatientName.Margin = new Padding(3, 3, 20, 3);
        txtPatientName.Name = "txtPatientName";
        txtPatientName.Size = new Size(211, 24);
        txtPatientName.TabIndex = 3;

        // 
        // lblPhoneNumber
        // 
        lblPhoneNumber.Anchor = AnchorStyles.Left;
        lblPhoneNumber.AutoSize = true;
        lblPhoneNumber.Location = new Point(3, 79);
        lblPhoneNumber.Name = "lblPhoneNumber";
        lblPhoneNumber.Size = new Size(92, 17);
        lblPhoneNumber.TabIndex = 4;
        lblPhoneNumber.Text = "Số điện thoại *";

        // 
        // txtPhoneNumber
        // 
        txtPhoneNumber.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtPhoneNumber.Location = new Point(113, 75);
        txtPhoneNumber.Margin = new Padding(3, 3, 20, 3);
        txtPhoneNumber.Name = "txtPhoneNumber";
        txtPhoneNumber.Size = new Size(211, 24);
        txtPhoneNumber.TabIndex = 5;

        // 
        // lblAppointmentDateTime
        // 
        lblAppointmentDateTime.Anchor = AnchorStyles.Left;
        lblAppointmentDateTime.AutoSize = true;
        lblAppointmentDateTime.Location = new Point(3, 114);
        lblAppointmentDateTime.Name = "lblAppointmentDateTime";
        lblAppointmentDateTime.Size = new Size(71, 17);
        lblAppointmentDateTime.TabIndex = 6;
        lblAppointmentDateTime.Text = "Ngày hẹn *";

        // 
        // dtpAppointmentDateTime
        // 
        dtpAppointmentDateTime.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        dtpAppointmentDateTime.CustomFormat = "dd/MM/yyyy HH:mm";
        dtpAppointmentDateTime.Format = DateTimePickerFormat.Custom;
        dtpAppointmentDateTime.Location = new Point(113, 110);
        dtpAppointmentDateTime.Margin = new Padding(3, 3, 20, 3);
        dtpAppointmentDateTime.Name = "dtpAppointmentDateTime";
        dtpAppointmentDateTime.Size = new Size(211, 24);
        dtpAppointmentDateTime.TabIndex = 7;

        // 
        // lblDoctor
        // 
        lblDoctor.Anchor = AnchorStyles.Left;
        lblDoctor.AutoSize = true;
        lblDoctor.Location = new Point(3, 149);
        lblDoctor.Name = "lblDoctor";
        lblDoctor.Size = new Size(45, 17);
        lblDoctor.TabIndex = 8;
        lblDoctor.Text = "Bác sĩ";

        // 
        // cboDoctor
        // 
        cboDoctor.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        cboDoctor.DropDownStyle = ComboBoxStyle.DropDownList;
        cboDoctor.FormattingEnabled = true;
        cboDoctor.Location = new Point(113, 145);
        cboDoctor.Margin = new Padding(3, 3, 20, 3);
        cboDoctor.Name = "cboDoctor";
        cboDoctor.Size = new Size(211, 24);
        cboDoctor.TabIndex = 9;

        // 
        // lblStatus
        // 
        lblStatus.Anchor = AnchorStyles.Left;
        lblStatus.AutoSize = true;
        lblStatus.Location = new Point(3, 184);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(66, 17);
        lblStatus.TabIndex = 10;
        lblStatus.Text = "Trạng thái";

        // 
        // cboStatus
        // 
        cboStatus.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        cboStatus.FormattingEnabled = true;
        cboStatus.Location = new Point(113, 180);
        cboStatus.Margin = new Padding(3, 3, 20, 3);
        cboStatus.Name = "cboStatus";
        cboStatus.Size = new Size(211, 24);
        cboStatus.TabIndex = 11;

        // 
        // lblReason
        // 
        lblReason.AutoSize = true;
        lblReason.Location = new Point(3, 215);
        lblReason.Margin = new Padding(3, 5, 3, 0);
        lblReason.Name = "lblReason";
        lblReason.Size = new Size(84, 17);
        lblReason.TabIndex = 12;
        lblReason.Text = "Lý do khám *";

        // 
        // txtReason
        // 
        txtReason.Dock = DockStyle.Fill;
        txtReason.Location = new Point(113, 213);
        txtReason.Margin = new Padding(3, 3, 20, 3);
        txtReason.Multiline = true;
        txtReason.Name = "txtReason";
        txtReason.ScrollBars = ScrollBars.Vertical;
        txtReason.Size = new Size(211, 79);
        txtReason.TabIndex = 13;

        // 
        // pnlButtons
        // 
        tlpInputs.SetColumnSpan(pnlButtons, 2);
        pnlButtons.Controls.Add(btnThem);
        pnlButtons.Controls.Add(btnCapNhat);
        pnlButtons.Controls.Add(btnXoa);
        pnlButtons.Controls.Add(btnLamMoi);
        pnlButtons.Dock = DockStyle.Top;
        pnlButtons.Location = new Point(3, 298);
        pnlButtons.Name = "pnlButtons";
        pnlButtons.Padding = new Padding(0, 10, 0, 0);
        pnlButtons.Size = new Size(338, 90);
        pnlButtons.TabIndex = 14;

        // 
        // btnThem
        // 
        btnThem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        btnThem.Location = new Point(3, 13);
        btnThem.Name = "btnThem";
        btnThem.Size = new Size(78, 32);
        btnThem.TabIndex = 0;
        btnThem.Text = "Thêm";
        btnThem.UseVisualStyleBackColor = true;

        // 
        // btnCapNhat
        // 
        btnCapNhat.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        btnCapNhat.Location = new Point(87, 13);
        btnCapNhat.Name = "btnCapNhat";
        btnCapNhat.Size = new Size(78, 32);
        btnCapNhat.TabIndex = 1;
        btnCapNhat.Text = "Cập nhật";
        btnCapNhat.UseVisualStyleBackColor = true;

        // 
        // btnXoa
        // 
        btnXoa.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        btnXoa.Location = new Point(171, 13);
        btnXoa.Name = "btnXoa";
        btnXoa.Size = new Size(78, 32);
        btnXoa.TabIndex = 2;
        btnXoa.Text = "Xóa";
        btnXoa.UseVisualStyleBackColor = true;

        // 
        // btnLamMoi
        // 
        btnLamMoi.Location = new Point(255, 13);
        btnLamMoi.Name = "btnLamMoi";
        btnLamMoi.Size = new Size(78, 32);
        btnLamMoi.TabIndex = 3;
        btnLamMoi.Text = "Làm mới";
        btnLamMoi.UseVisualStyleBackColor = true;

        // 
        // grpList
        // 
        grpList.Controls.Add(dgvAppointments);
        grpList.Controls.Add(pnlFilter);
        grpList.Dock = DockStyle.Fill;
        grpList.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
        grpList.Location = new Point(388, 8);
        grpList.Margin = new Padding(8);
        grpList.Name = "grpList";
        grpList.Padding = new Padding(10);
        grpList.Size = new Size(704, 599);
        grpList.TabIndex = 1;
        grpList.TabStop = false;
        grpList.Text = "Danh sách lịch hẹn";

        // 
        // dgvAppointments
        // 
        dgvAppointments.AllowUserToAddRows = false;
        dgvAppointments.AllowUserToDeleteRows = false;
        dgvAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvAppointments.BackgroundColor = SystemColors.Window;
        dgvAppointments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvAppointments.Dock = DockStyle.Fill;
        dgvAppointments.Location = new Point(10, 80);
        dgvAppointments.MultiSelect = false;
        dgvAppointments.Name = "dgvAppointments";
        dgvAppointments.ReadOnly = true;
        dgvAppointments.RowHeadersVisible = false;
        dgvAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvAppointments.Size = new Size(684, 509);
        dgvAppointments.TabIndex = 1;

        // 
        // pnlFilter
        // 
        pnlFilter.Controls.Add(btnResetFilter);
        pnlFilter.Controls.Add(cboFilterStatus);
        pnlFilter.Controls.Add(lblFilterStatus);
        pnlFilter.Controls.Add(dtpFilterDate);
        pnlFilter.Controls.Add(chkFilterDate);
        pnlFilter.Controls.Add(txtSearch);
        pnlFilter.Controls.Add(lblSearch);
        pnlFilter.Dock = DockStyle.Top;
        pnlFilter.Location = new Point(10, 27);
        pnlFilter.Name = "pnlFilter";
        pnlFilter.Size = new Size(684, 53);
        pnlFilter.TabIndex = 0;

        // 
        // btnResetFilter
        // 
        btnResetFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnResetFilter.Location = new Point(598, 12);
        btnResetFilter.Name = "btnResetFilter";
        btnResetFilter.Size = new Size(80, 28);
        btnResetFilter.TabIndex = 6;
        btnResetFilter.Text = "Bỏ lọc";
        btnResetFilter.UseVisualStyleBackColor = true;

        // 
        // cboFilterStatus
        // 
        cboFilterStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        cboFilterStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        cboFilterStatus.FormattingEnabled = true;
        cboFilterStatus.Location = new Point(483, 14);
        cboFilterStatus.Name = "cboFilterStatus";
        cboFilterStatus.Size = new Size(108, 24);
        cboFilterStatus.TabIndex = 5;

        // 
        // lblFilterStatus
        // 
        lblFilterStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblFilterStatus.AutoSize = true;
        lblFilterStatus.Location = new Point(410, 18);
        lblFilterStatus.Name = "lblFilterStatus";
        lblFilterStatus.Size = new Size(69, 17);
        lblFilterStatus.TabIndex = 4;
        lblFilterStatus.Text = "Trạng thái:";

        // 
        // dtpFilterDate
        // 
        dtpFilterDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        dtpFilterDate.CustomFormat = "dd/MM/yyyy";
        dtpFilterDate.Enabled = false;
        dtpFilterDate.Format = DateTimePickerFormat.Custom;
        dtpFilterDate.Location = new Point(295, 14);
        dtpFilterDate.Name = "dtpFilterDate";
        dtpFilterDate.Size = new Size(105, 24);
        dtpFilterDate.TabIndex = 3;

        // 
        // chkFilterDate
        // 
        chkFilterDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        chkFilterDate.AutoSize = true;
        chkFilterDate.Location = new Point(207, 16);
        chkFilterDate.Name = "chkFilterDate";
        chkFilterDate.Size = new Size(84, 21);
        chkFilterDate.TabIndex = 2;
        chkFilterDate.Text = "Lọc ngày:";
        chkFilterDate.UseVisualStyleBackColor = true;

        // 
        // txtSearch
        // 
        txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtSearch.Location = new Point(70, 14);
        txtSearch.Name = "txtSearch";
        txtSearch.PlaceholderText = "Tên hoặc SĐT...";
        txtSearch.Size = new Size(130, 24);
        txtSearch.TabIndex = 1;

        // 
        // lblSearch
        // 
        lblSearch.AutoSize = true;
        lblSearch.Location = new Point(3, 17);
        lblSearch.Name = "lblSearch";
        lblSearch.Size = new Size(63, 17);
        lblSearch.TabIndex = 0;
        lblSearch.Text = "Tìm kiếm:";

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
        ClientSize = new Size(1100, 661);
        Controls.Add(tlpMain);
        Controls.Add(statusStripMain);
        Controls.Add(menuStripMain);
        MainMenuStrip = menuStripMain;
        MinimumSize = new Size(950, 550);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Clinic Appointment Manager - Quản lý lịch hẹn phòng khám";
        menuStripMain.ResumeLayout(false);
        menuStripMain.PerformLayout();
        statusStripMain.ResumeLayout(false);
        statusStripMain.PerformLayout();
        tlpMain.ResumeLayout(false);
        grpInputs.ResumeLayout(false);
        tlpInputs.ResumeLayout(false);
        tlpInputs.PerformLayout();
        pnlButtons.ResumeLayout(false);
        grpList.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvAppointments).EndInit();
        pnlFilter.ResumeLayout(false);
        pnlFilter.PerformLayout();
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
    private ToolStripStatusLabel lblStatusCount;
    private TableLayoutPanel tlpMain;
    private GroupBox grpInputs;
    private TableLayoutPanel tlpInputs;
    private Label lblAppointmentId;
    private TextBox txtAppointmentId;
    private Label lblPatientName;
    private TextBox txtPatientName;
    private Label lblPhoneNumber;
    private TextBox txtPhoneNumber;
    private Label lblAppointmentDateTime;
    private DateTimePicker dtpAppointmentDateTime;
    private Label lblDoctor;
    private ComboBox cboDoctor;
    private Label lblStatus;
    private ComboBox cboStatus;
    private Label lblReason;
    private TextBox txtReason;
    private FlowLayoutPanel pnlButtons;
    private Button btnThem;
    private Button btnCapNhat;
    private Button btnXoa;
    private Button btnLamMoi;
    private GroupBox grpList;
    private DataGridView dgvAppointments;
    private Panel pnlFilter;
    private TextBox txtSearch;
    private Label lblSearch;
    private CheckBox chkFilterDate;
    private DateTimePicker dtpFilterDate;
    private Label lblFilterStatus;
    private ComboBox cboFilterStatus;
    private Button btnResetFilter;
    private ErrorProvider errorProvider1;
    private SaveFileDialog saveFileDialog1;
}
