namespace SolbegTask3.Models.Reservation;

public class ReservationDetailed
{
    public string? EmployeeFirstName { get; set; }
    public string? EmployeeLastName { get; set; }
    public int? Room { get; set; }
    public int? Floor { get; set; }
    public int? Table { get; set; }
    public DateTime TimeFrom { get; set; }
    public DateTime TimeTo { get; set; }
}