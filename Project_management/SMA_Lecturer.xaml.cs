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
using database_layer;
using logic_layer;

namespace Project_management
{
    /// <summary>
    /// Logika interakcji dla klasy SMA_Lecturer.xaml
    /// </summary>
    public partial class SMA_Lecturer : Page
    {
        public Lecturer lecturer { get; private set; }
        public SMA_Lecturer()
        {
            InitializeComponent();
            Lecturer_Grid.ItemsSource = MenuAdminLogic.getLecturerList(); 
        
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SMA_add add_wind = new SMA_add(2);
            add_wind.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Lecturer_Grid.SelectedItem == null)
            {
                MessageBox.Show("Choose user");
                return;
            }
            else if (Lecturer_Grid.SelectedItems.Count > 1)
            {
                MessageBox.Show("Choose one user");
                return;
            }

            var selected_user_id = ((MenuAdminLogic.UserDisplay)Lecturer_Grid.SelectedItem).User_ID;
            SMA_changePass chPass = new SMA_changePass(selected_user_id);
            chPass.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (Lecturer_Grid.SelectedItem == null)
            {
                MessageBox.Show("Choose user");
                return;
            }
            else if (Lecturer_Grid.SelectedItems.Count > 1)
            {
                MessageBox.Show("Choose one user");
                return;
            }
            var selected_user_id = ((MenuAdminLogic.UserDisplay)Lecturer_Grid.SelectedItem).User_ID;
            var selected_user_status = ((MenuAdminLogic.UserDisplay)Lecturer_Grid.SelectedItem).active;
            MenuAdminLogic.setUserStatus(selected_user_id, selected_user_status);
            Lecturer_Grid.ItemsSource = MenuAdminLogic.getLecturerList();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (Lecturer_Grid.SelectedItem == null)
            {
                MessageBox.Show("Choose user");
                return;
            }
            else if (Lecturer_Grid.SelectedItems.Count > 1)
            {
                MessageBox.Show("Choose one user");
                return;
            }
            var selected_user_id = ((MenuAdminLogic.UserDisplay)Lecturer_Grid.SelectedItem);
            SMA_editData edit_data = new SMA_editData(selected_user_id);
            edit_data.Show();
        }
    }
}
