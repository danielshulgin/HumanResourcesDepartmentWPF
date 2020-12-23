using HumanResourcesDepartment.EntityFramework;
using HumanResourcesDepartment.EntityFramework.Sercices;
using HumanResourcesDepartment.EntityFramework.Services;
using HumanResourcesDepartment.WPF.ViewModels;
using HumanResourcesDepartment.WPF.Views;
using System.Windows;

namespace HumanResourcesDepartment.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HumanResourcesDbContextFactory _dbContextFactor;

        public MainWindow()
        {
            var dbContextFactory = new HumanResourcesDbContextFactory("server=(localdb)\\MSSQLLocalDB;Database=HumanResourcesDepartmentDB;Trusted_Connection=True;");
            var departmentService = new DepartmentService(dbContextFactory);
            var positionService = new PositionService(dbContextFactory);
            var employeeService = new EmployeeDataService(dbContextFactory);
            _dbContextFactor = dbContextFactory;
            DataContext = new MainWindowViewModel(departmentService, positionService, employeeService);
            InitializeComponent();
        }

        public void HandleCreateDepartemntClick(object sender, RoutedEventArgs e)
        {
            CreateDepartmentWindow subWindow = new CreateDepartmentWindow(DataContext as MainWindowViewModel);
            subWindow.Show();
        }

        public void HandleCreatePositionClick(object sender, RoutedEventArgs e)
        {
            CreatePositionWindow subWindow = new CreatePositionWindow(DataContext as MainWindowViewModel, _dbContextFactor);
            subWindow.Show();
        }

        public void HandleCreateEmployeeClick(object sender, RoutedEventArgs e)
        {
            CreateEmployeeWindow subWindow = new CreateEmployeeWindow(DataContext as MainWindowViewModel);
            subWindow.Show();
        }
    }
}
