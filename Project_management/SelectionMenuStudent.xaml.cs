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
    /// Logika interakcji dla klasy SelectionMenuStudent.xaml
    /// </summary>
    public partial class SelectionMenuStudent : Window
    {
        public SelectionMenuStudent()
        {
            InitializeComponent();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SMS_Join objSecondWindow = new SMS_Join();
            objSecondWindow.Show();
        }
    }
}
