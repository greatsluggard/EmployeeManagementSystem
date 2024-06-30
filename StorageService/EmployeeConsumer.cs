using MassTransit;
using StorageService.Domain.Interfaces.Services;
using StorageService.Models;

namespace StorageService
{
    public class EmployeeConsumer : IConsumer<Employee>
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeConsumer(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task Consume(ConsumeContext<Employee> context)
        {
            try
            {
                var employee = context.Message;
                await _employeeService.HandleEmployeeAsync(employee);
            }
            catch (Exception ex)
            {
                throw; 
            }
        }
    }
}