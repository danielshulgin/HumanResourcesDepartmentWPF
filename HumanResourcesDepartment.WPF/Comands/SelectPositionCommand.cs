using HumanResourcesDepartment.Domain.Models;
using HumanResourcesDepartment.WPF.Navigators;
using HumanResourcesDepartment.WPF.ViewModels;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.WPF.Comands
{
    public class SelectPositionCommand : AsyncCommandBase
    {
        private readonly MainWindowViewModel _viewModel;

        public SelectPositionCommand(MainWindowViewModel viewModel, EntityFramework.Services.PositionService positionService)
        {
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            if (parameter is Position position)
            {
                _viewModel.SelectPosition(position);
                _viewModel.UpdateSelectedPage(ViewType.PositionPage);
            }
        }
    }
}
