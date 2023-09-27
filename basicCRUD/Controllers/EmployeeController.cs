using BAL;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace basicCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        [Route("CreateEmployee")]
        public IActionResult CreateEmployee(Employee employee)
        {
            var result = _employeeService.CreateEmployee(employee);
            return Ok(result);
        }
        [HttpPut]
        [Route("UpdateEmployee")]
        public IActionResult UpdateEmployee([FromBody] Employee employee)
        {
            var result = _employeeService.UpdateEmployee(employee);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetEmployee")]
        public IList<Employee> GetAll()
        {
            var result = _employeeService.GetAll();
            return result;
        }

        [HttpGet]
        [Route("GetEmployee/{id}")]
        public Employee GetById(int id)
        {
            var result = _employeeService.GetById(id);
            return result;
        }

        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public bool DeleteEmployee(int id)
        {
            var result = _employeeService.DeleteEmployee(id);
            return result;
        }
    }
}
