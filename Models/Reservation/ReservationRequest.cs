namespace SolbegTask3.Models.Reservation;

public class ReservationRequest
{
    public int WorkplaceId { get; set; }
    public DateTime TimeFrom { get; set; }
    public DateTime TimeTo { get; set; }
}