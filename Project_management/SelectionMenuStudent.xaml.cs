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
    /// Logika interakcji dla klasy SelectionMenuStudent.xaml
    /// </summary>
    public partial class SelectionMenuStudent : Window
    {

        public Student student { get; set; }
        public int studentSemest { get; set; }
        public SelectionMenuStudent(Student stu)
        {
            InitializeComponent();
            this.student = stu;
            topicGrid.IsReadOnly = true;
            membersgrid.IsReadOnly = true;

            topicGrid.ItemsSource = MenuStudentLogic.getSectionList(student.ID_Album);
            studentSemest = MenuStudentLogic.getStudentSemestr(student.ID_Album);
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var i = (MenuLecturerLogic.SectionDisplay)topicGrid.SelectedItem;
            if(i == null)
            {
                MessageBox.Show("Wybierz sekcje");
                return;
            }
            if(i.Max_User == membersgrid.Items.Count )
            {
                MessageBox.Show("Sekcja jest pelna");
                return;
            }
            bool isInSec = MenuStudentLogic.isStudentinSec(student.ID_Album);
            int sec_id = i.ID_sekcji;
            if (isInSec)
            {
                if (MessageBox.Show("Czy chcesz opuścić sekcje", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                {
                    return;
                }
                else
                {

                    MenuStudentLogic.removeStudFromSec(student.ID_Album);
                    MenuStudentLogic.addStudentToSec(sec_id, student.ID_Album);
                }
            }
            else
            {
                MenuStudentLogic.addStudentToSec(sec_id, student.ID_Album);
            }
        }

        private void topicGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected_sec = (MenuLecturerLogic.SectionDisplay)topicGrid.SelectedItem;
            if (selected_sec == null)
                return;
            int sec_id = selected_sec.ID_sekcji;
            membersgrid.ItemsSource = MenuLecturerLogic.getStudentInSection(sec_id);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            topicGrid.ItemsSource = MenuStudentLogic.getSectionWithCondition(studentSemest, subject_name.Text);
        }

        private void membersgrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            return;
        }
        private void membersgrid_DoubleClick(object sender, RoutedEventArgs e)
        {
            return;
        }
    }
}
