using Microsoft.EntityFrameworkCore;
using StorageService.Domain.Interfaces.Repository;
using StorageService.Domain.Interfaces.Services;
using StorageService.Models;

namespace StorageService.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IBaseRepository<Employee> _employeeRepository;
        private readonly IBaseRepository<Department> _departmentRepository;

        public EmployeeService(IBaseRepository<Employee> employeeRepository,
                                      IBaseRepository<Department> departmentRepository)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task HandleEmployeeAsync(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee), "Employee cannot be null.");
            }

            try
            {
                Department existingDepartment = await _departmentRepository.GetAll().FirstOrDefaultAsync(d => d.DepartmentName == employee.Department.DepartmentName);

                if (existingDepartment == null)
                {
                    existingDepartment = new Department
                    {
                        DepartmentName = employee.Department.DepartmentName
                    };
                    await _departmentRepository.CreateAsync(existingDepartment);
                    await _departmentRepository.SaveChangesAsync();
                }

                Employee newEmployee = new Employee
                {
                    Name = employee.Name,
                    LastName = employee.LastName,
                    Department = existingDepartment
                };

                await _employeeRepository.CreateAsync(newEmployee);
                await _employeeRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error processing employee message.", ex);
            }
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAll().ToListAsync();
        }

        public async Task<List<Employee>> GetEmployeesByDepartmentAsync(string departmentName)
        {
            if (string.IsNullOrEmpty(departmentName))
            {
                throw new ArgumentException("Department name cannot be null or empty.", nameof(departmentName));
            }

            Department department = await _departmentRepository.GetAll().FirstOrDefaultAsync(d => d.DepartmentName == departmentName);

            if (department == null)
            {
                throw new ArgumentException($"Department '{departmentName}' not found.");
            }

            List<Employee> employees = await _employeeRepository.GetAll()
                .Where(e => e.DepartmentId == department.DepartmentId)
                .ToListAsync();

            return employees;
        }
    }
}