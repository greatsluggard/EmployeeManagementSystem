using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StorageService.DAL.Repositories;
using StorageService.Domain.Interfaces.Repository;
using StorageService.Models;

namespace StorageService.DAL.DependencyInjection
{
    public static class DependencyInjeciton
    {
        public static void AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("PostgresSQL");

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            services.InitRepositories();
        }

        private static void InitRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<Employee>, BaseRepository<Employee>>();
            services.AddScoped<IBaseRepository<Department>, BaseRepository<Department>>();
        }
    }
}