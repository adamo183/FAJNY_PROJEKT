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
    /// Logika interakcji dla klasy SMA_add.xaml
    /// </summary>
    public partial class SMA_add : Window
    {
        public int mode;
        public SMA_add(int mode)
        {
            InitializeComponent();
            this.mode = mode;
            if(mode==1)
            {
                Degree_label.Visibility = Visibility.Hidden;
                Degree_choose.Visibility = Visibility.Hidden;
                Sem_label.Visibility = Visibility.Hidden;
                Sem_choose.Visibility = Visibility.Hidden;
            }
            else if(mode==2)
            {
                Sem_label.Visibility = Visibility.Hidden;
                Sem_choose.Visibility = Visibility.Hidden;

            }
            else if(mode ==3 )
            {
                Degree_label.Visibility = Visibility.Hidden;
                Degree_choose.Visibility = Visibility.Hidden;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

        private void Degree_choose_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = Name_field.Text.Trim();
            string surname = Surname_field.Text.Trim();
            string login = Login_field.Text.Trim();
            string pass = Pass_Field.Text.Trim();
            if(mode == 2)
            {

            }

        }
    }
}
