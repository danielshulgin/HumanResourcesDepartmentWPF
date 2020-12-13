using HumanResourcesDepartment.Domain.Models;
using HumanResourcesDepartment.Domain.Sercices;
using HumanResourcesDepartment.EntityFramework.Sercices;
using HumanResourcesDepartment.EntityFramework.Services;
using HumanResourcesDepartment.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.WPF.Comands
{
    public class DeletePositionCommand : AsyncCommandBase
    {
        private readonly MainWindowViewModel _mainWindowViewModel;

        private readonly PositionService _positionService;


        public DeletePositionCommand(MainWindowViewModel mainWindowViewModel, PositionService positionService)
        {
            _mainWindowViewModel = mainWindowViewModel;
            _positionService = positionService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            if (parameter is Position position)
            {
                await _positionService.Delete(position.Id);
                _mainWindowViewModel.SelectedPositions = _mainWindowViewModel.SelectedPositions.Where(w => w.Id != position.Id);
                _mainWindowViewModel.SelectedEmployees = _mainWindowViewModel.SelectedPositions.Select(p => p.Employee);
            }
           
        }
    }
}
