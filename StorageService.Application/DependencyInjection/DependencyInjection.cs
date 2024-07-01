using Microsoft.Extensions.DependencyInjection;
using StorageService.Application.Services;
using StorageService.Domain.Interfaces.Services;

namespace StorageService.Application.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.InitServices();
        }

        private static void InitServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
        }
    }
}