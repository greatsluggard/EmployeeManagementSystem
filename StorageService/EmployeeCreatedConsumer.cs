using Contracts;
using MassTransit;
using StorageService.Domain.Interfaces.Services;
using StorageService.Models;

namespace StorageService
{
    public class EmployeeCreatedConsumer : IConsumer<EmployeeCreatedEvent>
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeCreatedConsumer(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task Consume(ConsumeContext<EmployeeCreatedEvent> context)
        {
            var department = new Department
            {
                DepartmentName = context.Message.DepartmentName
            };

            var employee = new Employee
            {
                Name = context.Message.Name,
                LastName = context.Message.LastName,
                Department = department
            };

            await _employeeService.HandleEmployeeAsync(employee);
        }
    }
}