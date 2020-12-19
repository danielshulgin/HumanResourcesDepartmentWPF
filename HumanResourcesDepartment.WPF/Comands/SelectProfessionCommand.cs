using HumanResourcesDepartment.Domain.Models;
using HumanResourcesDepartment.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.WPF.Comands
{
    public class SelectProfessionCommand : AsyncCommandBase
    {
        private readonly ProfessionPageViewModel _viewModel;


        public SelectProfessionCommand(ProfessionPageViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            if (parameter is Profession profession)
            {
                _viewModel.CurrentProfession = profession;
            }
        }
    }
}
