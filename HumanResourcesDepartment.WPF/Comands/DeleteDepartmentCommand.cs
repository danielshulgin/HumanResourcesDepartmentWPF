using HumanResourcesDepartment.Domain.Models;
using HumanResourcesDepartment.EntityFramework.Sercices;
using HumanResourcesDepartment.EntityFramework.Services;
using HumanResourcesDepartment.WPF.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.WPF.Comands
{
    public class DeleteDepartmentCommand : AsyncCommandBase
    {
        private readonly MainWindowViewModel _mainWindowViewModel;

        private readonly DepartmentService _departmentService;

        private readonly PositionService _positionService;


        public DeleteDepartmentCommand(MainWindowViewModel mainWindowViewModel, DepartmentService departmentService, PositionService positionService)
        {
            _mainWindowViewModel = mainWindowViewModel;
            _departmentService = departmentService;
            _positionService = positionService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            if (parameter is Department department)
            {
                var positions = await _positionService.GetAll();
                var departmentPositions = positions.Where(p => p.Department.Id == department.Id);
                foreach (var pos in departmentPositions)
                {
                    await _positionService.Delete(pos.Id);
                }

                await _departmentService.Delete(department.Id);

                _mainWindowViewModel.SelectedEmployees = null;
                _mainWindowViewModel.SelectedPositions = null;
                _mainWindowViewModel.CurrentDepartment = null;
                _mainWindowViewModel.UpdateDepartments();
            }

        }
    }
}
