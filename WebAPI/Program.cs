using Database;
using Database.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace WebAPI;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        AddServices(builder.Services, builder.Configuration);

        var app = builder.Build();
        await UpdateDatabase(app);
        Configure(app);
        app.Run();
    }

    private static void AddServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbRepositories(configuration);
        services.AddApplicationServices();
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    private static void Configure(WebApplication application)
    {
        if (application.Environment.IsDevelopment())
        {
            application.UseSwagger();
            application.UseSwaggerUI();
        }

        application.UseHttpsRedirection();
        application.UseAuthorization();
        application.MapControllers();
    }

    private static async Task UpdateDatabase(WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<AppContext>();
            await db.Database.MigrateAsync();
        }
    }
}