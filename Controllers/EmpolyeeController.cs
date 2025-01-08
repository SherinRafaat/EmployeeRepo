using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using taskinterview.Model;
using taskinterview.Repository;

namespace taskinterview.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmpolyeeRepository _repository;

        public EmployeeController(IEmpolyeeRepository repository)
        {
            _repository = repository;
        }

        
        [HttpGet]
        public IActionResult GetAll([FromQuery] string? filter = null)
        {
            var employees = _repository.GetAll(filter);
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var employee = _repository.GetById(id);
            if (employee == null) return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Empolyee employee)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _repository.Add(employee);
            _repository.Save();
            return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Empolyee updatedEmployee)
        {
            var employee = _repository.GetById(id);
            if (employee == null) return NotFound();

            employee.Name = updatedEmployee.Name;
            employee.Email = updatedEmployee.Email;
            employee.Phone = updatedEmployee.Phone;
            employee.Address = updatedEmployee.Address;

            _repository.Update(employee);
            _repository.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var employee = _repository.GetById(id);
            if (employee == null) return NotFound();

            _repository.Delete(id);
            _repository.Save();

            return NoContent();
        }
    }

}










