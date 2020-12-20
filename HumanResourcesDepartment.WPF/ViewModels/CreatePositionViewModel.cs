using HumanResourcesDepartment.Domain.Models;
using HumanResourcesDepartment.Domain.Sercices;
using HumanResourcesDepartment.EntityFramework.Sercices;
using HumanResourcesDepartment.EntityFramework.Services;
using HumanResourcesDepartment.WPF.Comands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace HumanResourcesDepartment.WPF.ViewModels
{
    public class CreatePositionViewModel : ViewModelBase
    {
        public ICommand CreatePositionCommand { get; private set; }
        
        private string _name;

        private EmployeeDataService _employeeService;

        private GenericDataService<Profession> _professionService;

        private DepartmentService _departmentService;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

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

        private IEnumerable<Employee> _employees;

        public IEnumerable<Employee> Employees
        {
            get
            {
                return _employees;
            }
            set
            {
                _employees = value;
                OnPropertyChanged(nameof(Employees));
            }
        }

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

        private IEnumerable<Department> _departments;

        public IEnumerable<Department> Departments
        {
            get
            {
                return _departments;
            }
            set
            {
                _departments = value;
                OnPropertyChanged(nameof(Departments));
            }
        }

        private Profession _profession;

        public Profession Profession
        {
            get
            {
                return _profession;
            }
            set
            {
                _profession = value;
                OnPropertyChanged(nameof(Profession));
            }
        }

        private IEnumerable<Profession> _professions;

        public IEnumerable<Profession> Professions
        {
            get
            {
                return _professions;
            }
            set
            {
                _professions = value;
                OnPropertyChanged(nameof(Professions));
            }
        }

        private int _salary;

        public int Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                _salary = value;
                OnPropertyChanged(nameof(Salary));
            }
        }


        public CreatePositionViewModel(PositionService positionService, DepartmentService departmentService, EmployeeDataService employeeService, GenericDataService<Profession> professionService, MainWindowViewModel mainWindowViewModel)
        {
            _employeeService = employeeService;
            _professionService = professionService;
            _departmentService = departmentService;
            CreatePositionCommand = new CreatePositionCommand(this, mainWindowViewModel, positionService, departmentService, employeeService, professionService);
            InitializeSoucreCollections();
        }

        public void InitializeSoucreCollections()
        {
            _employeeService.GetAll().ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    Employees = task.Result;
                }
            });
            _professionService.GetAll().ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    Professions = task.Result;
                }
            });
            _departmentService.GetAll().ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    Departments = task.Result;
                }
            });
        }
    }
}
