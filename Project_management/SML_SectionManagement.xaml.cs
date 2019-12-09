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
    /// Logika interakcji dla klasy SML_SectionManagement.xaml
    /// </summary>
    public partial class SML_SectionManagement : Window
    {
        public SML_SectionManagement()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SML_Stu_Add stu_add_window = new SML_Stu_Add();
            stu_add_window.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SML_SecMan_SecAdd SML_SecMan_SecAdd_window = new SML_SecMan_SecAdd();
            SML_SecMan_SecAdd_window.Show();
        }
    }
}
