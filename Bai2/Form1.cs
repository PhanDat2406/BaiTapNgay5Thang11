using System.ComponentModel;
using System.Text;

namespace Bai2;

public partial class Form1 : Form
{
    private readonly BindingList<BorrowRecord> _allRecords = new();
    private readonly BindingList<BorrowRecord> _filteredRecords = new();
    private readonly BindingSource _bindingSource = new();
    private BorrowRecord? _selectedRecord;

    public Form1()
    {
        InitializeComponent();
        this.Load += Form1_Load;
    }

    private void Form1_Load(object? sender, EventArgs e)
    {
        InitializeControls();
        ConfigureDataGridView();
        RegisterEvents();

        LoadSampleData();
        RefreshStatuses();
        ApplyFilter();
    }

    private void InitializeControls()
    {
        // Equipment dropdown
        cboEquipment.Items.AddRange(new object[]
        {
            "Bộ thí nghiệm IoT ESP32",
            "Máy hiện sóng Oscilloscope Rigol 100MHz",
            "Đồng hồ vạn năng số Sanwa CD800a",
            "Bộ KIT thực hành FPGA Cyclone IV",
            "Kính hiển vi soi vi mạch điện tử",
            "Bộ nguồn xung DC Agilent 30V/5A",
            "Máy phát sóng hàm FG-100 DDS"
        });
        if (cboEquipment.Items.Count > 0) cboEquipment.SelectedIndex = 0;

        // Status dropdown
        string[] statuses = { "Đang mượn", "Đã trả", "Quá hạn" };
        cboStatus.Items.AddRange(statuses);
        cboStatus.SelectedIndex = 0;

        // Filter status
        cboFilterStatus.Items.Add("Tất cả tình trạng");
        cboFilterStatus.Items.AddRange(statuses);
        cboFilterStatus.SelectedIndex = 0;

        dtpBorrowDate.Value = DateTime.Today;
        dtpDueDate.Value = DateTime.Today.AddDays(7);
        dtpReturnDate.Value = DateTime.Today;
        chkHasReturned.Checked = false;
        dtpReturnDate.Enabled = false;
    }

    private void ConfigureDataGridView()
    {
        dgvBorrowRecords.AutoGenerateColumns = false;
        dgvBorrowRecords.Columns.Clear();
        dgvBorrowRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvBorrowRecords.ReadOnly = true;
        dgvBorrowRecords.MultiSelect = false;

        dgvBorrowRecords.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(BorrowRecord.BorrowId),
            HeaderText = "Mã phiếu",
            Width = 90
        });

        dgvBorrowRecords.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(BorrowRecord.StudentId),
            HeaderText = "Mã SV",
            Width = 100
        });

        dgvBorrowRecords.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(BorrowRecord.StudentName),
            HeaderText = "Họ tên sinh viên",
            Width = 160
        });

        dgvBorrowRecords.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(BorrowRecord.EquipmentName),
            HeaderText = "Thiết bị mượn",
            Width = 190
        });

        dgvBorrowRecords.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(BorrowRecord.Quantity),
            HeaderText = "Số lượng",
            Width = 75,
            DefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter
            }
        });

        dgvBorrowRecords.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(BorrowRecord.BorrowDate),
            HeaderText = "Ngày mượn",
            Width = 100,
            DefaultCellStyle = new DataGridViewCellStyle
            {
                Format = "dd/MM/yyyy",
                Alignment = DataGridViewContentAlignment.MiddleCenter
            }
        });

        dgvBorrowRecords.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(BorrowRecord.DueDate),
            HeaderText = "Hạn trả",
            Width = 100,
            DefaultCellStyle = new DataGridViewCellStyle
            {
                Format = "dd/MM/yyyy",
                Alignment = DataGridViewContentAlignment.MiddleCenter
            }
        });

        dgvBorrowRecords.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(BorrowRecord.ReturnDateDisplay),
            HeaderText = "Ngày trả TT",
            Width = 100,
            DefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter
            }
        });

        dgvBorrowRecords.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(BorrowRecord.Status),
            HeaderText = "Tình trạng",
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            DefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter
            }
        });

        _bindingSource.DataSource = _filteredRecords;
        dgvBorrowRecords.DataSource = _bindingSource;
    }

    private void RegisterEvents()
    {
        btnThem.Click += BtnThem_Click;
        btnCapNhat.Click += BtnCapNhat_Click;
        btnXoa.Click += BtnXoa_Click;
        btnDanhDauDaTra.Click += BtnDanhDauDaTra_Click;
        btnLamMoi.Click += (s, e) => ResetInputs();

        chkHasReturned.CheckedChanged += (s, e) =>
        {
            dtpReturnDate.Enabled = chkHasReturned.Checked;
            if (chkHasReturned.Checked && cboStatus.SelectedItem?.ToString() != "Đã trả")
            {
                cboStatus.SelectedItem = "Đã trả";
            }
        };

        cboStatus.SelectedIndexChanged += (s, e) =>
        {
            if (cboStatus.SelectedItem?.ToString() == "Đã trả" && !chkHasReturned.Checked)
            {
                chkHasReturned.Checked = true;
                dtpReturnDate.Value = DateTime.Today;
            }
        };

        dgvBorrowRecords.SelectionChanged += DgvBorrowRecords_SelectionChanged;

        txtSearch.TextChanged += (s, e) => ApplyFilter();
        cboFilterStatus.SelectedIndexChanged += (s, e) => ApplyFilter();
        btnResetFilter.Click += BtnResetFilter_Click;

        menuExportCsv.Click += MenuExportCsv_Click;
        menuExit.Click += (s, e) => Close();
    }

    private void LoadSampleData()
    {
        DateTime today = DateTime.Today;

        // Phiếu 1: Đang mượn đúng hạn
        _allRecords.Add(new BorrowRecord("PM001", "SV2022001", "Nguyễn Minh Khang", "Bộ thí nghiệm IoT ESP32", 1, today.AddDays(-2), today.AddDays(5), null, "Đang mượn"));

        // Phiếu 2: Quá hạn (hạn trả cách đây 3 ngày nhưng chưa trả)
        _allRecords.Add(new BorrowRecord("PM002", "SV2022045", "Trần Thị Thu Trang", "Máy hiện sóng Oscilloscope Rigol 100MHz", 1, today.AddDays(-10), today.AddDays(-3), null, "Quá hạn"));

        // Phiếu 3: Đã trả đúng hạn
        _allRecords.Add(new BorrowRecord("PM003", "SV2022112", "Lê Văn Bình", "Đồng hồ vạn năng số Sanwa CD800a", 2, today.AddDays(-5), today.AddDays(2), today.AddDays(-1), "Đã trả"));

        // Phiếu 4: Quá hạn khác
        _allRecords.Add(new BorrowRecord("PM004", "SV2022089", "Phạm Quốc Bảo", "Bộ KIT thực hành FPGA Cyclone IV", 1, today.AddDays(-14), today.AddDays(-1), null, "Quá hạn"));

        // Phiếu 5: Đang mượn
        _allRecords.Add(new BorrowRecord("PM005", "SV2022134", "Hoàng Ngọc Ánh", "Kính hiển vi soi vi mạch điện tử", 1, today.AddDays(-1), today.AddDays(6), null, "Đang mượn"));
    }

    private void RefreshStatuses()
    {
        foreach (var record in _allRecords)
        {
            record.CheckAndAutoUpdateStatus();
        }
    }

    private void DgvBorrowRecords_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgvBorrowRecords.CurrentRow != null && dgvBorrowRecords.CurrentRow.DataBoundItem is BorrowRecord record)
        {
            _selectedRecord = record;
            LoadRecordToInputs(record);
        }
    }

    private void LoadRecordToInputs(BorrowRecord record)
    {
        txtBorrowId.Text = record.BorrowId;
        txtStudentId.Text = record.StudentId;
        txtStudentName.Text = record.StudentName;

        int eqIdx = cboEquipment.FindStringExact(record.EquipmentName);
        if (eqIdx >= 0) cboEquipment.SelectedIndex = eqIdx;
        else
        {
            cboEquipment.Items.Add(record.EquipmentName);
            cboEquipment.SelectedItem = record.EquipmentName;
        }

        nudQuantity.Value = Math.Max(nudQuantity.Minimum, Math.Min(nudQuantity.Maximum, record.Quantity));
        dtpBorrowDate.Value = record.BorrowDate;
        dtpDueDate.Value = record.DueDate;

        if (record.ReturnDate.HasValue)
        {
            chkHasReturned.Checked = true;
            dtpReturnDate.Enabled = true;
            dtpReturnDate.Value = record.ReturnDate.Value;
        }
        else
        {
            chkHasReturned.Checked = false;
            dtpReturnDate.Enabled = false;
            dtpReturnDate.Value = DateTime.Today;
        }

        int statusIdx = cboStatus.FindStringExact(record.Status);
        if (statusIdx >= 0) cboStatus.SelectedIndex = statusIdx;

        errorProvider1.Clear();
    }

    private void ResetInputs()
    {
        dgvBorrowRecords.ClearSelection();
        _selectedRecord = null;
        txtBorrowId.Clear();
        txtStudentId.Clear();
        txtStudentName.Clear();
        if (cboEquipment.Items.Count > 0) cboEquipment.SelectedIndex = 0;
        nudQuantity.Value = 1;
        dtpBorrowDate.Value = DateTime.Today;
        dtpDueDate.Value = DateTime.Today.AddDays(7);
        chkHasReturned.Checked = false;
        dtpReturnDate.Enabled = false;
        dtpReturnDate.Value = DateTime.Today;
        if (cboStatus.Items.Count > 0) cboStatus.SelectedIndex = 0;
        errorProvider1.Clear();
        txtBorrowId.Focus();
    }

    private bool ValidateInputs(bool isAdding)
    {
        errorProvider1.Clear();
        bool isValid = true;

        string borrowId = txtBorrowId.Text.Trim();
        if (string.IsNullOrWhiteSpace(borrowId))
        {
            errorProvider1.SetError(txtBorrowId, "Mã phiếu không được để trống.");
            isValid = false;
        }
        else
        {
            bool duplicate = isAdding
                ? _allRecords.Any(r => r.BorrowId.Equals(borrowId, StringComparison.OrdinalIgnoreCase))
                : _allRecords.Any(r => r != _selectedRecord && r.BorrowId.Equals(borrowId, StringComparison.OrdinalIgnoreCase));

            if (duplicate)
            {
                errorProvider1.SetError(txtBorrowId, "Mã phiếu đã tồn tại trong hệ thống.");
                isValid = false;
            }
        }

        string studentId = txtStudentId.Text.Trim();
        if (string.IsNullOrWhiteSpace(studentId))
        {
            errorProvider1.SetError(txtStudentId, "Mã sinh viên không được để trống.");
            isValid = false;
        }

        string studentName = txtStudentName.Text.Trim();
        if (string.IsNullOrWhiteSpace(studentName))
        {
            errorProvider1.SetError(txtStudentName, "Họ tên sinh viên không được để trống.");
            isValid = false;
        }

        if (cboEquipment.SelectedItem == null || string.IsNullOrWhiteSpace(cboEquipment.Text))
        {
            errorProvider1.SetError(cboEquipment, "Thiết bị không được để trống.");
            isValid = false;
        }

        if (nudQuantity.Value <= 0)
        {
            errorProvider1.SetError(nudQuantity, "Số lượng phải lớn hơn 0.");
            isValid = false;
        }

        // Hạn trả không trước ngày mượn
        if (dtpDueDate.Value.Date < dtpBorrowDate.Value.Date)
        {
            errorProvider1.SetError(dtpDueDate, "Hạn trả không được trước ngày mượn.");
            isValid = false;
        }

        // Ngày trả thực tế không trước ngày mượn (nếu có trả)
        if (chkHasReturned.Checked && dtpReturnDate.Value.Date < dtpBorrowDate.Value.Date)
        {
            errorProvider1.SetError(dtpReturnDate, "Ngày trả thực tế không được trước ngày mượn.");
            isValid = false;
        }

        return isValid;
    }

    private void BtnThem_Click(object? sender, EventArgs e)
    {
        if (!ValidateInputs(isAdding: true))
            return;

        DateTime? returnDate = chkHasReturned.Checked ? dtpReturnDate.Value.Date : null;
        string status = cboStatus.SelectedItem?.ToString() ?? "Đang mượn";
        if (returnDate.HasValue) status = "Đã trả";

        var record = new BorrowRecord(
            txtBorrowId.Text.Trim(),
            txtStudentId.Text.Trim(),
            txtStudentName.Text.Trim(),
            cboEquipment.Text.Trim(),
            (int)nudQuantity.Value,
            dtpBorrowDate.Value.Date,
            dtpDueDate.Value.Date,
            returnDate,
            status
        );

        _allRecords.Add(record);
        RefreshStatuses();
        ApplyFilter();
        SelectRowByRecord(record);

        MessageBox.Show("Thêm phiếu mượn thiết bị thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void BtnCapNhat_Click(object? sender, EventArgs e)
    {
        if (_selectedRecord == null)
        {
            MessageBox.Show("Vui lòng chọn phiếu mượn từ danh sách để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!ValidateInputs(isAdding: false))
            return;

        _selectedRecord.BorrowId = txtBorrowId.Text.Trim();
        _selectedRecord.StudentId = txtStudentId.Text.Trim();
        _selectedRecord.StudentName = txtStudentName.Text.Trim();
        _selectedRecord.EquipmentName = cboEquipment.Text.Trim();
        _selectedRecord.Quantity = (int)nudQuantity.Value;
        _selectedRecord.BorrowDate = dtpBorrowDate.Value.Date;
        _selectedRecord.DueDate = dtpDueDate.Value.Date;
        _selectedRecord.ReturnDate = chkHasReturned.Checked ? dtpReturnDate.Value.Date : null;

        string selectedStatus = cboStatus.SelectedItem?.ToString() ?? "Đang mượn";
        if (_selectedRecord.ReturnDate.HasValue)
        {
            _selectedRecord.Status = "Đã trả";
        }
        else
        {
            _selectedRecord.Status = selectedStatus;
        }

        _selectedRecord.CheckAndAutoUpdateStatus();

        RefreshStatuses();
        ApplyFilter();
        SelectRowByRecord(_selectedRecord);

        MessageBox.Show("Cập nhật phiếu mượn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void BtnXoa_Click(object? sender, EventArgs e)
    {
        if (_selectedRecord == null)
        {
            MessageBox.Show("Vui lòng chọn phiếu mượn từ danh sách để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var confirm = MessageBox.Show(
            $"Bạn có chắc chắn muốn xóa phiếu [{_selectedRecord.BorrowId}] của sinh viên '{_selectedRecord.StudentName}' không?",
            "Xác nhận xóa",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        );

        if (confirm == DialogResult.Yes)
        {
            _allRecords.Remove(_selectedRecord);
            ResetInputs();
            ApplyFilter();
            MessageBox.Show("Đã xóa phiếu mượn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void BtnDanhDauDaTra_Click(object? sender, EventArgs e)
    {
        if (_selectedRecord == null)
        {
            MessageBox.Show("Vui lòng chọn một phiếu mượn cần đánh dấu đã trả.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (_selectedRecord.Status == "Đã trả")
        {
            MessageBox.Show("Phiếu này đã được đánh dấu trả trước đó rồi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        _selectedRecord.ReturnDate = DateTime.Today;
        _selectedRecord.Status = "Đã trả";

        chkHasReturned.Checked = true;
        dtpReturnDate.Value = DateTime.Today;
        cboStatus.SelectedItem = "Đã trả";

        RefreshStatuses();
        ApplyFilter();
        SelectRowByRecord(_selectedRecord);

        MessageBox.Show($"Đã cập nhật phiếu [{_selectedRecord.BorrowId}] sang trạng thái 'Đã trả' với ngày trả thực tế là {DateTime.Today:dd/MM/yyyy}!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void ApplyFilter()
    {
        string keyword = txtSearch.Text.Trim().ToLower();
        string filterStatus = cboFilterStatus.SelectedItem?.ToString() ?? "Tất cả tình trạng";

        var filtered = _allRecords.Where(r =>
        {
            // Search by student id or equipment name
            bool matchSearch = string.IsNullOrEmpty(keyword)
                || r.StudentId.ToLower().Contains(keyword)
                || r.EquipmentName.ToLower().Contains(keyword)
                || r.StudentName.ToLower().Contains(keyword);

            // Filter by status
            bool matchStatus = filterStatus == "Tất cả tình trạng" || r.Status == filterStatus;

            return matchSearch && matchStatus;
        }).ToList();

        _filteredRecords.Clear();
        foreach (var item in filtered)
        {
            _filteredRecords.Add(item);
        }

        UpdateStatusStrip();
    }

    private void UpdateStatusStrip()
    {
        int total = _filteredRecords.Count;
        int quaHan = _filteredRecords.Count(r => r.Status == "Quá hạn");
        int dangMuon = _filteredRecords.Count(r => r.Status == "Đang mượn");
        int daTra = _filteredRecords.Count(r => r.Status == "Đã trả");

        lblStatusTotal.Text = $"Tổng số phiếu: {total} | Quá hạn: {quaHan} | Đang mượn: {dangMuon} | Đã trả: {daTra}";
    }

    private void BtnResetFilter_Click(object? sender, EventArgs e)
    {
        txtSearch.Clear();
        cboFilterStatus.SelectedIndex = 0;
        ApplyFilter();
    }

    private void SelectRowByRecord(BorrowRecord record)
    {
        for (int i = 0; i < dgvBorrowRecords.Rows.Count; i++)
        {
            if (dgvBorrowRecords.Rows[i].DataBoundItem is BorrowRecord current && current.BorrowId == record.BorrowId)
            {
                dgvBorrowRecords.Rows[i].Selected = true;
                dgvBorrowRecords.CurrentCell = dgvBorrowRecords.Rows[i].Cells[0];
                break;
            }
        }
    }

    private void MenuExportCsv_Click(object? sender, EventArgs e)
    {
        if (_filteredRecords.Count == 0)
        {
            MessageBox.Show("Không có phiếu mượn nào để xuất ra file!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        saveFileDialog1.Filter = "CSV File (*.csv)|*.csv|All Files (*.*)|*.*";
        saveFileDialog1.FileName = $"DanhSachMuonThietBi_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
        saveFileDialog1.Title = "Xuất danh sách mượn thiết bị ra file CSV";

        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
        {
            try
            {
                var sb = new StringBuilder();
                // Header
                sb.AppendLine("Mã phiếu,Mã sinh viên,Họ tên sinh viên,Thiết bị,Số lượng,Ngày mượn,Hạn trả,Ngày trả thực tế,Tình trạng");

                // Rows
                foreach (var r in _filteredRecords)
                {
                    sb.AppendLine(string.Join(",",
                        EscapeCsvField(r.BorrowId),
                        EscapeCsvField(r.StudentId),
                        EscapeCsvField(r.StudentName),
                        EscapeCsvField(r.EquipmentName),
                        r.Quantity.ToString(),
                        EscapeCsvField(r.BorrowDate.ToString("dd/MM/yyyy")),
                        EscapeCsvField(r.DueDate.ToString("dd/MM/yyyy")),
                        EscapeCsvField(r.ReturnDateDisplay),
                        EscapeCsvField(r.Status)
                    ));
                }

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
