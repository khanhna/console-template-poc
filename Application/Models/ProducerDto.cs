namespace Application.Models;

public class ProducerDto
{
    public ProducerDto(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; }

    public string Name { get; }
}