namespace SolbegTask3.Models.Workplace;

public class Workplace
{
    public int Id { get; set; }
    public int Floor { get; set; }
    public int Room { get; set; }
    public int Table { get; set; }
    public List<string> Equipments { get; set; }
}