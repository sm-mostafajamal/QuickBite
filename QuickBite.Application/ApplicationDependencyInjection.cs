using FluentValidation;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using QuickBite.Application.Common.Behaviour;

namespace QuickBite.Application;


public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        AddMapster(services);
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidatorBehaviour<,>));
        services.AddValidatorsFromAssembly(typeof(ApplicationDependencyInjection).Assembly);
        services.AddMediatR(typeof(ApplicationDependencyInjection).Assembly);

        return services;
    }
    
    private static void AddMapster(IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(typeof(ApplicationDependencyInjection).Assembly);

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
    }
}
