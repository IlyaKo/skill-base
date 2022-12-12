using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Database.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        AddMediatRToAsseblies(services);
        AddAutoMapperToAsseblies(services);
        AddValidationToAsseblies(services);

        return services;
    }

    private static void AddMediatRToAsseblies(IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
    }

    private static void AddAutoMapperToAsseblies(IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }

    private static void AddValidationToAsseblies(IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), lifetime: ServiceLifetime.Singleton);
    }
}