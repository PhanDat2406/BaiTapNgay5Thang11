namespace Bai3;

public class RepairOrder
{
    public string OrderId { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string DeviceType { get; set; } = string.Empty;
    public string IssueDescription { get; set; } = string.Empty;
    public DateTime ReceivedDate { get; set; } = DateTime.Today;
    public decimal EstimatedCost { get; set; } = 0;
    public string Status { get; set; } = "Mới tiếp nhận";
    public string ImagePath { get; set; } = string.Empty;

    public RepairOrder()
    {
    }

    public RepairOrder(string orderId, string customerName, string phone, string deviceType, string issue, DateTime receivedDate, decimal cost, string status, string imagePath = "")
    {
        OrderId = orderId;
        CustomerName = customerName;
        PhoneNumber = phone;
        DeviceType = deviceType;
        IssueDescription = issue;
        ReceivedDate = receivedDate;
        EstimatedCost = cost;
        Status = status;
        ImagePath = imagePath;
    }
}
