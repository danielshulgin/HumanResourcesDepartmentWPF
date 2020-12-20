using HumanResourcesDepartment.Domain.Models;
using HumanResourcesDepartment.Domain.Sercices;
using HumanResourcesDepartment.WPF.Comands;
using System.Windows.Input;

namespace HumanResourcesDepartment.WPF.ViewModels
{
    public class CreateProfessionViewModel : ViewModelBase
    {
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

        private int _professionCode;

        public int ProfessionCode
        {
            get
            {
                return _professionCode;
            }
            set
            {
                _professionCode = value;
                OnPropertyChanged(nameof(ProfessionCode));
            }
        }

        private int _averageSalery;

        public int AverageSalery
        {
            get
            {
                return _averageSalery;
            }
            set
            {
                _averageSalery = value;
                OnPropertyChanged(nameof(AverageSalery));
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
        public ICommand CreateProfessionCommand { get; private set; }

        public CreateProfessionViewModel(ProfessionPageViewModel professionPageViewModel, GenericDataService<Profession> professionService)
        {
            CreateProfessionCommand = new CreateProfessionCommand(this, professionPageViewModel, professionService);
        }
    }
}
