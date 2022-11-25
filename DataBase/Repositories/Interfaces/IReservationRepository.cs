using SolbegTask3.Models.Reservation;

namespace SolbegTask3.DataBase.Repositories.Interfaces;

public interface IReservationRepository
{
    public Task<bool> MakeReservation(WorkplaceSearchParams makeReservation, int workplaceId);
    
}