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
using System.Collections.ObjectModel;
using database_layer;
using logic_layer;
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
            List<Tuple<int, string, string>> semsetrInfoList = new List<Tuple<int, string, string>>();

            IQueryable<SemsestrInfo> stb = MenuLecturerLogic.getSemestrInfo();
            stb.ToList();
            foreach (var rec in stb) semsetrInfoList.Add(Tuple.Create(rec.semestrid, rec.fieldofstudy.Trim(), rec.yearofstudy));
            Sem_choose.ItemsSource = semsetrInfoList;

            ObservableCollection<string> list = new ObservableCollection<string>();
            list.Add("Inż");
            list.Add("Mgr.");
            list.Add("Dr.");
            list.Add("Prof");
            Degree_choose.ItemsSource = list;
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
            bool avaible = isAvaible.IsChecked.Value;
            if(!Login.checklogin(login))
            {

            }
            if ( (name.Length==0)||(surname.Length==0)||(login.Length==0)||(pass.Length==0) )
            {
                MessageBox.Show("Wypełnij wszystkie pola");
                return;
            }
            if(mode == 2)
            {
                if(Degree_choose.SelectedItem == null)
                {
                    MessageBox.Show("Wybierz stopień naukowy");
                    return;
                }
                DataClassesDataContext context = new DataClassesDataContext();
                Lecturer new_lec= new Lecturer();
                int new_id = (context.Lecturer.OrderByDescending(x => x.ID_lecturer).FirstOrDefault()).ID_lecturer + 1;
                new_lec.ID_lecturer = (short)new_id;
                new_lec.Name = name;
                new_lec.Surname = surname;
                new_lec.Degree = Degree_choose.Text;
                MenuAdminLogic.addLecturer(new_lec);
                MenuAdminLogic.addLogin(login, pass, "lecturer", isAvaible.IsChecked.Value, (short)new_id);

            }
            else if(mode == 3)
            {
                if(Sem_choose.SelectedItem == null)
                {
                    MessageBox.Show("Wybierz semestr");
                    return;

                }
                DataClassesDataContext context = new DataClassesDataContext();
                Student stu = new Student();
                int new_id = (context.Student.OrderByDescending(x => x.ID_Album).FirstOrDefault()).ID_Album + 1;
                stu.ID_Album = (short)new_id;
                stu.Name = name;
                stu.Surname = surname;

                var sem_id= ((Tuple<int, string, string>)Sem_choose.SelectedItem).Item1;
                MenuAdminLogic.addStudent(stu);
                MenuAdminLogic.addLogin(login, pass, "student", isAvaible.IsChecked.Value, (short)new_id);
                MenuAdminLogic.addStuInSem(new_id, sem_id);
            }
            else if(mode == 1)
            {
                DataClassesDataContext context = new DataClassesDataContext();
                admin_tab new_admin = new admin_tab();
                int new_id = (context.admin_tab.OrderByDescending(x => x.admin_id).FirstOrDefault()).admin_id + 1;
                new_admin.admin_id = (short)new_id;
                new_admin.admin_name = name;
                new_admin.admin_surname = surname;
                MenuAdminLogic.addAdmin(new_admin);
                MenuAdminLogic.addLogin(login, pass, "admin",isAvaible.IsChecked.Value, (short)new_id);
            }

        }
    }
}
