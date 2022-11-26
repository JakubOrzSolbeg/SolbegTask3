using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SolbegTask3.DataBase.DbContext;
using SolbegTask3.DataBase.Entities;
using SolbegTask3.DataBase.Repositories.Interfaces;
using SolbegTask3.Models.Reservation;

namespace SolbegTask3.DataBase.Repositories.Implementations;

public class ReservationRepository : Repository, IReservationRepository
{
    public ReservationRepository(MainDbContext dbContext):base(dbContext)
    {
    }

    public async Task MakeReservation(Reservation reservation)
    {
        await DbContext.Reservations.AddAsync(reservation);
    }

    public async Task<Reservation?> GetReservationById(int reservationId, int empId)
    {
        return await DbContext.Reservations
            .FirstOrDefaultAsync(reservation =>
            reservation.Id.Equals(reservationId) && reservation.EmployeeId.Equals(empId));
    }

    public async Task<List<ReservationDetailed>> GetAllReservations()
    {
        var result = await DbContext.Reservations.Join(DbContext.Employees,
                reservation => reservation.EmployeeId,
                employee => employee.Id,
                ((reservation, employee) => new { reservation, employee }))
            .Join(DbContext.Workplaces,
                r => r.reservation.WorkplaceId,
                workplace => workplace.Id,
                (__, workplace) => new { __.employee, __.reservation, workplace })
            .Select(arg => new ReservationDetailed()
            {
                EmployeeFirstName = arg.employee.FirstName,
                EmployeeLastName = arg.employee.LastName,
                Floor = arg.workplace.Floor,
                Table = arg.workplace.Table,
                Room = arg.workplace.Room,
                TimeFrom = arg.reservation.TimeFrom,
                TimeTo = arg.reservation.TimeTo
            }).ToListAsync();
        return result;
    }

    public async Task<List<UserReservation>> GetEmployeeReservations(int employeeId)
    {
        return await DbContext.Reservations.Where(r => r.EmployeeId.Equals(employeeId))
            .Join(DbContext.Workplaces,
                reservation => reservation.WorkplaceId,
                workplace => workplace.Id,
                (reservation, workplace) => new UserReservation()
                {
                    ReservationId = reservation.Id,
                    TimeFrom = reservation.TimeFrom,
                    TimeTo = reservation.TimeTo,
                    Workplace = new Models.Workplace.Workplace()
                    {
                        Floor = workplace.Floor,
                        Table = workplace.Table,
                        Room = workplace.Room
                    }
                })
            .ToListAsync();
    }

    public void DeleteReservation(Reservation reservation)
    {
        DbContext.Reservations.Remove(reservation);
    }
}