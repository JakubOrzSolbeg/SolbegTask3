namespace SolbegTask3.Models.Reservation;

public class MakeReservation
{
    public string EmployeeId { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    
    public int? Floor { get; set; }
    public int? Room { get; set; }
    public int? Table { get; set; }
}