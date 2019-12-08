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
    /// Logika interakcji dla klasy SelectionMenuLecturer.xaml
    /// </summary>
    public partial class SelectionMenuLecturer : Window
    {
        public SelectionMenuLecturer()
        {
            InitializeComponent();
        }

        private void SML_CreateSubject_button(object sender, RoutedEventArgs e)
        {
            SML_Subject SML_Subject_window = new SML_Subject();
             //this.Visibility = Visibility.Hidden;
            SML_Subject_window.Show();
        }

        private void SML_SectionManagement_button(object sender, RoutedEventArgs e)
        {
            SML_SectionManagement SML_SectionManagement_window = new SML_SectionManagement();
            //this.Visibility = Visibility.Hidden;
            SML_SectionManagement_window.Show();
        }

        private void SML_Presence_button(object sender, RoutedEventArgs e)
        {
            SML_Presence SML_Presence_window = new SML_Presence();
            //this.Visibility = Visibility.Hidden;
            SML_Presence_window.Show();
        }
    }
}
