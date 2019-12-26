using database_layer;
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
    /// Logika interakcji dla klasy SML_Sub_AddEdit.xaml
    /// </summary>
    public partial class SML_Sub_AddEdit : Window
    {
        private Subject subject;
        private int mode;

        public SML_Sub_AddEdit()
        {
            InitializeComponent();
        }
        public SML_Sub_AddEdit(int mod, Subject sub)
        {
            mode = mod;
            subject = sub;
            InitializeComponent();
            view();
        }
          private void view()
          {
              if(mode == 0 )
                  this.s_name.Text = subject.Name;
          }
          

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
