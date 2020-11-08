using HumanResourcesDepartment.Domain.Models;
using HumanResourcesDepartment.Domain.Sercices;
using HumanResourcesDepartment.EntityFramework;
using HumanResourcesDepartment.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HumanResourcesDepartment.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            DepartmentService departmentService = new DepartmentService(new HumanResourcesDbContextFactory("server=(localdb)\\MSSQLLocalDB;Database=HumanResourcesDepartmentDB;Trusted_Connection=True;"));

            Window window = new MainWindow();

            window.DataContext = new MainWindowViewModel(departmentService);
            window.Show();

            base.OnStartup(e);
        }
    }
}
