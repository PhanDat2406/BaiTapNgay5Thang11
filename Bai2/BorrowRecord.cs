namespace Bai2;

public class BorrowRecord
{
    public string BorrowId { get; set; } = string.Empty;
    public string StudentId { get; set; } = string.Empty;
    public string StudentName { get; set; } = string.Empty;
    public string EquipmentName { get; set; } = string.Empty;
    public int Quantity { get; set; } = 1;
    public DateTime BorrowDate { get; set; } = DateTime.Today;
    public DateTime DueDate { get; set; } = DateTime.Today.AddDays(7);
    public DateTime? ReturnDate { get; set; }
    public string Status { get; set; } = "Đang mượn";

    public string ReturnDateDisplay => ReturnDate.HasValue ? ReturnDate.Value.ToString("dd/MM/yyyy") : "Chưa trả";

    public BorrowRecord()
    {
    }

    public BorrowRecord(string borrowId, string studentId, string studentName, string equipment, int quantity, DateTime borrowDate, DateTime dueDate, DateTime? returnDate, string status)
    {
        BorrowId = borrowId;
        StudentId = studentId;
        StudentName = studentName;
        EquipmentName = equipment;
        Quantity = quantity;
        BorrowDate = borrowDate;
        DueDate = dueDate;
        ReturnDate = returnDate;
        Status = status;
        CheckAndAutoUpdateStatus();
    }

    public void CheckAndAutoUpdateStatus()
    {
        if (Status != "Đã trả" && !ReturnDate.HasValue)
        {
            if (DueDate.Date < DateTime.Today)
            {
                Status = "Quá hạn";
            }
            else
            {
                Status = "Đang mượn";
            }
        }
    }
}
