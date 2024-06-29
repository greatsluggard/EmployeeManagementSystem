using MassTransit;
using Microsoft.AspNetCore.Mvc;
using StorageService.Domain.Interfaces.Services;
using StorageService.Models;

namespace StorageService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("employees")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("employees/{departmentName}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeesByDepartment(string departmentName)
        {
            var employees = await _employeeService.GetEmployeesByDepartmentAsync(departmentName);
            return Ok(employees);
        }
    }
}