using HumanResourcesDepartment.Domain.Models;
using HumanResourcesDepartment.Domain.Sercices;
using HumanResourcesDepartment.WPF.Comands;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace HumanResourcesDepartment.WPF.ViewModels
{
    public class ProfessionPageViewModel : ViewModelBase
    {
        private GenericDataService<Profession> _professionService;

        private Profession _currentProfession;

        public Profession CurrentProfession
        {
            get
            {
                return _currentProfession;
            }
            set
            {
                _currentProfession = value;
                OnPropertyChanged(nameof(CurrentProfession));
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

        public ICommand SelectProfessionCommand { get; }


        public ProfessionPageViewModel(GenericDataService<Profession> professionService)
        {
            _professionService = professionService;
            SelectProfessionCommand = new SelectProfessionCommand(this);
            SelectAllProfessions();
        }

        public void SelectAllProfessions()
        {
            _professionService.GetAll().ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    Professions = task.Result;
                    CurrentProfession = Professions.FirstOrDefault();
                }
            });
        }
    }
}
