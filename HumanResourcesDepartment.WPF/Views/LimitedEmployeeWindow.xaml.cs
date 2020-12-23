using HumanResourcesDepartment.Domain.Models;
using HumanResourcesDepartment.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HumanResourcesDepartment.WPF.Views
{
    /// <summary>
    /// Interaction logic for LimitedEmployeeWindow.xaml
    /// </summary>
    public partial class LimitedEmployeeWindow : Window
    {
        public LimitedEmployeeWindow(Employee employee)
        {
            InitializeComponent();

            DataContext = new EmployeePageViewModel() {Employee = employee };
        }
    }
}
