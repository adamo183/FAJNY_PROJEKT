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
    /// Logika interakcji dla klasy SMA_panel.xaml
    /// </summary>
    public partial class SMA_panel : Window
    {
        public SMA_panel()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SMA_add SMA_add_window = new SMA_add();
            this.Visibility = Visibility ;
            SMA_add_window.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SMA_add SMA_add_window = new SMA_add();
            this.Visibility = Visibility;
            SMA_add_window.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SMA_add SMA_add_window = new SMA_add();
            this.Visibility = Visibility;
            SMA_add_window.Show();
        }
    }
    }

