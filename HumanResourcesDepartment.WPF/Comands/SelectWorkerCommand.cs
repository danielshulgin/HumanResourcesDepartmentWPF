using HumanResourcesDepartment.Domain.Models;
using HumanResourcesDepartment.Domain.Sercices;
using HumanResourcesDepartment.WPF.Navigators;
using HumanResourcesDepartment.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HumanResourcesDepartment.WPF.Comands
{
    public class SelectWorkerCommand : AsyncCommandBase
    {
        private readonly MainWindowViewModel _viewModel;

        public SelectWorkerCommand(MainWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            if (parameter is Worker worker)
            {
                _viewModel.SelectWorker(worker);
                _viewModel.UpdateSelectedPage(ViewType.WorkerPage);
            }
        }
    }
}
