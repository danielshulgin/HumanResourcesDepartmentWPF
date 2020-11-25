using HumanResourcesDepartment.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace HumanResourcesDepartment.WPF.Navigators
{
    public class UpdateCurrentViewwModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private INavigator _navigator;


        public UpdateCurrentViewwModelCommand(MainWindowViewModel mainWindowViewModel)
        {
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
