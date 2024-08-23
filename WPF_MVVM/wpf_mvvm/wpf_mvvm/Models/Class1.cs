using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_mvvm.Models
{
    public class EmployeeManager
    {
        public static ObservableCollection<Employee> _DataBaseEmployee = new ObservableCollection<Employee>()
        {
            new Employee {Id=1, Name="Employee1",EmployeeId="Emp1", Email="Emp1@employee.com", Phone="(123) 456 789"},
            new Employee {Id=2, Name="Employee2",EmployeeId="Emp2", Email="Emp2@employee.com", Phone="(123) 456 789"},
            new Employee {Id=3, Name="Employee3",EmployeeId="Emp3", Email="Emp3@employee.com", Phone="(123) 456 789"},
            new Employee {Id=4, Name="Employee4",EmployeeId="Emp4", Email="Emp4@employee.com", Phone="(123) 456 789"}
        };

        public static ObservableCollection<Employee> GetEmployees()
        {
            return _DataBaseEmployee;
        }

        public static void AddEmployee(Employee employee)
        {
            _DataBaseEmployee.Add(employee);
        }
    }
}
