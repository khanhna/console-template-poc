using Application.Mapping;
using AutoMapper;
using Domain.Models;

namespace Application.Models;

public class AssetDto : IMapping<Asset, AssetDto>
{
    public Guid Id { get; set; }
    public AssetType AssetType { get; set; }
    public string Name { get; set; }
    public decimal NetWorth { get; set; }
    public DateTime CreationDate { get; set; }

    public ProviderDto Origin { get; set; }

    public Action<IMappingExpression<Asset, AssetDto>> ExtraMappingFromConfiguration() => cfg =>
        cfg.ForMember(x => x.NetWorth, opt => opt.MapFrom(src => src.Price * src.Quantity));
}
