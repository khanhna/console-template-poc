namespace Domain.Models;

public class Asset
{
    public Guid Id { get; set; }
    public AssetType AssetType { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public DateTime CreationDate { get; set; }

    public Provider Origin { get; set; }
}

public enum AssetType
{
    CashAndEquivalent,
    Vehicles,
    Furniture,
    House,
    Investments
}