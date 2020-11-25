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
    public class DeleteWorkerCommand : AsyncCommandBase
    {
        private readonly MainWindowViewModel _mainWindowViewModel;

        private readonly GenericDataService<Worker> _workerService;


        public DeleteWorkerCommand(MainWindowViewModel mainWindowViewModel, GenericDataService<Worker> workerService)
        {
            _mainWindowViewModel = mainWindowViewModel;
            _workerService = workerService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            if (parameter is Worker worker)
            {
                await _workerService.Delete(worker.Id);
                _mainWindowViewModel.SelectedWorkers = _mainWindowViewModel.SelectedWorkers.Where(w => w.Id != worker.Id);
            }
           
        }
    }
}
