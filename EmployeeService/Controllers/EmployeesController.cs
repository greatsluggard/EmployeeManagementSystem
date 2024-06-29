using EmployeeService.Model;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IBus _bus;

        public EmployeesController(IBus bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }

            await _bus.Publish(employee);
            return Ok("Employee was sent.");
        }
    }
}
