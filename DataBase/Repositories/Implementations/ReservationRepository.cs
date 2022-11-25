using System.ComponentModel.DataAnnotations;
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

    public async Task<bool> MakeReservation(WorkplaceSearchParams makeReservation, int workplaceId)
    {
        var workplace = await DbContext.Workplaces
            .FirstOrDefaultAsync(w => w.Id.Equals(workplaceId));
        if (workplace == null)
        {
            return false;
        }

        if (makeReservation.DateFrom == null || makeReservation.DateTo == null)
        {
            throw new ValidationException("Date cannot be null");
        }
        else
        {
            await DbContext.Reservations.AddAsync(new Reservation()
            {
                TimeFrom = makeReservation.DateFrom.Value.Date,
                TimeTo = makeReservation.DateTo.Value.Date,
                WorkplaceId = workplace.Id
            });
        }

        return true;
    }
}