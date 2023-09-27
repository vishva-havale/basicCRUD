using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepo _employeeRepo;

        public EmployeeService(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;  
        }

        public Employee CreateEmployee(Employee employee)
        {
            var result=_employeeRepo.CreateEmployee(employee);
            return result;
        }

        public bool DeleteEmployee(int id)
        {
            var result = _employeeRepo.DeleteEmployee(id);
            return result;
        }

        public IList<Employee> GetAll()
        {
            var result = _employeeRepo.GetAll();
            return result;
        }

        public Employee GetById(int id)
        {
            var result = _employeeRepo.GetById(id);
            return result;
        }

        public Employee UpdateEmployee( Employee employee)
        {
            var result = _employeeRepo.UpdateEmployee(employee);
            return result;
        }
    }
}
