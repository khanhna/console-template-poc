namespace Domain.Models;

public class Organization
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string TaxCode { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
}