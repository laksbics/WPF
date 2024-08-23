using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using wpf_mvvm.Commands;
using wpf_mvvm.Models;

namespace wpf_mvvm.ViewModel
{
    public class AddEmployeeViewModel
    {

        public AddEmployeeViewModel()
        {
            AddEmployeeCommand = new RelayCommand(AddEmployee, CanAddEmployee);
        }

        public ICommand AddEmployeeCommand { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmployeeId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }


        private bool CanAddEmployee(object obj)
        {
           return true;
        }

        private void AddEmployee(object obj)
        {
            EmployeeManager.AddEmployee(new Employee { Name = Name, EmployeeId = EmployeeId, Email = Email, Phone = Phone });
        }
    }
}
