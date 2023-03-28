using Application.Mapping;
using AutoMapper;
using Domain.Models;

namespace Application.Models;

public class PersonDto : IMapping<Person, PersonDto>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime DoB { get; set; }
    public string CitizenCode { get; set; }

    public ICollection<AssetDto> Assets { get; set; }

    public Action<IMappingExpression<Person, PersonDto>> ExtraMappingFromConfiguration() => cfg =>
        cfg.ForMember(x => x.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
}