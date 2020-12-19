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

        private int _workerId;

        public int WorkerId
        {
            get
            {
                return _workerId;
            }
            set
            {
                _workerId = value;
                OnPropertyChanged(nameof(WorkerId));
            }
        }

        private int _departmentId;


        public int DepartmentId
        {
            get
            {
                return _departmentId;
            }
            set
            {
                _departmentId = value;
                OnPropertyChanged(nameof(DepartmentId));
            }
        }

        private int _professionId;

        public int ProfessionId
        {
            get
            {
                return _professionId;
            }
            set
            {
                _professionId = value;
                OnPropertyChanged(nameof(ProfessionId));
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


        public CreatePositionViewModel(PositionService positionService, DepartmentService departmentService, EmployeeDataService workerService, GenericDataService<Profession> professionService, MainWindowViewModel mainWindowViewModel)
        {
            CreatePositionCommand = new CreatePositionCommand(this, mainWindowViewModel, positionService, departmentService, workerService, professionService);
        }
    }
}
