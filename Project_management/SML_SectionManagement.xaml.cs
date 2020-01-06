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
    /// Logika interakcji dla klasy SML_SectionManagement.xaml
    /// </summary>
    public partial class SML_SectionManagement : Window
    {
        public int max_user { get; set; }
        public Lecturer lecturer { get; private set; }
        public Semester semestr { get; private set; }
        public SML_SectionManagement(Lecturer lecturer,Semester sem)
        {
            InitializeComponent();

            this.lecturer = lecturer;
            this.semestr = sem;
            sectionsgrid.IsReadOnly = true;
            sectionsgrid.ItemsSource = MenuLecturerLogic.getSection(sem.ID_Semester);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sectionsgrid.SelectedItem == null)
            {
                MessageBox.Show("Wynierz sekcje!");
                return;
            }

            int current_user_number = StuSecGrid.Items.Count;
            if (max_user == current_user_number)
            {
                MessageBox.Show("Ta sekcja jest pełna");
                return;
            }

            MenuLecturerLogic.SectionDisplay selected_secion = (MenuLecturerLogic.SectionDisplay)sectionsgrid.SelectedItem;
            SML_Stu_Add stu_add_window = new SML_Stu_Add(semestr,selected_secion, current_user_number);
            stu_add_window.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            var selected_student = StuSecGrid.SelectedItems ;
            List<MenuLecturerLogic.StudentDisplay> stud_list = new List<MenuLecturerLogic.StudentDisplay>();

            foreach(var i in selected_student)
            {
                var single_stud = (MenuLecturerLogic.StudentDisplay)i;
                stud_list.Add(single_stud);
            }
            if(selected_student.Count == 0)
            {
                MessageBox.Show("Wybierz studentów");
                return;
            }
            if((Degree_field.Text.Length != 1) || !(char.IsDigit(Degree_field.Text.ElementAt(0))) || (Int32.Parse(Degree_field.Text))> 6 )
            {
                MessageBox.Show("Błędna ocena");
                return;
            }
            int degree = Int32.Parse(Degree_field.Text);
            MenuLecturerLogic.addDegree(stud_list, degree);


        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SML_SecMan_SecAdd SML_SecMan_SecAdd_window = new SML_SecMan_SecAdd(lecturer,semestr);
            SML_SecMan_SecAdd_window.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            SML_Presence precence_window = new SML_Presence();
            precence_window.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var selected_student = StuSecGrid.SelectedItems;
            List<MenuLecturerLogic.StudentDisplay> stud_list = new List<MenuLecturerLogic.StudentDisplay>();

            foreach (var i in selected_student)
            {
                var single_stud = (MenuLecturerLogic.StudentDisplay)i;
                stud_list.Add(single_stud);
            }
            if (selected_student.Count == 0)
            {
                MessageBox.Show("Wybierz studentów");
                return;
            }



            SML_AddPresence addpresence_windows = new SML_AddPresence(stud_list);
            addpresence_windows.Show();
        }

        private void sectionsgrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select_row = (MenuLecturerLogic.SectionDisplay)sectionsgrid.SelectedItem;
            int seleted_secId = select_row.ID_sekcji;
            max_user = select_row.Max_User;
            var tab_source = MenuLecturerLogic.getStudentInSection(seleted_secId);
            StuSecGrid.ItemsSource = tab_source;


        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            return;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            var selected_student = StuSecGrid.SelectedItems;
            List<MenuLecturerLogic.StudentDisplay> stud_list = new List<MenuLecturerLogic.StudentDisplay>();

            foreach (var i in selected_student)
            {
                var single_stud = (MenuLecturerLogic.StudentDisplay)i;
                stud_list.Add(single_stud);
            }
            if (selected_student.Count == 0)
            {
                MessageBox.Show("Wybierz studentów");
                return;
            }
            MenuLecturerLogic.removeStudents(stud_list);
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            string topic_field = SecTopField.Text;
            bool nonFull_field = (bool)NonFullField.IsChecked;
            MenuLecturerLogic.getSectionsWithCondition(semestr.ID_Semester, topic_field, nonFull_field);


        }
    }
}
