using HumanResourcesDepartment.Domain.Sercices;
using HumanResourcesDepartment.EntityFramework.Sercices;
using HumanResourcesDepartment.WPF.Comands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace HumanResourcesDepartment.WPF.ViewModels
{
    public class CreateDepartmentViewModel : ViewModelBase
    {
        public ICommand CreateDepartmentCommand { get; private set; }
        
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

        private string _description;

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private string _contactEmail;


        public string ContactEmail
        {
            get
            {
                return _contactEmail;
            }
            set
            {
                _contactEmail = value;
                OnPropertyChanged(nameof(ContactEmail));
            }
        }

        private int _contactPhone;

        public int ContactPhone
        {
            get
            {
                return _contactPhone;
            }
            set
            {
                _contactPhone = value;
                OnPropertyChanged(nameof(ContactPhone));
            }
        }

        private string _country;

        public string Country
        {
            get
            {
                return _country;
            }
            set
            {
                _country = value;
                OnPropertyChanged(nameof(Country));
            }
        }

        private string _city;

        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
                OnPropertyChanged(nameof(City));
            }
        }

        private string _street;

        public string Street
        {
            get
            {
                return _street;
            }
            set
            {
                _street = value;
                OnPropertyChanged(nameof(Street));
            }
        }

        private string _houseNumber;

        public string HouseNumber
        {
            get
            {
                return _houseNumber;
            }
            set
            {
                _houseNumber = value;
                OnPropertyChanged(nameof(HouseNumber));
            }
        }


        public CreateDepartmentViewModel(DepartmentService departmentService, MainWindowViewModel mainWindowViewModel)
        {
            CreateDepartmentCommand = new CreateDepartmentCommand(this, mainWindowViewModel, departmentService);
        }

        public bool IsValuesCorrect()
        {
            if (!Regex.IsMatch(_contactPhone.ToString(), @"\d{12}"))
            {
                return false;
            }
            return true;
        }
    }
}
