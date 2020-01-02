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
using System.Windows.Shapes;

namespace Project_management
{
    /// <summary>
    /// Logika interakcji dla klasy SelectionMenuAdmin.xaml
    /// </summary>
    public partial class SelectionMenuAdmin : Window
    {
        public SelectionMenuAdmin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SMA.Content = new SMA_Admin();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SMA.Content = new SMA_Lecturer();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SMA.Content = new SMA_Student();
        }
    }
}
