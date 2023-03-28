using System.Reflection;
using AutoMapper;

namespace Application.Mapping;

public interface IMapping<TSource, TDest>
{
    Action<IMappingExpression<TSource, TDest>> ExtraMappingFromConfiguration() => null;
    Action<IMappingExpression<TDest, TSource>> ExtraMappingToConfiguration() => null;
    void MappingFrom(Profile profile)
    {
        var extraMappingConfig = ExtraMappingFromConfiguration();
        if(extraMappingConfig == null)
            profile.CreateMap<TSource, TDest>();
        else
            extraMappingConfig.Invoke(profile.CreateMap<TSource, TDest>());
    }
    
    /// <summary>
    /// Personally, I don't see Reverse mapping is a good way if we wish reverse mapping direction.
    ///     There's no logic to guarantee the custom mapping if any reverse correctly.
    /// We can consider whether to have this or not.
    /// </summary>
    void MappingTo(Profile profile)
    {
        var extraMappingConfig = ExtraMappingToConfiguration();
        if (extraMappingConfig == null)
            profile.CreateMap<TDest, TSource>();
        else
            extraMappingConfig.Invoke(profile.CreateMap<TDest, TSource>());
    }
}

public interface IMultipleSourceMapping
{
    void Mapping(Profile profile);
}

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        SingleDestinationMappingWithMultipleSources();
    }
    
    private void ApplyMappingsFromAssembly(Assembly assembly)
    {
        var standardPairMappingTypes = assembly.GetExportedTypes()
            .Where(t => t.GetInterfaces().Any(i =>
                i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapping<,>)));

        foreach (var type in standardPairMappingTypes)
        {
            var mapInterface = type.GetInterfaces().First(x => x.Name.StartsWith(nameof(IMapping<object, object>)));
            var mapType = typeof(IMapping<,>).MakeGenericType(mapInterface.GetGenericArguments());
            var instance = Activator.CreateInstance(type);
            
            mapType.GetMethod(nameof(IMapping<object, object>.MappingFrom))?.Invoke(instance, new object[] { this });
            mapType.GetMethod(nameof(IMapping<object, object>.MappingTo))?.Invoke(instance, new object[] { this });
        }
        
        var multipleSourceMappingTypes = assembly.GetExportedTypes()
            .Where(t => t.GetInterfaces().Any(i =>
                i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMultipleSourceMapping)));

        foreach (var type in multipleSourceMappingTypes)
        {
            var instance = Activator.CreateInstance(type);
            var methodInfo = type.GetMethod(nameof(IMultipleSourceMapping.Mapping));
            methodInfo?.Invoke(instance, new object[] { this });
        }
    }

    /// <summary>
    /// Each mapping pair are unique and shouldn't be re-use
    /// Mapping should always implement from highest layer to lowest (source type shouldn't care what destination type
    ///     it is going to be mapped)
    /// In case multiple sources wish to map to a single destination type, define them here.
    ///     This case should not happen frequently by design, either re-use destination models
    ///     or create other destination models for the specific job if needed.
    /// Or in my PoV, we make use of IMultipleSourceMapping interface above is better.
    /// </summary>
    void SingleDestinationMappingWithMultipleSources()
    {
    }
}