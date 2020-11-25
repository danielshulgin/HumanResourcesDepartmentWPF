using HumanResourcesDepartment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResourcesDepartment.WPF.ViewModels
{
    public class WorkerPageViewModel : ViewModelBase
    {
        private Worker _worker;

        public Worker Worker
        {
            get
            {
                return _worker;
            }
            set
            {
                _worker = value;
                OnPropertyChanged(nameof(Worker));
            }
        }
    }
}
