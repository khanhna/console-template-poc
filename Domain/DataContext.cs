using Domain.Models;

namespace Domain;

public class DataContext
{
    private static Guid HouseProviderId = Guid.NewGuid();
    private static Guid FurnitureProviderId = Guid.NewGuid();
    private static Guid VehicleProviderId = Guid.NewGuid();
    
    private static Provider GetHouseProvider() => new()
    {
        Id = HouseProviderId, Name = "House Provider LTD", Address = "Some big building", State = "NSW",
        PhoneNumber = "0129347935", TaxCode = "OGN0128592", ABN = "13547578", ACN = "47580457"
    };
    private static Provider GetFurnitureProvider() => new()
    {
        Id = FurnitureProviderId, Name = "Furniture Provider LTD", Address = "Some middle building", State = "NSW",
        PhoneNumber = "0129098021", TaxCode = "OGN0222222", ABN = "113331251", ACN = "333111333"
    };
    
    private static Provider GetVehicleProvider() => new()
    {
        Id = VehicleProviderId, Name = "Car Provider LTD", Address = "Some showroom", State = "NSW",
        PhoneNumber = "0129056940", TaxCode = "OGN0222233", ABN = "481523421", ACN = "923560983"
    };

    public static Person GenerateInitialData() => new()
    {
        Id = Guid.NewGuid(), FirstName = "Khanh", LastName = "Nguyen", CitizenCode = "ABC",
        DoB = new DateTime(2020, 1, 1),
        Assets = new List<Asset>
        {
            new()
            {
                Id = Guid.NewGuid(), AssetType = AssetType.House, Name = "My House", Price = 1000000, Quantity = 1,
                CreationDate = new DateTime(2016, 1, 1), Origin = GetHouseProvider()
            },
            new()
            {
                Id = Guid.NewGuid(), AssetType = AssetType.Furniture, Name = "Smart TV", Price = 875, Quantity = 1,
                CreationDate = new DateTime(2016, 1, 2), Origin = GetFurnitureProvider()
            },
            new()
            {
                Id = Guid.NewGuid(), AssetType = AssetType.Vehicles, Name = "Car", Price = 41000, Quantity = 1,
                CreationDate = new DateTime(2018, 4, 23), Origin = GetVehicleProvider()
            }
        }
    };
}