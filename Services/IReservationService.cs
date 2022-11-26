using SolbegTask3.Models.Reservation;

namespace SolbegTask3.Services;

public interface IReservationService
{
    public Task AddReservation(string userGuid, ReservationRequest reservationRequest);
    public Task<List<UserReservation>> GetEmpReservations(string userGuid);
    public Task<List<ReservationDetailed>> GetAllReservation();
    public Task CancelReservation(int reservationId, string empGuid);
}