namespace Domain.Models;

public class Person
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DoB { get; set; }
    public string CitizenCode { get; set; }

    public ICollection<Asset> Assets { get; set; }
}