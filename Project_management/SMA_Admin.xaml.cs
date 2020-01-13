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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (AdminGrid.SelectedItem == null)
            {
                MessageBox.Show("Choose user");
                return;
            }
            else if(AdminGrid.SelectedItems.Count>1 )
            {
                MessageBox.Show("Choose one user");
                return;
            }

            var selected_user_id = ((MenuAdminLogic.UserDisplay)AdminGrid.SelectedItem).User_ID;
            SMA_changePass chPass = new SMA_changePass(selected_user_id);
            chPass.Show();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (AdminGrid.SelectedItem == null)
            {
                MessageBox.Show("Choose user");
                return;
            }
            else if (AdminGrid.SelectedItems.Count > 1)
            {
                MessageBox.Show("Choose one user");
                return;
            }
            var selected_user_id = ((MenuAdminLogic.UserDisplay)AdminGrid.SelectedItem).User_ID;
            var selected_user_status = ((MenuAdminLogic.UserDisplay)AdminGrid.SelectedItem).active;
            MenuAdminLogic.setUserStatus(selected_user_id, selected_user_status);
            AdminGrid.ItemsSource = MenuAdminLogic.getAdminList();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (AdminGrid.SelectedItem == null)
            {
                MessageBox.Show("Choose user");
                return;
            }
            else if (AdminGrid.SelectedItems.Count > 1)
            {
                MessageBox.Show("Choose one user");
                return;
            }
            var selected_user_id = ((MenuAdminLogic.UserDisplay)AdminGrid.SelectedItem);
            SMA_editData edit_data = new SMA_editData(selected_user_id);
            edit_data.Show();

            
        }
    }
}
