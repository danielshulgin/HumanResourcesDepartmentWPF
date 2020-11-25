using HumanResourcesDepartment.Domain.Sercices;
using HumanResourcesDepartment.EntityFramework;
using HumanResourcesDepartment.EntityFramework.Sercices;
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
    /// Interaction logic for CreateDepartmentWindow.xaml
    /// </summary>
    public partial class CreateDepartmentWindow : Window
    {
        public CreateDepartmentWindow(MainWindowViewModel mainWindowViewModel)
        {
            DepartmentService departmentService = new DepartmentService(new HumanResourcesDbContextFactory("server=(localdb)\\MSSQLLocalDB;Database=HumanResourcesDepartmentDB;Trusted_Connection=True;"));
            this.DataContext = new CreateDepartmentViewModel(departmentService, mainWindowViewModel);
            InitializeComponent();
        }


        public void HandleCloseButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
