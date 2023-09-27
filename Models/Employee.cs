using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Employee
    {
        public int emp_id { get; set; }
        public string? name { get; set; }
        public string? salary { get; set; }
        public string? mobile { get; set; }
        public string? email { get; set; }
        public string? Address { get; set; }
        public string? State { get; set; }
        public string? District { get; set; }
        public string? City { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Boolean IsActive { get; set; }

    }
}
