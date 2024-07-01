using Contracts;
using EmployeeService.Model;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public EmployeesController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }

            await _publishEndpoint.Publish(new EmployeeCreatedEvent
            {
                Name = employee.Name,
                LastName = employee.LastName,
                DepartmentName = employee.DepartmentName
            });

            return Ok("The employee was sent to the queue successfully.");
        }
    }
}