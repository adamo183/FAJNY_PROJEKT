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
                MessageBox.Show("Błędne dane logowania!","Error",MessageBoxButton.OK,MessageBoxImage.Error);
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
    }

    class Login
    {
      public static bool login(string log_f, string pass_f)
        {
            DataClasses1DataContext context = new DataClasses1DataContext();
            var q = from t in context.login_tab
                    where t.login == log_f && 
                    t.password == pass_f
                    select t;


                return (q.Count() == 1);

        }
    }
}
