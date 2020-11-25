using HumanResourcesDepartment.Domain.Models;
using HumanResourcesDepartment.EntityFramework.Sercices;
using HumanResourcesDepartment.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.WPF.Comands
{
    public class CreateDepartmentCommand : AsyncCommandBase
    {
        private readonly CreateDepartmentViewModel _viewModel;

        private readonly MainWindowViewModel _mainWindowViewModel;

        private readonly DepartmentService _departmentService;


        public CreateDepartmentCommand(CreateDepartmentViewModel viewModel, MainWindowViewModel mainWindowViewModel,  DepartmentService departmentService)
        {
            _viewModel = viewModel;
            _mainWindowViewModel = mainWindowViewModel;
            _departmentService = departmentService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var adress = new Address(_viewModel.Country, _viewModel.City, _viewModel.Street, _viewModel.HouseNumber);

            var department = new Department(_viewModel.Name, _viewModel.Description, _viewModel.ContactPhone, _viewModel.ContactEmail, adress);

            await _departmentService.Create(department);

            _mainWindowViewModel.UpdateDepartments();
        }
    }
}
