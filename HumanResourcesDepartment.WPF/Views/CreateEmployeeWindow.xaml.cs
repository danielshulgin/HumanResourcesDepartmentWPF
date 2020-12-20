using HumanResourcesDepartment.Domain.Models;
using HumanResourcesDepartment.Domain.Sercices;
using HumanResourcesDepartment.EntityFramework;
using HumanResourcesDepartment.WPF.ViewModels;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Markup;

namespace HumanResourcesDepartment.WPF.Views
{
    /// <summary>
    /// Interaction logic for CreateWorkerWindow.xaml
    /// </summary>
    public partial class CreateEmployeeWindow : Window
    {

        public CreateEmployeeWindow(MainWindowViewModel mainWindowViewModel)
        {
            HumanResourcesDbContextFactory dbContextFactory = new HumanResourcesDbContextFactory("server=(localdb)\\MSSQLLocalDB;Database=HumanResourcesDepartmentDB;Trusted_Connection=True;");
            var workerService = new GenericDataService<Employee>(dbContextFactory);
            this.DataContext = new CreateEmployeeViewModel(workerService, mainWindowViewModel);
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
