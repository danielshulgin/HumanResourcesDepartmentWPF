using HumanResourcesDepartment.Domain.Models;
using HumanResourcesDepartment.Domain.Sercices;
using HumanResourcesDepartment.WPF.Comands;
using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Input;

namespace HumanResourcesDepartment.WPF.ViewModels
{
    public class CreateEmployeeViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        private readonly ErrorsViewModel _errorsViewModel;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public bool CanCreate => !HasErrors &&
            !string.IsNullOrEmpty(_name) &&
            _tin != 0 &&
            _phone != 0 &&
            !string.IsNullOrEmpty(_contactEmail) &&
            !string.IsNullOrEmpty(_country) &&
            !string.IsNullOrEmpty(_city) &&
            !string.IsNullOrEmpty(_street) &&
            !string.IsNullOrEmpty(_houseNumber);

        public ICommand CreateProductCommand { get; }

        public bool HasErrors => _errorsViewModel.HasErrors;

        public ICommand CreateEmployeeCommand { get; private set; }

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
                _errorsViewModel.ClearErrors(nameof(Name));
                if (_name.Length < 3 || _name.Length > 15)
                {
                    _errorsViewModel.AddError(nameof(Name), "Invalid name");
                }
                OnPropertyChanged(nameof(Name));
            }
        }

        private Sex _sex;

        public Sex Sex
        {
            get
            {
                return _sex;
            }
            set
            {
                _sex = value;
                OnPropertyChanged(nameof(Sex));
            }
        }

        private int _tin;


        public int Tin
        {
            get
            {
                return _tin;
            }
            set
            {
                _tin = value;

                _errorsViewModel.ClearErrors(nameof(Tin));
                if (_tin < 99999 || _tin > 99999999)
                {
                    _errorsViewModel.AddError(nameof(Tin), "Invalid tin");
                }
                OnPropertyChanged(nameof(Tin));
            }
        }

        private int _phone;

        public int Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;

                _errorsViewModel.ClearErrors(nameof(Phone));
                if (_phone < 999999 || _phone > 99999999)
                {
                    _errorsViewModel.AddError(nameof(Phone), "Invalid phone");
                }

                OnPropertyChanged(nameof(Phone));
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
                _errorsViewModel.ClearErrors(nameof(ContactEmail));
                if (_contactEmail.Length < 3 || _contactEmail.Length > 15)
                {
                    _errorsViewModel.AddError(nameof(ContactEmail), "Invalid email");
                }
                OnPropertyChanged(nameof(ContactEmail));
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


        private AccessRights _accessRights;

        public AccessRights AccessRights
        {
            get
            {
                return _accessRights;
            }
            set
            {
                _accessRights = value;
                OnPropertyChanged(nameof(AccessRights));
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
                _errorsViewModel.ClearErrors(nameof(Country));
                if (_country.Length < 3 || _country.Length > 15)
                {
                    _errorsViewModel.AddError(nameof(Country), "Invalid country");
                }
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
                _errorsViewModel.ClearErrors(nameof(City));
                if (_city.Length < 3 || _city.Length > 15)
                {
                    _errorsViewModel.AddError(nameof(City), "Invalid city");
                }
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
                _errorsViewModel.ClearErrors(nameof(Street));
                if (_street.Length < 3 || _street.Length > 15)
                {
                    _errorsViewModel.AddError(nameof(Street), "Invalid street");
                }
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
                _errorsViewModel.ClearErrors(nameof(HouseNumber));
                if (_houseNumber.Length < 1 || _houseNumber.Length > 7)
                {
                    _errorsViewModel.AddError(nameof(HouseNumber), "Invalid house number");
                }
                OnPropertyChanged(nameof(HouseNumber));
            }
        }


        public CreateEmployeeViewModel(GenericDataService<Employee> workerService, MainWindowViewModel mainWindowViewModel)
        {
            CreateEmployeeCommand = new CreateEmployeeCommand(this, workerService);
            _errorsViewModel = new ErrorsViewModel();
            _errorsViewModel.ErrorsChanged += ErrorsViewModel_ErrorsChanged;
        }

        public IEnumerable GetErrors(string propertyName)
        {
            return _errorsViewModel.GetErrors(propertyName);
        }

        private void ErrorsViewModel_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            ErrorsChanged?.Invoke(this, e);
            OnPropertyChanged(nameof(CanCreate));
        }
    }
}
