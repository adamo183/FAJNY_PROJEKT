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
using database_layer;
using logic_layer;

namespace Project_management
{
    /// <summary>
    /// Logika interakcji dla klasy SMA_changePass.xaml
    /// </summary>
    public partial class SMA_changePass : Window
    {
        public int id { get; set; }
        public SMA_changePass(int id)
        {
            InitializeComponent();
            this.id = id;
            MessageBox.Show(id.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (new_pass0.Password != new_pass1.Password)
            {
                MessageBox.Show("");
                return;
            }
            MenuAdminLogic.changePassword(new_pass0.Password,id);
            this.Close();
        }
    }
}
