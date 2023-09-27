using BAL;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace basicCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAddressController: ControllerBase
    {
        private readonly IEmployeeAddressService _employeeAddressService;

        public EmployeeAddressController(IEmployeeAddressService employeeAddressService)
        {
            _employeeAddressService = employeeAddressService;
        }

        [HttpPost]
        [Route("CreateEmployee")]
        public IActionResult addEmployeeAddress(EmpAddress employee)
        {
            var result = _employeeAddressService.addEmployeeAddress(employee);
            return Ok(result);
        }

        [HttpGet]
        [Route("getAllEmployeeAddress")]
        public IList<EmpAddress> GetAll()
        {
            var result = _employeeAddressService.GetAllEmployeeAddress();
            return result;
        }

    }
}
