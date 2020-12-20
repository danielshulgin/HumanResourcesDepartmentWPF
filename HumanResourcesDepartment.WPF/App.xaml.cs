using HumanResourcesDepartment.EntityFramework;
using HumanResourcesDepartment.EntityFramework.Sercices;
using HumanResourcesDepartment.EntityFramework.Services;
using HumanResourcesDepartment.WPF.ViewModels;
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
            var dbContextFactory = new HumanResourcesDbContextFactory("server=(localdb)\\MSSQLLocalDB;Database=HumanResourcesDepartmentDB;Trusted_Connection=True;");
            var departmentService = new DepartmentService(dbContextFactory);
            var positionService = new PositionService(dbContextFactory);
            var employeeService = new EmployeeDataService(dbContextFactory);

            Window window = new MainWindow(dbContextFactory)
            {
                DataContext = new MainWindowViewModel(departmentService, positionService, employeeService)
            };
            window.Show();

            base.OnStartup(e);
        }
    }
}
