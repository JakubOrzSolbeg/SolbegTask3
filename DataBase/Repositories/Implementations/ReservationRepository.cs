using SolbegTask3.DataBase.DbContext;
using SolbegTask3.DataBase.Repositories.Interfaces;

namespace SolbegTask3.DataBase.Repositories.Implementations;

public class ReservationRepository : Repository, IReservationRepository
{
    public ReservationRepository(MainDbContext dbContext):base(dbContext)
    {
    }
}