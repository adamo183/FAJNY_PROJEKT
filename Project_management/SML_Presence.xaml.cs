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
    /// Logika interakcji dla klasy SML_Presence.xaml
    /// </summary>
    public partial class SML_Presence : Window
    {
        public SML_Presence(int sec_id)
        {
            InitializeComponent();
            presencegrid.ItemsSource = MenuLecturerLogic.getPresenceofSection(sec_id);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
