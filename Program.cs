using MultiTenantDotNet9.Infrastructure;
using MultiTenantDotNet9.Logic;
using MultiTenantDotNet9.Middlewares;
using Microsoft.EntityFrameworkCore;

namespace MultiTenantDotNet9
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddScoped<IDbContextConnectionStringProvider, DbContextConnectionStringProvider>();
            builder.Services.AddDbContext<SystemContext>((serviceProvider, options) =>
            {
                var connectionStringProvider = serviceProvider.GetRequiredService<IDbContextConnectionStringProvider>();
                options.UseSqlServer(connectionStringProvider.ConnectionString);
            });

            builder.Services.AddScoped<CategoryLogic>();

            var app = builder.Build();

            app.UseAuthorization();

            app.UseMiddleware<TenantMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}
