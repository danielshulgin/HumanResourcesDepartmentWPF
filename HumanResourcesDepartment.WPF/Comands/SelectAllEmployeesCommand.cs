using HumanResourcesDepartment.Domain.Models;
using HumanResourcesDepartment.Domain.Sercices;
using HumanResourcesDepartment.WPF.ViewModels;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.WPF.Comands
{
    public class SelectAllEmployeesCommand : AsyncCommandBase
    {
        private readonly MainWindowViewModel _viewModel;

        private readonly IDataService<Employee> _employeeService;

        public SelectAllEmployeesCommand(MainWindowViewModel viewModel, IDataService<Employee> employeeService)
        {
            _viewModel = viewModel;
            _employeeService = employeeService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _viewModel.SelectedEmployees = await _employeeService.GetAll();
        }
    }
}
