using HumanResourcesDepartment.Domain.Models;
using HumanResourcesDepartment.EntityFramework.Sercices;
using HumanResourcesDepartment.EntityFramework.Services;
using HumanResourcesDepartment.WPF.ViewModels;
using HumanResourcesDepartment.WPF.Views;
using System.Threading.Tasks;
using System.Windows;

namespace HumanResourcesDepartment.WPF.Comands
{
    public class LoginCommand : AsyncCommandBase
    {
        private readonly LoginViewModel _viewModel;

        private readonly Window _window;

        private readonly EmployeeDataService _employeeDataService;


        public LoginCommand(EmployeeDataService employeeDataService, LoginViewModel viewModel, Window window)
        {
            _viewModel = viewModel;
            _employeeDataService = employeeDataService;
            _window = window;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var employee = await _employeeDataService.GetByEmail(_viewModel.Email);


            if (employee == null)
            {
                MessageBox.Show("Incorrect Email");
                return;
            }
            if (employee.Password != _viewModel.Password)
            {
                MessageBox.Show("Incorrect Password");
                return;
            }
            if (employee.AccessRights == AccessRights.Full)
            {

                Window window = new MainWindow();
                window.Show();
                _window.Hide();
                return;
            }
            else if (employee.AccessRights == AccessRights.Limited)
            {
                var window = new LimitedEmployeeWindow(employee);
                window.Show();
                _window.Hide();
                return;
            }
        }
    }
}
