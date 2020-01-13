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
using logic_layer;
using database_layer;
namespace Project_management
{
    /// <summary>
    /// Logika interakcji dla klasy SMA_editData.xaml
    /// </summary>
    public partial class SMA_editData : Window
    {
        public login_tab login_user { get; private set; }
        public string surname { get;private set; }
        public SMA_editData(MenuAdminLogic.UserDisplay user)
        {
            InitializeComponent();
            login_user = MenuAdminLogic.getLoginInfo(user.User_ID);
            login_field.Text = login_user.login;
            surname = user.Surname;
            surname_field.Text = surname;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(login_user.login != login_field.Text)
            {
                if(!(Login.checklogin(login_field.Text)))
                {
                    MessageBox.Show("Login already exist in database");
                    return;
                }
                if (login_field.Text.Trim().Length != 0)
                {
                    MenuAdminLogic.changeLogin(login_user.Id, login_field.Text);
                }
                else
                {
                    MessageBox.Show("Fill empty field");
                    return;
                }

            }
            else if(surname != surname_field.Text)
            {
               if(surname_field.Text.Trim().Length != 0 )
                {
                    MenuAdminLogic.changeSurname(login_user.u_id, login_user.role, surname_field.Text);
                }
               else
                {
                    MessageBox.Show("Fill empty field");
                    return;
                }
            }
            this.Close();

            
        }
    }
}
