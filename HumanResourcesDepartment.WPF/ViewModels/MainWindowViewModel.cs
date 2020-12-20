using HumanResourcesDepartment.Domain.Models;
using HumanResourcesDepartment.Domain.Sercices;
using HumanResourcesDepartment.EntityFramework.Sercices;
using HumanResourcesDepartment.EntityFramework.Services;
using HumanResourcesDepartment.WPF.Comands;
using HumanResourcesDepartment.WPF.Navigators;
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

        private PositionService _positionService;

        private DepartmentPageViewModel _departmentPageViewModel;

        private PositionPageViewModel _positionPageViewModell;

        private EmployeePageViewModel _workerPageViewModel;

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

        private IEnumerable<Employee> _selectedEmployees;

        public IEnumerable<Employee> SelectedEmployees
        {
            get
            {
                return _selectedEmployees;
            }
            set
            {
                _selectedEmployees = value;
                OnPropertyChanged(nameof(SelectedEmployees));
            }
        }

        private IEnumerable<Position> _selectedPositions;

        public IEnumerable<Position> SelectedPositions
        {
            get
            {
                return _selectedPositions;
            }
            set
            {
                _selectedPositions = value;
                OnPropertyChanged(nameof(SelectedPositions));
            } 
        }

        private Department _currentDepartment;

        public Department CurrentDepartment
        {
            get
            {
                return _currentDepartment;
            }
            set
            {
                _departmentPageViewModel.Department = value;
                _currentDepartment = value;
                OnPropertyChanged(nameof(CurrentDepartment));
            }
        }

        private Position _currentPosition;

        public Position CurrentPosition
        {
            get
            {
                return _currentPosition;
            }
            private set
            {
                _positionPageViewModell.Position = value;
                _currentPosition = value;
                if (_currentPosition.Employee != null)
                {
                    SelectedEmployees = new List<Employee>() { _currentPosition.Employee };
                }
                OnPropertyChanged(nameof(CurrentPosition));
                OnPropertyChanged(nameof(SelectedEmployees));
            }
        }

        private Employee _currentEmployee;

        public Employee CurrentEmployee
        {
            get
            {
                return _currentEmployee;
            }
            set
            {
                _workerPageViewModel.Employee= value;
                _currentEmployee = value;
                OnPropertyChanged(nameof(CurrentEmployee));
            }
        }

        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public ICommand SelectDepartmetnCommand { get; }

        public ICommand SelectPositionCommand { get; }

        public ICommand SelectEmployeeCommand { get; }

        public ICommand SelectAllEmployeesCommand { get; }


        public MainWindowViewModel(DepartmentService departmentService, PositionService positionService, IDataService<Employee> workerService)
        {
            _departmentService = departmentService;
            _positionService = positionService;
            SelectDepartmetnCommand = new SelectDepartmentCommand(this, positionService);
            SelectPositionCommand = new SelectPositionCommand(this, positionService);
            SelectEmployeeCommand = new SelectEmployeeCommand(this);
            SelectAllEmployeesCommand = new SelectAllEmployeesCommand(this, workerService);
            
            _departmentPageViewModel = new DepartmentPageViewModel(this, departmentService, positionService);
            _positionPageViewModell = new PositionPageViewModel();
            _workerPageViewModel = new EmployeePageViewModel();

            UpdateDepartments();
        }

        public void SelectDepartment(Department department)
        {
            CurrentDepartment = department;
        }

        public void SelectPosition(Position position)
        {
            CurrentPosition = position;
        }
        
        public void SelectEmployee(Employee employee)
        {
            CurrentEmployee = employee;
        }

        public void UpdateDepartments()
        {
            _departmentService.GetAll().ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    Departments = task.Result;
                }
            });
        }

        public void UpdateSelectedPage(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.DepartmentPage:
                    CurrentViewModel = _departmentPageViewModel;
                    break;
                case ViewType.PositionPage:
                    CurrentViewModel = _positionPageViewModell;
                    break;
                case ViewType.EmployeePage:
                    CurrentViewModel = _workerPageViewModel;
                    break;
            }
        }
    }
}
