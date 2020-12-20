using HumanResourcesDepartment.Domain.Models;

namespace HumanResourcesDepartment.WPF.ViewModels
{
    public class PositionPageViewModel : ViewModelBase
    {
        private Position _position;

        public Position Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
                OnPropertyChanged(nameof(Position));
            }
        }
    }
}
