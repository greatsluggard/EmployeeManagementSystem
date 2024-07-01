using StorageService.Models;

namespace StorageService.Domain.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task HandleEmployeeAsync(Employee employee);
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<List<Employee>> GetEmployeesByDepartmentAsync(string departmentName);
    }
}