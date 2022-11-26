using SolbegTask3.DataBase.Entities;
using SolbegTask3.Models.Reservation;

namespace SolbegTask3.DataBase.Repositories.Interfaces;

public interface IReservationRepository
{
    public Task MakeReservation(Reservation reservation);
    public Task<Reservation?> GetReservationById(int reservationId, int empId);
    public Task<List<ReservationDetailed>> GetAllReservations();
    public Task<List<UserReservation>> GetEmployeeReservations(int employeeId);
    public void DeleteReservation(Reservation reservation);
}