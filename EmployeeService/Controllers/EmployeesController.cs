using EmployeeService.Model;
using MassTransit;
using MassTransit.Transports;
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

            var endpoint = await _bus.GetSendEndpoint(new Uri("queue:employee-queue"));

            await endpoint.Send(employee);

            return Ok("Employee was sent");
        }
    }
}
