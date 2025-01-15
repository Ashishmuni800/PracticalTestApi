using Application.DTO;
using Application.ServiceInterface;
using Domain.Model;
using Domain.RepositoryInterface;
using Microsoft.AspNetCore.Mvc;

namespace PracticalTestApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmployeeController : Controller
    {
        private readonly IServiceInfra _employee;
        public EmployeeController(IServiceInfra employee)
        {
            _employee = employee;
        }
        // Display the employee form and data
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = await _employee.EmployeeService.GetEmployeeAsync().ConfigureAwait(false);
            return Ok(employees);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            if (Id == null) { return BadRequest("Input invailid or null"); }
            else
            {
                var employees = await _employee.EmployeeService.GetEmployeeByIdAsync(Id).ConfigureAwait(false);
                return Ok(employees);
            }
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteEmployee(int Id)
        {
            await _employee.EmployeeService.DeletedAsync(Id).ConfigureAwait(false);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeDTO model)
        {
            if (ModelState.IsValid)
            {
                var data=await _employee.EmployeeService.AddEmployeeAsync(model).ConfigureAwait(false);
                // Redirect to the index to see the updated list
                return Ok(data);
            }
            return BadRequest("invalid input");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditEmployee(int id,[FromBody] EmployeeDTO model)
        {
            if (ModelState.IsValid)
            {
                var data = await _employee.EmployeeService.EditEmployeeAsync(model).ConfigureAwait(false);
                // Redirect to the index to see the updated list
                return Ok(data);
            }
            return BadRequest("invalid input");
        }
    }
}
  