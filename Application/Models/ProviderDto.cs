using Application.Mapping;
using AutoMapper;
using Domain.Models;

namespace Application.Models;

public class ProviderDto : IMultipleSourceMapping
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsOffshoreProvider { get; set; }

    /// <summary>
    /// Mapping multiple sources here. Instead of using SingleDestinationMappingWithMultipleSources
    /// in MappingProfile.
    /// </summary>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Provider, ProviderDto>()
            .ForMember(x => x.IsOffshoreProvider, opt => opt.MapFrom(src => src.State != "NSW"));
        profile.CreateMap<Organization, ProviderDto>();
    }
}