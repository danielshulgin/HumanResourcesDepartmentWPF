using HumanResourcesDepartment.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace HumanResourcesDepartment.WPF.Navigators
{
    public enum ViewType
    {
        DepartmentPage,
        PositionPage,
        WorkerPage
    }

    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }

        ICommand UpdateCurrentViewModel { get; }
    }
}
