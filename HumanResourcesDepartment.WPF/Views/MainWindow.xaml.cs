using HumanResourcesDepartment.EntityFramework;
using HumanResourcesDepartment.WPF.ViewModels;
using HumanResourcesDepartment.WPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HumanResourcesDepartment.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HumanResourcesDbContextFactory _dbContextFactor;

        public MainWindow(HumanResourcesDbContextFactory dbContextFactor)
        {
            _dbContextFactor = dbContextFactor;
            InitializeComponent();
        }

        public void HandleCreateDepartemntClick(object sender, RoutedEventArgs e)
        {
            CreateDepartmentWindow subWindow = new CreateDepartmentWindow(DataContext as MainWindowViewModel);
            subWindow.Show();
        }

        public void HandleCreatePositionClick(object sender, RoutedEventArgs e)
        {
            CreatePositionWindow subWindow = new CreatePositionWindow(DataContext as MainWindowViewModel, _dbContextFactor);
            subWindow.Show();
        }
        
        public void HandleCreateEmployeeClick(object sender, RoutedEventArgs e)
        {
            CreateEmployeeWindow subWindow = new CreateEmployeeWindow(DataContext as MainWindowViewModel);
            subWindow.Show();
        }
    }
}
