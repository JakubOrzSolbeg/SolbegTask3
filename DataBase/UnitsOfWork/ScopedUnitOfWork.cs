using SolbegTask3.DataBase.DbContext;
using SolbegTask3.DataBase.Repositories.Interfaces;

namespace SolbegTask3.DataBase.UnitsOfWork;

public class ScopedUnitOfWork : IMainUnitOfWork
{
    private readonly MainDbContext _dbContext;
    public IEmployeeRepository Employees { get; set; }
    public IEquipmentRepository Equipments { get; set; }
    public IWorkplaceRepository Workplaces { get; set; }
    public IReservationRepository Reservations { get; set; }

    public ScopedUnitOfWork(
        MainDbContext dbContext, 
        IEmployeeRepository employees, 
        IEquipmentRepository equipments, 
        IWorkplaceRepository workplaces, 
        IReservationRepository reservations)
    {
        _dbContext = dbContext;
        Employees = employees;
        Equipments = equipments;
        Workplaces = workplaces;
        Reservations = reservations;
    }
    
    public async Task Commit()
    {
        await _dbContext.SaveChangesAsync();
    }
}