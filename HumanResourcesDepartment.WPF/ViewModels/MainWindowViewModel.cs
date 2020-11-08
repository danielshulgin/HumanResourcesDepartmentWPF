using HumanResourcesDepartment.Domain.Models;
using HumanResourcesDepartment.Domain.Sercices;
using HumanResourcesDepartment.WPF.Comands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Input;

namespace HumanResourcesDepartment.WPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private DepartmentService _departmentService;


        private IEnumerable<Department> _departments;

        public IEnumerable<Department> Departments
        {
            get
            {
                return _departments;
            }
            private set
            {
                _departments = value;
                OnPropertyChanged(nameof(Departments));
            }
        }

        public IEnumerable<Worker> CurrentDepartmentWorkers { get; private set; }

        private Department _currentDepartment;

        public Department CurrentDepartment
        {
            get
            {
                return _currentDepartment;
            }
            private set
            {
                _currentDepartment = value;
                CurrentDepartmentWorkers = CurrentDepartment.Positions.Select(position => position.Worker);
                OnPropertyChanged(nameof(CurrentDepartment));
                OnPropertyChanged(nameof(CurrentDepartmentWorkers));
            }
        }

        public ICommand SelectDepartmetnCommand { get; }


        public MainWindowViewModel(DepartmentService departmentService)
        {
            _departmentService = departmentService;
            SelectDepartmetnCommand = new SelectDepartmentCommand(this, departmentService);

            departmentService.GetAll().ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    Departments = task.Result;
                    CurrentDepartment = departmentService.GetAll().Result.First();
                }
            });
        }

        public void SelectDepartment(Department department)
        {
            CurrentDepartment = department;
        }
    }
}
