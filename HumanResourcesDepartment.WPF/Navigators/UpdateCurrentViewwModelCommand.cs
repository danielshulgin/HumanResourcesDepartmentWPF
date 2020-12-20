using HumanResourcesDepartment.WPF.ViewModels;
using System;
using System.Windows.Input;

namespace HumanResourcesDepartment.WPF.Navigators
{
    public class UpdateCurrentViewwModelCommand : ICommand
    {
        public MainWindowViewModel MainWindowViewModel { get; }
#pragma warning disable CS0067
        public event EventHandler CanExecuteChanged;
        public UpdateCurrentViewwModelCommand(MainWindowViewModel mainWindowViewModel)
        {
            MainWindowViewModel = mainWindowViewModel;
            //_navigator = mainWindowViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
