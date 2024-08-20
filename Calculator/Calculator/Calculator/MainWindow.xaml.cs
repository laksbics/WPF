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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Calculator.Constants;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        double lastNumber, result;
        SelectedOperator selectedOperator;

        private void btnNumber_Click(object sender, RoutedEventArgs e)
        {
            string selectedValue = ((Button)sender).Content.ToString();

            if(lblResult.Content.ToString() == "0")
            {
                lblResult.Content = selectedValue;
            }
            else
            {
                lblResult.Content = $"{lblResult.Content}{selectedValue}";
            }
        }
         

        private void btnDot_Click(object sender, RoutedEventArgs e)
        {
            if (lblResult.Content.ToString().Contains("."))
            {
                // Do nothing
            }
            else
            {
                lblResult.Content = $"{lblResult.Content}.";
            }

        }

        private void btnAns_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(lblResult.Content.ToString(), out newNumber))
            {
                switch (selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Sustraction:
                        result = SimpleMath.Sustraction(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiply(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Divide(lastNumber, newNumber);
                        break;
                }

                lblResult.Content = result.ToString();
            }
        }
        private void btnAC_Click(object sender, RoutedEventArgs e)
        {
            lblResult.Content = "0";
        }

        private void btnPlusOrMinus_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(lblResult.Content.ToString(), out lastNumber))
            {
                lastNumber = -lastNumber;
                lblResult.Content = lastNumber.ToString();
            }
        }

        private void btnDiv_Click(object sender, RoutedEventArgs e)
        {
            double tempNumber;
            if (double.TryParse(lblResult.Content.ToString(), out tempNumber))
            {
                tempNumber = (tempNumber / 100);
                if (lastNumber != 0)
                    tempNumber *= lastNumber;
                lblResult.Content = tempNumber.ToString();
            }
        }
         
        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(lblResult.Content.ToString(), out lastNumber))
            {
                lblResult.Content = "0";
            }

            if (sender == btnMul)
                selectedOperator = SelectedOperator.Multiplication;
            if (sender == btnDivident)
                selectedOperator = SelectedOperator.Division;
            if (sender == btnAdd)
                selectedOperator = SelectedOperator.Addition;
            if (sender == btnSub)
                selectedOperator = SelectedOperator.Sustraction;
        }

    }
}
