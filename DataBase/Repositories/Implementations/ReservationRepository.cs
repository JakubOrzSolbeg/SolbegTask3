using Microsoft.EntityFrameworkCore;
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

    public async Task<bool> MakeReservation(MakeReservation makeReservation, int workplaceId)
    {
        var workplace = await DbContext.Workplaces
            .FirstOrDefaultAsync(w => w.Id.Equals(workplaceId));
        if (workplace == null)
        {
            return false;
        }

        await DbContext.Reservations.AddAsync(new Reservation()
        {
            EmployeeId = makeReservation.EmployeeId,
            TimeFrom = makeReservation.DateFrom,
            TimeTo = makeReservation.DateTo,
            WorkplaceId = workplace.Id
        });
        return true;
    }
}