using HumanResourcesDepartment.Domain.Models;
using HumanResourcesDepartment.EntityFramework.Services;
using HumanResourcesDepartment.WPF.Navigators;
using HumanResourcesDepartment.WPF.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.WPF.Comands
{
    public class SelectDepartmentCommand : AsyncCommandBase
    {
        private readonly MainWindowViewModel _viewModel;

        private readonly PositionService _positionService;


        public SelectDepartmentCommand(MainWindowViewModel viewModel, PositionService positionService)
        {
            _viewModel = viewModel;
            _positionService = positionService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            if (parameter is Department department)
            {
                _viewModel.SelectDepartment(department);
                _viewModel.UpdateSelectedPage(ViewType.DepartmentPage);
                var positions = await _positionService.GetAll();
                _viewModel.SelectedPositions = positions.Where(p => p.Department.Id == department.Id);
                _viewModel.SelectedEmployees =
                    positions.Where(p => p.Department.Id == department.Id)
                             .Select(p => p.Employee)
                             .Where(emp => emp != null)
                             .Distinct();
            }
        }
    }
}
