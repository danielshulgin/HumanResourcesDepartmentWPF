using HumanResourcesDepartment.Domain.Models;
using HumanResourcesDepartment.EntityFramework.Sercices;
using HumanResourcesDepartment.EntityFramework.Services;
using HumanResourcesDepartment.WPF.Comands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace HumanResourcesDepartment.WPF.ViewModels
{
    public class DepartmentPageViewModel : ViewModelBase
    {
        private Department _department;

        public Department Department
        {
            get
            {
                return _department;
            }
            set
            {
                _department = value;
                OnPropertyChanged(nameof(Department));
            }
        }

        public ICommand DeleteDepartmentCommand { get; set; }
        

        public DepartmentPageViewModel(MainWindowViewModel mainWindowViewModel, DepartmentService departmentService, PositionService positionService)
        {
            DeleteDepartmentCommand = new DeleteDepartmentCommand(mainWindowViewModel, departmentService, positionService);
        }
    }
}
