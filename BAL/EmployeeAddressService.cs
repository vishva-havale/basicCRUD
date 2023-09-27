using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class EmployeeAddressService : IEmployeeAddressService
    {
        private readonly IEmployeeAddressRepo _employeeAddressRepo;
        public EmployeeAddressService(IEmployeeAddressRepo employeeAddressRepo)
        {
            _employeeAddressRepo = employeeAddressRepo;
        }

        public EmpAddress addEmployeeAddress(EmpAddress empAddress)
        {
            var result = _employeeAddressRepo.addEmployeeAddress(empAddress);
            return result;
        }

        public IList<EmpAddress> GetAllEmployeeAddress()
        {
            var result = _employeeAddressRepo.GetAllEmployeeAddress();
            return result;
        }
    }
}
