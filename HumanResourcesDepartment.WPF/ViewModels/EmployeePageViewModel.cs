using HumanResourcesDepartment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResourcesDepartment.WPF.ViewModels
{
    public class EmployeePageViewModel : ViewModelBase
    {
        private Employee _employee;

        public Employee Employee
        {
            get
            {
                return _employee;
            }
            set
            {
                _employee = value;
                OnPropertyChanged(nameof(Employee));
            }
        }
    }
}
