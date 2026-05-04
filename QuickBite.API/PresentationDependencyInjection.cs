using Mapster;
using MapsterMapper;

namespace QuickBite.API;


public static class PresentationDependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        AddMapper(services);

        return services;
    }

    private static void AddMapper(IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(typeof(PresentationDependencyInjection).Assembly);
        services.AddSingleton(config);

        services.AddScoped<IMapper, ServiceMapper>();
    }
}