﻿using HumanResourcesDepartment.Domain.Models;
using HumanResourcesDepartment.Domain.Sercices;
using HumanResourcesDepartment.EntityFramework;
using HumanResourcesDepartment.EntityFramework.Sercices;
using HumanResourcesDepartment.EntityFramework.Services;
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
using System.Windows.Shapes;

namespace HumanResourcesDepartment.WPF.Views
{
    /// <summary>
    /// Interaction logic for CreatePositionWindow.xaml
    /// </summary>
    public partial class CreateProfessionWindow : Window
    {
        public CreateProfessionWindow(ProfessionPageViewModel professionPageViewModel)
        {
            HumanResourcesDbContextFactory dbContextFactory = new HumanResourcesDbContextFactory("server=(localdb)\\MSSQLLocalDB;Database=HumanResourcesDepartmentDB;Trusted_Connection=True;");
            var professionService = new GenericDataService<Profession>(dbContextFactory);
            this.DataContext = new CreateProfessionViewModel(professionPageViewModel, professionService);
            InitializeComponent();
        }


        public void HandleCloseButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}