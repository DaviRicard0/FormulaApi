namespace FormulaApi.Models;

public class Driver
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int DriverNumber { get; set; }
    public string Team { get; set; } = string.Empty;
}
