using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public interface IEmployeeAddressService
    {
        public EmpAddress addEmployeeAddress(EmpAddress empAddress);
        public IList<EmpAddress> GetAllEmployeeAddress();
    }
}
