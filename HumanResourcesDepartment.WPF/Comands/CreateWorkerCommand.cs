using HumanResourcesDepartment.Domain.Models;
using HumanResourcesDepartment.Domain.Sercices;
using HumanResourcesDepartment.EntityFramework.Sercices;
using HumanResourcesDepartment.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.WPF.Comands
{
    public class CreateWorkerCommand : AsyncCommandBase
    {
        private readonly CreateWorkerViewModel _viewModel;

        private readonly GenericDataService<Worker> _workerService;


        public CreateWorkerCommand(CreateWorkerViewModel createWorkerViewModel, GenericDataService<Worker> workerService)
        {
            _viewModel = createWorkerViewModel;
            _workerService = workerService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var adress = new Address(_viewModel.Country, _viewModel.City, _viewModel.Street, _viewModel.HouseNumber);

            var worker = new Worker(_viewModel.Name, _viewModel.Sex, _viewModel.Tin, _viewModel.Phone, _viewModel.ContactEmail, adress, null);

            await _workerService.Create(worker);
        }
    }
}
