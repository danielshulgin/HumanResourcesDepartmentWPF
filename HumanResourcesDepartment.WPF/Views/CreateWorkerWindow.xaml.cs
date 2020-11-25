using HumanResourcesDepartment.Domain.Models;
using HumanResourcesDepartment.Domain.Sercices;
using HumanResourcesDepartment.EntityFramework;
using HumanResourcesDepartment.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HumanResourcesDepartment.WPF.Views
{
    /// <summary>
    /// Interaction logic for CreateWorkerWindow.xaml
    /// </summary>
    public partial class CreateWorkerWindow : Window
    {

        public CreateWorkerWindow(MainWindowViewModel mainWindowViewModel)
        {
            HumanResourcesDbContextFactory dbContextFactory = new HumanResourcesDbContextFactory("server=(localdb)\\MSSQLLocalDB;Database=HumanResourcesDepartmentDB;Trusted_Connection=True;");
            var workerService = new GenericDataService<Worker>(dbContextFactory);
            this.DataContext = new CreateWorkerViewModel(workerService, mainWindowViewModel);
            InitializeComponent();
        }


        public void HandleCloseButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

    public class EnumToItemsSource : MarkupExtension
    {
        private readonly Type _type;

        public EnumToItemsSource(Type type)
        {
            _type = type;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enum.GetValues(_type)
                .Cast<object>()
                .Select(e => new { Value = (int)e, DisplayName = e.ToString() });
        }
    }
}
