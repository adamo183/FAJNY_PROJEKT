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
using logic_layer;
using database_layer;



namespace Project_management
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        string log_t;

        private void OpenWindow(object sender, RoutedEventArgs e)
        {
            /*SelectionMenuAdmin objSMA = new SelectionMenuAdmin();
            this.Visibility = Visibility.Hidden;
            objSMA.Show();
            */
            log_t = login_text.Text;
            if(login_text.Text == "" || password_text.Text == "")
            {
                MessageBox.Show("Uzupełnij pola login oraz hasło!","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            else
            {
                bool access = Login.login(login_text.Text, password_text.Text);
                if (access)
                {
                    SelectionMenuAdmin objSMA = new SelectionMenuAdmin();
                    this.Visibility = Visibility.Hidden;
                    objSMA.Show();
                }
                else
                    MessageBox.Show("Błędne dane logowania!(spróbuj admin,123)");


            }
        }
        ///Usunąć potem funkcję DoProwadzących, tylko do testów sobie zrobiłem
        private void DoProwadzacych(object sender, RoutedEventArgs e)
        {
            SelectionMenuLecturer SelectionMenuLecturer_window = new SelectionMenuLecturer();
            this.Visibility = Visibility.Hidden;
            SelectionMenuLecturer_window.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SMA_panel SMA_panel_window = new SMA_panel();
            this.Visibility = Visibility;
            SMA_panel_window.Show(); 


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SelectionMenuStudent NewWindow = new SelectionMenuStudent();
            this.Visibility = Visibility.Hidden;
            NewWindow.Show();
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }
    }

    class Login
    {
      public static bool login(string log_f, string pass_f)
        {
            DataClassesDataContext context = new DataClassesDataContext();
            var q = from t in context.login_tab
                    where t.login == log_f && 
                    t.password == pass_f
                    select t;


                return (q.Count() == 1);
                
            
        }
    }
}
