using SolbegTask3.Models.Workplace;

namespace SolbegTask3.DataBase.Repositories.Interfaces;

public interface IEquipmentRepository
{
    public Task<List<Equipment>> GetAllEquipment();
    public Task<List<string>> GetEquipmentNames();
    public Task<Dictionary<int, string>> GetAllEquipmentsNamesDict();
}