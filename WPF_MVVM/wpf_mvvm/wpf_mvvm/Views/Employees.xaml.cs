using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using wpf_mvvm.Models;
using wpf_mvvm.ViewModel;

namespace wpf_mvvm.Views
{
    /// <summary>
    /// Interaction logic for Employees.xaml
    /// </summary>
    public partial class Employees : Window
    {
        public Employees()
        {
            InitializeComponent();
            EmployeeViewModel viewModel = new EmployeeViewModel();
            this.DataContext = viewModel;
        }

        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            EmployeeList.Items.Filter = FilterMethod;
        }

        private bool FilterMethod(object obj)
        {
            Employee emp = obj as Employee;
            return emp.Name.Contains(FilterTextBox.Text, StringComparison.OrdinalIgnoreCase) || emp.EmployeeId.Contains(FilterTextBox.Text, StringComparison.OrdinalIgnoreCase) || emp.Phone.Contains(FilterTextBox.Text, StringComparison.OrdinalIgnoreCase) || emp.Email.Contains(FilterTextBox.Text, StringComparison.OrdinalIgnoreCase);
        }
    }
}
