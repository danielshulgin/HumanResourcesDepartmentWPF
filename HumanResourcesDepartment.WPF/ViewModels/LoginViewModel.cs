using GalaSoft.MvvmLight.Command;
using HumanResourcesDepartment.Domain.Models;
using HumanResourcesDepartment.Domain.Sercices;
using HumanResourcesDepartment.EntityFramework;
using HumanResourcesDepartment.EntityFramework.Sercices;
using HumanResourcesDepartment.EntityFramework.Services;
using HumanResourcesDepartment.WPF.Comands;
using HumanResourcesDepartment.WPF.Views;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HumanResourcesDepartment.WPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private EmployeeDataService _employeeDataService;

        private Window _window;

        private string _email;

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string _password;

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand LoginCommand { get; private set; }


        public LoginViewModel(EmployeeDataService employeeDataService, Window window)
        {
            _employeeDataService = employeeDataService;
            LoginCommand = new LoginCommand(employeeDataService, this, window);
            _window = window;
        }
    }
}
