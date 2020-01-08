﻿using System;
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
using database_layer;
using logic_layer;


namespace Project_management
{
    /// <summary>
    /// Logika interakcji dla klasy SMA_Admin.xaml
    /// </summary>
    public partial class SMA_Admin : Page
    {
        public SMA_Admin()
        {
            InitializeComponent();
            AdminGrid.ItemsSource = MenuAdminLogic.getAdminList();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SMA_add add_wind = new SMA_add(1);
            add_wind.Show();
        }
    }
}
