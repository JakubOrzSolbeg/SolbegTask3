namespace SolbegTask3.Models.Reservation;

public class ReservationRootModel
{
    public WorkplaceSearchParams SearchParams { get; set; }
    public List<Workplace.Workplace> AwaibleWorkplaces { get; set; }
}