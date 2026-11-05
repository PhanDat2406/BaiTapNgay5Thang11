namespace Bai1;

public class Appointment
{
    public string AppointmentId { get; set; } = string.Empty;
    public string PatientName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime AppointmentDateTime { get; set; }
    public string Doctor { get; set; } = string.Empty;
    public string Reason { get; set; } = string.Empty;
    public string Status { get; set; } = "Chờ khám";

    public Appointment()
    {
    }

    public Appointment(string id, string name, string phone, DateTime dateTime, string doctor, string reason, string status)
    {
        AppointmentId = id;
        PatientName = name;
        PhoneNumber = phone;
        AppointmentDateTime = dateTime;
        Doctor = doctor;
        Reason = reason;
        Status = status;
    }
}
