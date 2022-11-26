namespace SolbegTask3.Models.Reservation;

public class UserReservation
{
    public Workplace.Workplace Workplace { get; set; }
    public DateTime TimeFrom { get; set; }
    public DateTime TimeTo { get; set; }
    public int ReservationId { get; set; }
}