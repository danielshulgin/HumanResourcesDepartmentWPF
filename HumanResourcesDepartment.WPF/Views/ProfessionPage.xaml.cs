using HumanResourcesDepartment.Domain.Models;
using HumanResourcesDepartment.Domain.Sercices;
using HumanResourcesDepartment.EntityFramework;
using HumanResourcesDepartment.WPF.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace HumanResourcesDepartment.WPF.Views
{
    /// <summary>
    /// Interaction logic for WorkerPage.xaml
    /// </summary>
    public partial class ProfessionPage : UserControl
    {
        public ProfessionPage()
        {
            InitializeComponent();
            HumanResourcesDbContextFactory dbContextFactory = new HumanResourcesDbContextFactory("server=(localdb)\\MSSQLLocalDB;Database=HumanResourcesDepartmentDB;Trusted_Connection=True;");
            var professionService = new GenericDataService<Profession>(dbContextFactory);
            this.DataContext = new ProfessionPageViewModel(professionService);
        }

        public void HandleCreateProfessionClick(object sender, RoutedEventArgs e)
        {
            CreateProfessionWindow subWindow = new CreateProfessionWindow(DataContext as ProfessionPageViewModel);
            subWindow.Show();
        }
    }
}
