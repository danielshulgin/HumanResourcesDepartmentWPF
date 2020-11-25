using HumanResourcesDepartment.Domain.Models;
using HumanResourcesDepartment.Domain.Sercices;
using HumanResourcesDepartment.WPF.Navigators;
using HumanResourcesDepartment.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.WPF.Comands
{
    public class SelectAllWorkersCommand : AsyncCommandBase
    {
        private readonly MainWindowViewModel _viewModel;

        private readonly GenericDataService<Worker> _workerService;

        public SelectAllWorkersCommand(MainWindowViewModel viewModel, GenericDataService<Worker> workerService)
        {
            _viewModel = viewModel;
            _workerService = workerService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _viewModel.SelectedWorkers = await _workerService.GetAll();
        }
    }
}
