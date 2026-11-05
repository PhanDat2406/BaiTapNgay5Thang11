using System.ComponentModel;
using System.Text;

namespace Bai3;

public partial class Form1 : Form
{
    private readonly BindingList<RepairOrder> _allOrders = new();
    private readonly BindingList<RepairOrder> _filteredOrders = new();
    private readonly BindingSource _bindingSource = new();
    private RepairOrder? _selectedOrder;
    private string _currentImagePath = string.Empty;

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

        string appDir = AppDomain.CurrentDomain.BaseDirectory;
        string imgDir = Path.Combine(appDir, "SampleImages");
        ImageHelper.EnsureSampleImages(imgDir);

        LoadSampleData(imgDir);
        ApplyFilter();
    }

    private void InitializeControls()
    {
        // Device types
        cboDeviceType.Items.AddRange(new object[]
        {
            "Điện thoại thông minh",
            "Máy tính bảng (Tablet)",
            "Laptop",
            "PC / Máy để bàn",
            "Màn hình máy tính",
            "Tai nghe / Phụ kiện",
            "Khác"
        });
        if (cboDeviceType.Items.Count > 0) cboDeviceType.SelectedIndex = 0;

        // Statuses
        string[] statuses = { "Mới tiếp nhận", "Đang sửa", "Chờ linh kiện", "Hoàn tất", "Đã hủy" };
        cboStatus.Items.AddRange(statuses);
        cboStatus.SelectedIndex = 0;

        // Filter statuses
        cboFilterStatus.Items.Add("Tất cả trạng thái");
        cboFilterStatus.Items.AddRange(statuses);
        cboFilterStatus.SelectedIndex = 0;

        dtpReceivedDate.Value = DateTime.Today;
        picDevice.SizeMode = PictureBoxSizeMode.Zoom;
    }

    private void ConfigureDataGridView()
    {
        dgvOrders.AutoGenerateColumns = false;
        dgvOrders.Columns.Clear();
        dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvOrders.ReadOnly = true;
        dgvOrders.MultiSelect = false;

        dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(RepairOrder.OrderId),
            HeaderText = "Mã đơn",
            Width = 90
        });

        dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(RepairOrder.CustomerName),
            HeaderText = "Tên khách hàng",
            Width = 150
        });

        dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(RepairOrder.PhoneNumber),
            HeaderText = "Số điện thoại",
            Width = 110
        });

        dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(RepairOrder.DeviceType),
            HeaderText = "Loại thiết bị",
            Width = 130
        });

        dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(RepairOrder.ReceivedDate),
            HeaderText = "Ngày tiếp nhận",
            Width = 110,
            DefaultCellStyle = new DataGridViewCellStyle
            {
                Format = "dd/MM/yyyy",
                Alignment = DataGridViewContentAlignment.MiddleCenter
            }
        });

        dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(RepairOrder.EstimatedCost),
            HeaderText = "Chi phí DK (VNĐ)",
            Width = 125,
            DefaultCellStyle = new DataGridViewCellStyle
            {
                Format = "N0",
                Alignment = DataGridViewContentAlignment.MiddleRight
            }
        });

        dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(RepairOrder.Status),
            HeaderText = "Trạng thái",
            Width = 110,
            DefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter
            }
        });

        dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(RepairOrder.IssueDescription),
            HeaderText = "Mô tả lỗi",
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        });

        _bindingSource.DataSource = _filteredOrders;
        dgvOrders.DataSource = _bindingSource;
    }

    private void RegisterEvents()
    {
        btnThem.Click += BtnThem_Click;
        btnCapNhat.Click += BtnCapNhat_Click;
        btnXoa.Click += BtnXoa_Click;
        btnLamMoi.Click += (s, e) => ResetInputs();

        btnChonAnh.Click += BtnChonAnh_Click;
        btnXoaAnh.Click += (s, e) => DisplayImage(string.Empty);

        dgvOrders.SelectionChanged += DgvOrders_SelectionChanged;

        txtSearch.TextChanged += (s, e) => ApplyFilter();
        cboFilterStatus.SelectedIndexChanged += (s, e) => ApplyFilter();
        btnResetFilter.Click += BtnResetFilter_Click;

        menuExportCsv.Click += MenuExportCsv_Click;
        menuExit.Click += (s, e) => Application.Exit();
    }

    private void LoadSampleData(string imgDir)
    {
        string phoneImg = Path.Combine(imgDir, "phone_screen_crack.png");
        string laptopImg = Path.Combine(imgDir, "laptop_battery.png");

        _allOrders.Add(new RepairOrder("SC001", "Nguyễn Văn Tuấn", "0918112233", "Điện thoại thông minh", "Màn hình OLED bị nứt kính, liệt cảm ứng góc dưới", DateTime.Today.AddDays(-3), 1250000, "Đang sửa", phoneImg));
        _allOrders.Add(new RepairOrder("SC002", "Trần Mai Phương", "0988776655", "Laptop", "Laptop Dell XPS không lên nguồn, chai pin phồng nắp đáy", DateTime.Today.AddDays(-2), 2400000, "Chờ linh kiện", laptopImg));
        _allOrders.Add(new RepairOrder("SC003", "Lê Hải Đăng", "0905123987", "PC / Máy để bàn", "Máy tính bật kêu 3 tiếng bíp liên tục, màn hình không xuất tín hiệu", DateTime.Today.AddDays(-1), 650000, "Mới tiếp nhận", ""));
        _allOrders.Add(new RepairOrder("SC004", "Phạm Thị Hương", "0932654987", "Máy tính bảng (Tablet)", "iPad gen 9 hỏng chân sạc Type-C, sạc chập chờn", DateTime.Today.AddDays(-5), 800000, "Hoàn tất", ""));
        _allOrders.Add(new RepairOrder("SC005", "Đỗ Quang Vinh", "0977112358", "Tai nghe / Phụ kiện", "AirPods Pro rè loa bên phải khi bật chống ồn", DateTime.Today.AddDays(-4), 500000, "Đã hủy", ""));
    }

    private void DgvOrders_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgvOrders.CurrentRow != null && dgvOrders.CurrentRow.DataBoundItem is RepairOrder order)
        {
            _selectedOrder = order;
            LoadOrderToInputs(order);
        }
    }

    private void LoadOrderToInputs(RepairOrder order)
    {
        txtOrderId.Text = order.OrderId;
        txtCustomerName.Text = order.CustomerName;
        txtPhoneNumber.Text = order.PhoneNumber;

        int deviceIdx = cboDeviceType.FindStringExact(order.DeviceType);
        if (deviceIdx >= 0) cboDeviceType.SelectedIndex = deviceIdx;
        else
        {
            cboDeviceType.Items.Add(order.DeviceType);
            cboDeviceType.SelectedItem = order.DeviceType;
        }

        dtpReceivedDate.Value = order.ReceivedDate;
        txtEstimatedCost.Text = order.EstimatedCost.ToString("0");

        int statusIdx = cboStatus.FindStringExact(order.Status);
        if (statusIdx >= 0) cboStatus.SelectedIndex = statusIdx;

        txtIssueDescription.Text = order.IssueDescription;
        DisplayImage(order.ImagePath);

        errorProvider1.Clear();
    }

    private void DisplayImage(string path)
    {
        _currentImagePath = path;
        picDevice.Image?.Dispose();
        picDevice.Image = null;

        if (!string.IsNullOrWhiteSpace(path) && File.Exists(path))
        {
            try
            {
                using var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                using var ms = new MemoryStream();
                fs.CopyTo(ms);
                ms.Position = 0;
                picDevice.Image = Image.FromStream(ms);
            }
            catch
            {
                picDevice.Image = null;
            }
        }
    }

    private void ResetInputs()
    {
        dgvOrders.ClearSelection();
        _selectedOrder = null;
        txtOrderId.Clear();
        txtCustomerName.Clear();
        txtPhoneNumber.Clear();
        if (cboDeviceType.Items.Count > 0) cboDeviceType.SelectedIndex = 0;
        dtpReceivedDate.Value = DateTime.Today;
        txtEstimatedCost.Text = "0";
        if (cboStatus.Items.Count > 0) cboStatus.SelectedIndex = 0;
        txtIssueDescription.Clear();
        DisplayImage(string.Empty);
        errorProvider1.Clear();
        txtOrderId.Focus();
    }

    private bool ValidateInputs(bool isAdding, out decimal parsedCost)
    {
        parsedCost = 0;
        errorProvider1.Clear();
        bool isValid = true;

        string id = txtOrderId.Text.Trim();
        if (string.IsNullOrWhiteSpace(id))
        {
            errorProvider1.SetError(txtOrderId, "Mã đơn không được để trống.");
            isValid = false;
        }
        else
        {
            bool duplicate = isAdding
                ? _allOrders.Any(o => o.OrderId.Equals(id, StringComparison.OrdinalIgnoreCase))
                : _allOrders.Any(o => o != _selectedOrder && o.OrderId.Equals(id, StringComparison.OrdinalIgnoreCase));

            if (duplicate)
            {
                errorProvider1.SetError(txtOrderId, "Mã đơn đã tồn tại trong hệ thống.");
                isValid = false;
            }
        }

        string name = txtCustomerName.Text.Trim();
        if (string.IsNullOrWhiteSpace(name))
        {
            errorProvider1.SetError(txtCustomerName, "Tên khách hàng không được để trống.");
            isValid = false;
        }

        string phone = txtPhoneNumber.Text.Trim();
        if (string.IsNullOrWhiteSpace(phone))
        {
            errorProvider1.SetError(txtPhoneNumber, "Số điện thoại không được để trống.");
            isValid = false;
        }

        // Validate Chi phí dự kiến: không âm
        string costText = txtEstimatedCost.Text.Trim().Replace(",", "").Replace(".", "");
        if (string.IsNullOrWhiteSpace(costText))
        {
            errorProvider1.SetError(txtEstimatedCost, "Chi phí dự kiến không được để trống.");
            isValid = false;
        }
        else if (!decimal.TryParse(costText, out parsedCost) || parsedCost < 0)
        {
            errorProvider1.SetError(txtEstimatedCost, "Chi phí dự kiến phải là số không âm (>= 0).");
            isValid = false;
        }

        // Mô tả lỗi bắt buộc
        string desc = txtIssueDescription.Text.Trim();
        if (string.IsNullOrWhiteSpace(desc))
        {
            errorProvider1.SetError(txtIssueDescription, "Mô tả lỗi bắt buộc phải nhập.");
            isValid = false;
        }

        return isValid;
    }

    private void BtnThem_Click(object? sender, EventArgs e)
    {
        if (!ValidateInputs(isAdding: true, out decimal cost))
            return;

        var order = new RepairOrder(
            txtOrderId.Text.Trim(),
            txtCustomerName.Text.Trim(),
            txtPhoneNumber.Text.Trim(),
            cboDeviceType.SelectedItem?.ToString() ?? "Khác",
            txtIssueDescription.Text.Trim(),
            dtpReceivedDate.Value.Date,
            cost,
            cboStatus.SelectedItem?.ToString() ?? "Mới tiếp nhận",
            _currentImagePath
        );

        _allOrders.Add(order);
        ApplyFilter();
        SelectRowByOrder(order);

        MessageBox.Show("Thêm đơn sửa chữa mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void BtnCapNhat_Click(object? sender, EventArgs e)
    {
        if (_selectedOrder == null)
        {
            MessageBox.Show("Vui lòng chọn đơn sửa chữa cần cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!ValidateInputs(isAdding: false, out decimal cost))
            return;

        _selectedOrder.OrderId = txtOrderId.Text.Trim();
        _selectedOrder.CustomerName = txtCustomerName.Text.Trim();
        _selectedOrder.PhoneNumber = txtPhoneNumber.Text.Trim();
        _selectedOrder.DeviceType = cboDeviceType.SelectedItem?.ToString() ?? "Khác";
        _selectedOrder.ReceivedDate = dtpReceivedDate.Value.Date;
        _selectedOrder.EstimatedCost = cost;
        _selectedOrder.Status = cboStatus.SelectedItem?.ToString() ?? "Mới tiếp nhận";
        _selectedOrder.IssueDescription = txtIssueDescription.Text.Trim();
        _selectedOrder.ImagePath = _currentImagePath;

        ApplyFilter();
        SelectRowByOrder(_selectedOrder);

        MessageBox.Show("Cập nhật đơn sửa chữa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void BtnXoa_Click(object? sender, EventArgs e)
    {
        if (_selectedOrder == null)
        {
            MessageBox.Show("Vui lòng chọn đơn sửa chữa cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var confirm = MessageBox.Show(
            $"Bạn có chắc chắn muốn xóa đơn sửa chữa [{_selectedOrder.OrderId}] của khách hàng '{_selectedOrder.CustomerName}' không?",
            "Xác nhận xóa",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        );

        if (confirm == DialogResult.Yes)
        {
            _allOrders.Remove(_selectedOrder);
            ResetInputs();
            ApplyFilter();
            MessageBox.Show("Đã xóa đơn sửa chữa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void BtnChonAnh_Click(object? sender, EventArgs e)
    {
        openFileDialog1.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All files (*.*)|*.*";
        openFileDialog1.Title = "Chọn ảnh thiết bị sửa chữa";

        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            DisplayImage(openFileDialog1.FileName);
        }
    }

    private void ApplyFilter()
    {
        string keyword = txtSearch.Text.Trim().ToLower();
        string filterStatus = cboFilterStatus.SelectedItem?.ToString() ?? "Tất cả trạng thái";

        var filtered = _allOrders.Where(o =>
        {
            bool matchSearch = string.IsNullOrEmpty(keyword)
                || o.OrderId.ToLower().Contains(keyword)
                || o.CustomerName.ToLower().Contains(keyword)
                || o.PhoneNumber.Contains(keyword);

            bool matchStatus = filterStatus == "Tất cả trạng thái" || o.Status == filterStatus;

            return matchSearch && matchStatus;
        }).ToList();

        _filteredOrders.Clear();
        foreach (var item in filtered)
        {
            _filteredOrders.Add(item);
        }

        UpdateStatusStrip();
    }

    private void UpdateStatusStrip()
    {
        int totalFiltered = _filteredOrders.Count;
        lblStatusOrders.Text = $"Số đơn hiển thị: {totalFiltered}";

        // Tổng chi phí dự kiến của các đơn chưa hoàn tất (Status != "Hoàn tất" && Status != "Đã hủy")
        decimal totalIncompleteCost = _allOrders
            .Where(o => o.Status != "Hoàn tất" && o.Status != "Đã hủy")
            .Sum(o => o.EstimatedCost);

        lblStatusTotalCost.Text = $"Tổng chi phí dự kiến (chưa hoàn tất): {totalIncompleteCost:N0} VNĐ";
    }

    private void BtnResetFilter_Click(object? sender, EventArgs e)
    {
        txtSearch.Clear();
        cboFilterStatus.SelectedIndex = 0;
        ApplyFilter();
    }

    private void SelectRowByOrder(RepairOrder order)
    {
        for (int i = 0; i < dgvOrders.Rows.Count; i++)
        {
            if (dgvOrders.Rows[i].DataBoundItem is RepairOrder current && current.OrderId == order.OrderId)
            {
                dgvOrders.Rows[i].Selected = true;
                dgvOrders.CurrentCell = dgvOrders.Rows[i].Cells[0];
                break;
            }
        }
    }

    private void MenuExportCsv_Click(object? sender, EventArgs e)
    {
        if (_filteredOrders.Count == 0)
        {
            MessageBox.Show("Không có đơn sửa chữa nào để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        saveFileDialog1.Filter = "CSV File (*.csv)|*.csv|All Files (*.*)|*.*";
        saveFileDialog1.FileName = $"DanhSachDonSuaChua_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
        saveFileDialog1.Title = "Xuất danh sách đơn sửa chữa ra CSV";

        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
        {
            try
            {
                var sb = new StringBuilder();
                // Header
                sb.AppendLine("Mã đơn,Tên khách hàng,Số điện thoại,Loại thiết bị,Ngày tiếp nhận,Chi phí dự kiến (VNĐ),Trạng thái,Mô tả lỗi,Đường dẫn ảnh");

                // Rows
                foreach (var o in _filteredOrders)
                {
                    sb.AppendLine(string.Join(",",
                        EscapeCsvField(o.OrderId),
                        EscapeCsvField(o.CustomerName),
                        EscapeCsvField(o.PhoneNumber),
                        EscapeCsvField(o.DeviceType),
                        EscapeCsvField(o.ReceivedDate.ToString("dd/MM/yyyy")),
                        o.EstimatedCost.ToString("0"),
                        EscapeCsvField(o.Status),
                        EscapeCsvField(o.IssueDescription),
                        EscapeCsvField(o.ImagePath)
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
