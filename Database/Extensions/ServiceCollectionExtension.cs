using Database.Repositories.KnowledgeLevels;
using Database.Repositories.SkillAreas;
using Database.Repositories.Skills;
using Database.Repositories.Subdivisions;
using Database.Repositories.Surveys;
using Database.Repositories.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Database.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDbRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("AppDb");
        services.AddDbContext<AppContext>(builder => 
            builder
                .UseNpgsql(connectionString)
                .EnableSensitiveDataLogging(), 
            contextLifetime: ServiceLifetime.Transient);

        services.AddTransient<IKnowledgeLevelRepository, KnowledgeLevelRepository>();
        services.AddTransient<ISkillRepository, SkillRepository>();
        services.AddTransient<ISkillAreaRepository, SkillAreaRepository>();
        services.AddTransient<ISubdivisionRepository, SubdivisionRepository>();
        services.AddTransient<ISurveyRepository, SurveyRepository>();
        services.AddTransient<IUserRepository, UserRepository>();

        return services;
    }
}

