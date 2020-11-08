using HumanResourcesDepartment.Domain.Models;
using HumanResourcesDepartment.Domain.Sercices;
using HumanResourcesDepartment.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.WPF.Comands
{
    public class SelectDepartmentCommand : AsyncCommandBase
    {
        private readonly MainWindowViewModel _viewModel;

        private readonly DepartmentService _departmentService;


        public SelectDepartmentCommand(MainWindowViewModel viewModel, DepartmentService departmentService)
        {
            _viewModel = viewModel;
            _departmentService = departmentService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            if (parameter is Department)
            {
                var department = (Department)parameter;
                _viewModel.SelectDepartment(department);
            }
        }
    }
}
