using HumanResourcesDepartment.Domain.Models;
using HumanResourcesDepartment.Domain.Sercices;
using HumanResourcesDepartment.EntityFramework.Sercices;
using HumanResourcesDepartment.EntityFramework.Services;
using HumanResourcesDepartment.WPF.ViewModels;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.WPF.Comands
{
    public class CreatePositionCommand : AsyncCommandBase
    {
        private readonly CreatePositionViewModel _viewModel;

        private readonly MainWindowViewModel _mainWindowViewModel;

        private readonly PositionService _positionService;

        private readonly DepartmentService _departmentService;

        private readonly EmployeeDataService _workerService;

        private readonly GenericDataService<Profession> _profesionService;


        public CreatePositionCommand(CreatePositionViewModel viewModel, MainWindowViewModel mainWindowViewModel, PositionService positionService, DepartmentService departmentService, EmployeeDataService workerService, GenericDataService<Profession> professionService)
        {
            _viewModel = viewModel;
            _mainWindowViewModel = mainWindowViewModel;
            _positionService = positionService;
            _departmentService = departmentService;
            _workerService = workerService;
            _profesionService = professionService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var employee = _viewModel.Employee;
            var professsion = _viewModel.Profession;
            var department = _viewModel.Department;
            var position = new Position(_viewModel.Name, employee, professsion, department, _viewModel.Salary);

            await _positionService.Create(position);

            _mainWindowViewModel.UpdateDepartments();
        }
    }
}
