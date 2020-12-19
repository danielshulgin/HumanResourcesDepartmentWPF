using HumanResourcesDepartment.Domain.Models;
using HumanResourcesDepartment.Domain.Sercices;
using HumanResourcesDepartment.EntityFramework;
using HumanResourcesDepartment.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
