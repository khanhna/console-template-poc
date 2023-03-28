using Application.Mapping;
using AutoMapper;
using Domain.Models;

namespace Application.Models;

public class ProviderDto : IMapping<Provider, ProviderDto>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsOffshoreProvider { get; set; }

    public Action<IMappingExpression<Provider, ProviderDto>> ExtraMappingFromConfiguration() => config =>
        config.ForMember(x => x.IsOffshoreProvider, opt => opt.MapFrom(src => src.State != "NSW"));
}