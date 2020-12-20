using HumanResourcesDepartment.Domain.Models;
using HumanResourcesDepartment.Domain.Sercices;
using HumanResourcesDepartment.EntityFramework;
using HumanResourcesDepartment.EntityFramework.Sercices;
using HumanResourcesDepartment.EntityFramework.Services;
using HumanResourcesDepartment.WPF.ViewModels;
using System.Windows;

namespace HumanResourcesDepartment.WPF.Views
{
    /// <summary>
    /// Interaction logic for CreatePositionWindow.xaml
    /// </summary>
    public partial class CreatePositionWindow : Window
    {
        public CreatePositionWindow(MainWindowViewModel mainWindowViewModel, HumanResourcesDbContextFactory dbContextFactory)
        {
            var positionService = new PositionService(dbContextFactory);
            var departmentService = new DepartmentService(dbContextFactory);
            var workerService = new EmployeeDataService(dbContextFactory);
            var professionService = new GenericDataService<Profession>(dbContextFactory);
            this.DataContext = new CreatePositionViewModel(positionService, departmentService, workerService, professionService, mainWindowViewModel);
            InitializeComponent();
        }


        public void HandleCloseButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
