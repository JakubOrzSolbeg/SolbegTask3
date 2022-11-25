namespace SolbegTask3.Models.Workplace;

public class Equipment
{
    public int EquipmentId { get; set; }
    public string Type { get; set; }
    public bool IsSelected { get; set; } = false;
}