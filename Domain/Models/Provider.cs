namespace Domain.Models;

public class Provider : Organization
{
    public string ABN { get; set; }
    public string ACN { get; set; }
    public string State { get; set; }
}