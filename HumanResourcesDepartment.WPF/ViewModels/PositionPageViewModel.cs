using HumanResourcesDepartment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
