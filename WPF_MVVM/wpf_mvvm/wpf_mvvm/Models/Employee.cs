using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_mvvm.Models
{
    public class Employee
    {
        public Employee() { }

        public int Id { get; set; }
        public string Name { get; set; }
        public string EmployeeId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
