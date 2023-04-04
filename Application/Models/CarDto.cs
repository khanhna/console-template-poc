namespace Application.Models;

public class CarDto
{
    public string Name { get; set; } = string.Empty;

    public int NumberOfSeats { get; set; }

    public CarColorDto Color { get; set; }

    public ProducerDto? Producer { get; set; }

    public List<TireDto>? Tires { get; set; }

    public int NumberOfTires { get; set; }

    public int NumberOfTiresMultiplyByFour { get; set; }
}