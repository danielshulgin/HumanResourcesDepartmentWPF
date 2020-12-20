using HumanResourcesDepartment.Domain.Models;
using HumanResourcesDepartment.Domain.Sercices;
using HumanResourcesDepartment.WPF.ViewModels;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.WPF.Comands
{
    public class CreateProfessionCommand : AsyncCommandBase
    {
        private readonly GenericDataService<Profession> _professionService;

        private readonly CreateProfessionViewModel _viewModel;

        private readonly ProfessionPageViewModel _professionPageviewModel;


        public CreateProfessionCommand(CreateProfessionViewModel viewModel, ProfessionPageViewModel professionPageviewModel, GenericDataService<Profession> professionService)
        {
            _professionService = professionService;
            _professionPageviewModel = professionPageviewModel;
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var position = new Profession(_viewModel.Name, _viewModel.ProfessionCode, _viewModel.AverageSalery, _viewModel.Description);
            await _professionService.Create(position);
            _professionPageviewModel.Professions = await _professionService.GetAll();
        }
    }
}
