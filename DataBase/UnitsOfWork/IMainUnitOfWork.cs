using SolbegTask3.DataBase.Repositories.Interfaces;

namespace SolbegTask3.DataBase.UnitsOfWork;

public interface IMainUnitOfWork
{
    public IEmployeeRepository Employees { get; set; }
    public IEquipmentRepository Equipments { get; set; }
    public IWorkplaceRepository Workplaces { get; set; }
    public IReservationRepository Reservations { get; set; }

    public Task Commit();
}