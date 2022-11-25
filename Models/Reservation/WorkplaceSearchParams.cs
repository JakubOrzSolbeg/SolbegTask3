using Microsoft.AspNetCore.Mvc.Rendering;
using SolbegTask3.Models.Workplace;

namespace SolbegTask3.Models.Reservation;

public class WorkplaceSearchParams
{
    public DateTime? DateFrom { get; set; }
    public DateTime? DateTo { get; set; }
    public List<Equipment> Equipments { get; set; }
}