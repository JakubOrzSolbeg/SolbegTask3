using SolbegTask3.DataBase.Entities;
using SolbegTask3.DataBase.UnitsOfWork;
using SolbegTask3.Models.Reservation;

namespace SolbegTask3.Services;

public class ReservationService : IReservationService
{
    private readonly IMainUnitOfWork _mainUnitOfWork;

    public ReservationService(IMainUnitOfWork mainUnitOfWork)
    {
        _mainUnitOfWork = mainUnitOfWork;
    }
    public async Task AddReservation(string userGuid, ReservationRequest reservationRequest)
    {
        int? userId = await _mainUnitOfWork.Employees.GetEmployeeByGuid(userGuid);
        if (userId == null)
        {
            return;
        }
        var reservation = new Reservation()
        {
            EmployeeId = userId.Value,
            WorkplaceId = reservationRequest.WorkplaceId,
            TimeFrom = reservationRequest.TimeFrom,
            TimeTo = reservationRequest.TimeTo
        };
        await _mainUnitOfWork.Reservations.MakeReservation(reservation);
        await _mainUnitOfWork.Commit();
    }

    public async Task<List<UserReservation>> GetEmpReservations(string userGuid)
    {
        var userId = await _mainUnitOfWork.Employees.GetEmployeeByGuid(userGuid);
        if (userId == null)
        {
            throw new ArgumentNullException();
        }
        return await _mainUnitOfWork.Reservations.GetEmployeeReservations(userId.Value);
    }

    public async Task<List<ReservationDetailed>> GetAllReservation()
    {
        return await _mainUnitOfWork.Reservations.GetAllReservations();
    }

    public async Task CancelReservation(int reservationId, string empGuid)
    {
        var empId = await _mainUnitOfWork.Employees.GetEmployeeByGuid(empGuid);
        if (!empId.HasValue)
        {
            return;
        }

        var reservationToDelete = await _mainUnitOfWork.Reservations.GetReservationById(reservationId, empId.Value);
        if (reservationToDelete == null)
        {
            return;
        }
        _mainUnitOfWork.Reservations.DeleteReservation(reservationToDelete);
        await _mainUnitOfWork.Commit();
    }
}