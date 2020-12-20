using HumanResourcesDepartment.WPF.ViewModels;
using System.Windows.Input;

namespace HumanResourcesDepartment.WPF.Navigators
{
    public enum ViewType
    {
        DepartmentPage,
        PositionPage,
        EmployeePage
    }

    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }

        ICommand UpdateCurrentViewModel { get; }
    }
}
