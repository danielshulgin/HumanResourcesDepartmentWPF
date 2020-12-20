using HumanResourcesDepartment.Domain.Models;
using HumanResourcesDepartment.Domain.Sercices;
using HumanResourcesDepartment.WPF.ViewModels;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.WPF.Comands
{
    public class CreateEmployeeCommand : AsyncCommandBase
    {
        private readonly CreateEmployeeViewModel _viewModel;

        private readonly GenericDataService<Employee> _workerService;


        public CreateEmployeeCommand(CreateEmployeeViewModel createWorkerViewModel, GenericDataService<Employee> workerService)
        {
            _viewModel = createWorkerViewModel;
            _workerService = workerService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var adress = new Address(_viewModel.Country, _viewModel.City, _viewModel.Street, _viewModel.HouseNumber);

            var worker = new Employee(_viewModel.Name, _viewModel.Sex, _viewModel.Tin, _viewModel.Phone, _viewModel.ContactEmail, adress, null);

            await _workerService.Create(worker);
        }
    }
}
