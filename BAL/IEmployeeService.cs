using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public interface IEmployeeService
    {
        public Employee CreateEmployee(Employee employee);
        public Employee UpdateEmployee(Employee employee);

        public IList<Employee> GetAll();
        public bool DeleteEmployee(int id);
        public Employee GetById(int id);
    }
}
