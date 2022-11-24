namespace SolbegTask3.Models.Reservation;

public class ReservationDetailed
{
    public string? EmployeeFirstName { get; set; }
    public string? EmployeeLastName { get; set; }
    public int WorkplaceId { get; set; }
    public int? Room { get; set; }
    public int? Floor { get; set; }
    public int? Table { get; set; }
    public List<string>? Equipments { get; set; }
}