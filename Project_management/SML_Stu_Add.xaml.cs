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
    /// Logika interakcji dla klasy SML_Stu_Add.xaml
    /// </summary>
    public partial class SML_Stu_Add : Window
    {

        public Semester semester { get; private set; }
        public MenuLecturerLogic.SectionDisplay selected_sec { get; private set; }
        public int free_space { get; set; }
        public SML_Stu_Add(Semester sems , MenuLecturerLogic.SectionDisplay selected_sec,int studentinsecnumber)
        {
            InitializeComponent();
            this.semester = sems;
            this.selected_sec = selected_sec;
            free_space = selected_sec.Max_User - studentinsecnumber;
            StudentGrid.ItemsSource = MenuLecturerLogic.getFreeStudentInSem(semester,selected_sec.ID_sekcji);
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string Name_con = Name_condition.Text;
            string Surname_con = SurName_condition.Text;

            if (Name_con.Length == 0 && Surname_con.Length == 0)
            {
                MessageBox.Show("Wyplenij przynajmniej jedno z pol");
            }
            else if (Name_con.Length != 0 && Surname_con.Length == 0)
            {
                StudentGrid.ItemsSource = MenuLecturerLogic.getFreeStudentInSem(semester, selected_sec.ID_sekcji).Where(x=>x.Name.Trim() == Name_con.Trim());
            }
            else if (Surname_con.Length != 0 && Name_con.Length == 0)
            {
                StudentGrid.ItemsSource = MenuLecturerLogic.getFreeStudentInSem(semester, selected_sec.ID_sekcji).Where(x=>x.Surname.Trim() == Surname_con.Trim());
            }
            else if (Surname_con.Length != 0 && Name_con.Length != 0)
            {
                StudentGrid.ItemsSource = MenuLecturerLogic.getFreeStudentInSem(semester, selected_sec.ID_sekcji).Where(x=>x.Surname.Trim() == Surname_con.Trim() && x.Name.Trim() == Name_con.Trim());
            }
            else
                MessageBox.Show("Samfing is not yes :(");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var selected_student = StudentGrid.SelectedItems;
            
            if(selected_student.Count == 0)
            {
                MessageBox.Show("Wybierz studentów");
                return;
            }
            if(selected_student.Count > free_space)
            {
                MessageBox.Show("Do tej sekcji nie można dodać tylko " + free_space.ToString() + " studenta");
                return;
            }

            DataClassesDataContext context = new DataClassesDataContext();
            context.Connection.Open();
            //context.ExecuteCommand("SET IDENTITY_INSERT Stu_Sec ON");
            int last_ID = context.Stu_Sec.OrderByDescending(x => x.ID_Stu_Sek).FirstOrDefault().ID_Stu_Sek+1;

            var list = new List<Stu_Sec>();
            int list_nr = 0;
            foreach(var i in selected_student)
            {
                var atcStd = (MenuLecturerLogic.StudentDisplay)i;
                list.Add(new Stu_Sec() { ID_Stu_Sek = (short)last_ID, Mark = 0, ID_Album = (short)atcStd.Id,ID_Section = (short)selected_sec.ID_sekcji });
                last_ID++;
                context.Stu_Sec.InsertOnSubmit(list.ElementAt(list_nr));
                list_nr++;
            }
            context.SubmitChanges();
            this.Close();
            //context.ExecuteCommand("SET IDENTITY_INSERT Stu_Sec OFF");
        }
    }
}
