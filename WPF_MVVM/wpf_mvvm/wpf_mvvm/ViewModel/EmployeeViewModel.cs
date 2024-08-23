using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using wpf_mvvm.Commands;
using wpf_mvvm.Models;
using wpf_mvvm.Views;

namespace wpf_mvvm.ViewModel
{
    public class EmployeeViewModel
    {
        public ObservableCollection<Employee> Employees { get; set; }

        public ICommand ShowWindowCommand {  get; set; }    

        public EmployeeViewModel()
        {
            Employees = EmployeeManager.GetEmployees();
            ShowWindowCommand = new RelayCommand(ShowWindow, CanShowWindow);
        }

        public bool CanShowWindow(object obj)
        {
            return true;
        }

        public void ShowWindow(object obj)
        {
            AddEmployee addEmployee = new AddEmployee();
            addEmployee.Owner = obj as Window;
            addEmployee.ShowDialog();
        }
    }
}
