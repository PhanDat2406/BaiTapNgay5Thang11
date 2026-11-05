using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;

namespace Bai1;

public partial class Form1 : Form
{
    private readonly BindingList<Appointment> _allAppointments = new();
    private readonly BindingList<Appointment> _filteredAppointments = new();
    private readonly BindingSource _bindingSource = new();
    private Appointment? _selectedAppointment;

    public Form1()
    {
        InitializeComponent();
        this.Load += Form1_Load;
    }

    private void Form1_Load(object? sender, EventArgs e)
    {
        InitializeComboBoxes();
        ConfigureDataGridView();
        RegisterEvents();

        // Sample initial data
        LoadSampleData();

        ApplyFilter();
    }

    private void InitializeComboBoxes()
    {
        // Doctor options
        cboDoctor.Items.AddRange(new object[]
        {
            "BS. Nguyễn Văn An (Nội tổng quát)",
            "BS. Trần Thị Bình (Tim mạch)",
            "BS. Lê Hoàng Cường (Da liễu)",
            "BS. Phạm Minh Đức (Nhi khoa)",
            "BS. Hoàng Mai Lan (Răng - Hàm - Mặt)"
        });
        if (cboDoctor.Items.Count > 0) cboDoctor.SelectedIndex = 0;

        // Status options
        string[] statuses = { "Chờ khám", "Đang khám", "Hoàn tất", "Đã hủy" };
        cboStatus.Items.AddRange(statuses);
        cboStatus.SelectedIndex = 0;

        // Filter status
        cboFilterStatus.Items.Add("Tất cả trạng thái");
        cboFilterStatus.Items.AddRange(statuses);
        cboFilterStatus.SelectedIndex = 0;

        // Default appointment datetime: Tomorrow at 09:00
        dtpAppointmentDateTime.Value = DateTime.Today.AddDays(1).AddHours(9);
        dtpFilterDate.Value = DateTime.Today;
    }

    private void ConfigureDataGridView()
    {
        dgvAppointments.AutoGenerateColumns = false;
        dgvAppointments.Columns.Clear();
        dgvAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvAppointments.ReadOnly = true;
        dgvAppointments.MultiSelect = false;

        dgvAppointments.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(Appointment.AppointmentId),
            HeaderText = "Mã LH",
            Width = 90
        });

        dgvAppointments.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(Appointment.PatientName),
            HeaderText = "Họ tên bệnh nhân",
            Width = 160
        });

        dgvAppointments.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(Appointment.PhoneNumber),
            HeaderText = "Số điện thoại",
            Width = 110
        });

        dgvAppointments.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(Appointment.AppointmentDateTime),
            HeaderText = "Ngày giờ hẹn",
            Width = 135,
            DefaultCellStyle = new DataGridViewCellStyle
            {
                Format = "dd/MM/yyyy HH:mm",
                Alignment = DataGridViewContentAlignment.MiddleCenter
            }
        });

        dgvAppointments.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(Appointment.Doctor),
            HeaderText = "Bác sĩ",
            Width = 150
        });

        dgvAppointments.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(Appointment.Status),
            HeaderText = "Trạng thái",
            Width = 100,
            DefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter
            }
        });

        dgvAppointments.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(Appointment.Reason),
            HeaderText = "Lý do khám",
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        });

        _bindingSource.DataSource = _filteredAppointments;
        dgvAppointments.DataSource = _bindingSource;
    }

    private void RegisterEvents()
    {
        btnThem.Click += BtnThem_Click;
        btnCapNhat.Click += BtnCapNhat_Click;
        btnXoa.Click += BtnXoa_Click;
        btnLamMoi.Click += (s, e) => ResetInputs();

        dgvAppointments.SelectionChanged += DgvAppointments_SelectionChanged;

        txtSearch.TextChanged += (s, e) => ApplyFilter();
        chkFilterDate.CheckedChanged += (s, e) =>
        {
            dtpFilterDate.Enabled = chkFilterDate.Checked;
            ApplyFilter();
        };
        dtpFilterDate.ValueChanged += (s, e) =>
        {
            if (chkFilterDate.Checked) ApplyFilter();
        };
        cboFilterStatus.SelectedIndexChanged += (s, e) => ApplyFilter();
        btnResetFilter.Click += BtnResetFilter_Click;

        menuExportCsv.Click += MenuExportCsv_Click;
        menuExit.Click += (s, e) => Close();
    }

    private void LoadSampleData()
    {
        DateTime baseDate = DateTime.Today;
        _allAppointments.Add(new Appointment("LH001", "Nguyễn Văn Hùng", "0912345678", baseDate.AddDays(1).AddHours(8).AddMinutes(30), "BS. Nguyễn Văn An (Nội tổng quát)", "Đau dạ dày và ợ chua", "Chờ khám"));
        _allAppointments.Add(new Appointment("LH002", "Trần Thị Mai", "0987654321", baseDate.AddDays(1).AddHours(9).AddMinutes(15), "BS. Trần Thị Bình (Tim mạch)", "Khám định kỳ huyết áp cao", "Chờ khám"));
        _allAppointments.Add(new Appointment("LH003", "Lê Văn Tùng", "0903123456", baseDate.AddHours(14).AddMinutes(0), "BS. Lê Hoàng Cường (Da liễu)", "Dị ứng mẩn đỏ vùng cánh tay", "Đang khám"));
        _allAppointments.Add(new Appointment("LH004", "Phạm Quỳnh Anh", "0978999888", baseDate.AddDays(2).AddHours(10).AddMinutes(0), "BS. Phạm Minh Đức (Nhi khoa)", "Bé ho sốt 2 ngày", "Chờ khám"));
        _allAppointments.Add(new Appointment("LH005", "Vũ Hoàng Long", "0934567890", baseDate.AddDays(-1).AddHours(15).AddMinutes(0), "BS. Hoàng Mai Lan (Răng - Hàm - Mặt)", "Nhổ răng khôn số 8", "Hoàn tất"));
    }

    private void DgvAppointments_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgvAppointments.CurrentRow != null && dgvAppointments.CurrentRow.DataBoundItem is Appointment appointment)
        {
            _selectedAppointment = appointment;
            LoadAppointmentToInputs(appointment);
        }
    }

    private void LoadAppointmentToInputs(Appointment apt)
    {
        txtAppointmentId.Text = apt.AppointmentId;
        txtPatientName.Text = apt.PatientName;
        txtPhoneNumber.Text = apt.PhoneNumber;
        dtpAppointmentDateTime.Value = apt.AppointmentDateTime;

        int docIdx = cboDoctor.FindStringExact(apt.Doctor);
        if (docIdx >= 0) cboDoctor.SelectedIndex = docIdx;
        else
        {
            cboDoctor.Items.Add(apt.Doctor);
            cboDoctor.SelectedItem = apt.Doctor;
        }

        int statusIdx = cboStatus.FindStringExact(apt.Status);
        if (statusIdx >= 0) cboStatus.SelectedIndex = statusIdx;

        txtReason.Text = apt.Reason;
        errorProvider1.Clear();
    }

    private void ResetInputs()
    {
        dgvAppointments.ClearSelection();
        _selectedAppointment = null;
        txtAppointmentId.Clear();
        txtPatientName.Clear();
        txtPhoneNumber.Clear();
        dtpAppointmentDateTime.Value = DateTime.Today.AddDays(1).AddHours(9);
        if (cboDoctor.Items.Count > 0) cboDoctor.SelectedIndex = 0;
        if (cboStatus.Items.Count > 0) cboStatus.SelectedIndex = 0;
        txtReason.Clear();
        errorProvider1.Clear();
        txtAppointmentId.Focus();
    }

    private bool ValidateInputs(bool isAdding)
    {
        errorProvider1.Clear();
        bool isValid = true;

        string id = txtAppointmentId.Text.Trim();
        if (string.IsNullOrWhiteSpace(id))
        {
            errorProvider1.SetError(txtAppointmentId, "Mã lịch hẹn không được để trống.");
            isValid = false;
        }
        else
        {
            bool duplicate = isAdding
                ? _allAppointments.Any(a => a.AppointmentId.Equals(id, StringComparison.OrdinalIgnoreCase))
                : _allAppointments.Any(a => a != _selectedAppointment && a.AppointmentId.Equals(id, StringComparison.OrdinalIgnoreCase));

            if (duplicate)
            {
                errorProvider1.SetError(txtAppointmentId, "Mã lịch hẹn đã tồn tại, vui lòng chọn mã khác.");
                isValid = false;
            }
        }

        string name = txtPatientName.Text.Trim();
        if (string.IsNullOrWhiteSpace(name))
        {
            errorProvider1.SetError(txtPatientName, "Họ tên bệnh nhân không được để trống.");
            isValid = false;
        }

        string phone = txtPhoneNumber.Text.Trim();
        if (string.IsNullOrWhiteSpace(phone))
        {
            errorProvider1.SetError(txtPhoneNumber, "Số điện thoại không được để trống.");
            isValid = false;
        }
        else if (!Regex.IsMatch(phone, @"^0\d{9}$"))
        {
            errorProvider1.SetError(txtPhoneNumber, "Số điện thoại phải gồm 10 chữ số và bắt đầu bằng số 0.");
            isValid = false;
        }

        // Ngày hẹn không được nằm trong quá khứ
        // So sánh tính đến phút hiện tại
        if (dtpAppointmentDateTime.Value < DateTime.Now.AddMinutes(-5))
        {
            errorProvider1.SetError(dtpAppointmentDateTime, "Ngày hẹn không được nằm trong quá khứ.");
            isValid = false;
        }

        if (cboDoctor.SelectedItem == null)
        {
            errorProvider1.SetError(cboDoctor, "Vui lòng chọn bác sĩ phụ trách.");
            isValid = false;
        }

        if (cboStatus.SelectedItem == null)
        {
            errorProvider1.SetError(cboStatus, "Vui lòng chọn trạng thái lịch hẹn.");
            isValid = false;
        }

        string reason = txtReason.Text.Trim();
        if (string.IsNullOrWhiteSpace(reason))
        {
            errorProvider1.SetError(txtReason, "Lý do khám không được để trống.");
            isValid = false;
        }

        return isValid;
    }

    private void BtnThem_Click(object? sender, EventArgs e)
    {
        if (!ValidateInputs(isAdding: true))
            return;

        var apt = new Appointment(
            txtAppointmentId.Text.Trim(),
            txtPatientName.Text.Trim(),
            txtPhoneNumber.Text.Trim(),
            dtpAppointmentDateTime.Value,
            cboDoctor.SelectedItem?.ToString() ?? "",
            txtReason.Text.Trim(),
            cboStatus.SelectedItem?.ToString() ?? "Chờ khám"
        );

        _allAppointments.Add(apt);
        ApplyFilter();

        // Select the newly added item
        SelectRowByAppointment(apt);
        MessageBox.Show("Thêm lịch hẹn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void BtnCapNhat_Click(object? sender, EventArgs e)
    {
        if (_selectedAppointment == null)
        {
            MessageBox.Show("Vui lòng chọn lịch hẹn từ danh sách để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!ValidateInputs(isAdding: false))
            return;

        _selectedAppointment.AppointmentId = txtAppointmentId.Text.Trim();
        _selectedAppointment.PatientName = txtPatientName.Text.Trim();
        _selectedAppointment.PhoneNumber = txtPhoneNumber.Text.Trim();
        _selectedAppointment.AppointmentDateTime = dtpAppointmentDateTime.Value;
        _selectedAppointment.Doctor = cboDoctor.SelectedItem?.ToString() ?? "";
        _selectedAppointment.Reason = txtReason.Text.Trim();
        _selectedAppointment.Status = cboStatus.SelectedItem?.ToString() ?? "Chờ khám";

        ApplyFilter();
        SelectRowByAppointment(_selectedAppointment);
        MessageBox.Show("Cập nhật lịch hẹn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void BtnXoa_Click(object? sender, EventArgs e)
    {
        if (_selectedAppointment == null)
        {
            MessageBox.Show("Vui lòng chọn lịch hẹn từ danh sách để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var confirm = MessageBox.Show(
            $"Bạn có chắc chắn muốn xóa lịch hẹn [{_selectedAppointment.AppointmentId}] của bệnh nhân '{_selectedAppointment.PatientName}' không?",
            "Xác nhận xóa",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        );

        if (confirm == DialogResult.Yes)
        {
            _allAppointments.Remove(_selectedAppointment);
            ResetInputs();
            ApplyFilter();
            MessageBox.Show("Đã xóa lịch hẹn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void ApplyFilter()
    {
        string keyword = txtSearch.Text.Trim().ToLower();
        bool filterDate = chkFilterDate.Checked;
        DateTime selectedDate = dtpFilterDate.Value.Date;
        string filterStatus = cboFilterStatus.SelectedItem?.ToString() ?? "Tất cả trạng thái";

        var filtered = _allAppointments.Where(apt =>
        {
            // Search by name or phone
            bool matchSearch = string.IsNullOrEmpty(keyword)
                || apt.PatientName.ToLower().Contains(keyword)
                || apt.PhoneNumber.Contains(keyword);

            // Filter by date
            bool matchDate = !filterDate || apt.AppointmentDateTime.Date == selectedDate;

            // Filter by status
            bool matchStatus = filterStatus == "Tất cả trạng thái" || apt.Status == filterStatus;

            return matchSearch && matchDate && matchStatus;
        }).ToList();

        _filteredAppointments.Clear();
        foreach (var item in filtered)
        {
            _filteredAppointments.Add(item);
        }

        UpdateStatusStrip();
    }

    private void UpdateStatusStrip()
    {
        int total = _filteredAppointments.Count;
        int choKham = _filteredAppointments.Count(a => a.Status == "Chờ khám");
        int dangKham = _filteredAppointments.Count(a => a.Status == "Đang khám");
        int hoanTat = _filteredAppointments.Count(a => a.Status == "Hoàn tất");
        int daHuy = _filteredAppointments.Count(a => a.Status == "Đã hủy");

        lblStatusCount.Text = $"Hiển thị: {total} lịch hẹn | Chờ khám: {choKham} | Đang khám: {dangKham} | Hoàn tất: {hoanTat} | Đã hủy: {daHuy}";
    }

    private void BtnResetFilter_Click(object? sender, EventArgs e)
    {
        txtSearch.Clear();
        chkFilterDate.Checked = false;
        cboFilterStatus.SelectedIndex = 0;
        ApplyFilter();
    }

    private void SelectRowByAppointment(Appointment apt)
    {
        for (int i = 0; i < dgvAppointments.Rows.Count; i++)
        {
            if (dgvAppointments.Rows[i].DataBoundItem is Appointment current && current.AppointmentId == apt.AppointmentId)
            {
                dgvAppointments.Rows[i].Selected = true;
                dgvAppointments.CurrentCell = dgvAppointments.Rows[i].Cells[0];
                break;
            }
        }
    }

    private void MenuExportCsv_Click(object? sender, EventArgs e)
    {
        if (_filteredAppointments.Count == 0)
        {
            MessageBox.Show("Không có dữ liệu lịch hẹn nào để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        saveFileDialog1.Filter = "CSV File (*.csv)|*.csv|All Files (*.*)|*.*";
        saveFileDialog1.FileName = $"DanhSachLichHen_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
        saveFileDialog1.Title = "Xuất danh sách lịch hẹn ra file CSV";

        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
        {
            try
            {
                var sb = new StringBuilder();
                // Header
                sb.AppendLine("Mã lịch hẹn,Họ tên bệnh nhân,Số điện thoại,Ngày giờ hẹn,Bác sĩ,Trạng thái,Lý do khám");

                // Rows
                foreach (var apt in _filteredAppointments)
                {
                    sb.AppendLine(string.Join(",",
                        EscapeCsvField(apt.AppointmentId),
                        EscapeCsvField(apt.PatientName),
                        EscapeCsvField(apt.PhoneNumber),
                        EscapeCsvField(apt.AppointmentDateTime.ToString("dd/MM/yyyy HH:mm")),
                        EscapeCsvField(apt.Doctor),
                        EscapeCsvField(apt.Status),
                        EscapeCsvField(apt.Reason)
                    ));
                }

                // UTF8 with BOM so Excel displays Vietnamese correctly
                File.WriteAllText(saveFileDialog1.FileName, sb.ToString(), Encoding.UTF8);

                MessageBox.Show($"Xuất dữ liệu thành công ra file:\n{saveFileDialog1.FileName}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất file CSV: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private static string EscapeCsvField(string field)
    {
        if (string.IsNullOrEmpty(field)) return "\"\"";
        if (field.Contains(',') || field.Contains('"') || field.Contains('\n') || field.Contains('\r'))
        {
            return $"\"{field.Replace("\"", "\"\"")}\"";
        }
        return field;
    }
}
