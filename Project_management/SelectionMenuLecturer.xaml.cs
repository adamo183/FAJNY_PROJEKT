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
    /// Logika interakcji dla klasy SelectionMenuLecturer.xaml
    /// </summary>
    public partial class SelectionMenuLecturer : Window
    {
        public SelectionMenuLecturer()
        {
            InitializeComponent();
            

        }
        public Lecturer lecturer { get; private set; }
        public SelectionMenuLecturer(Lecturer lecturer)
        {


            InitializeComponent();
            List<Tuple<int, string, string>> semsetrInfoList = new List<Tuple<int, string, string>>();

            IQueryable<SemsestrInfo> stb = MenuLecturerLogic.getSemestrInfo();
            stb.ToList();
            foreach (var rec in stb) semsetrInfoList.Add(Tuple.Create(rec.semestrid, rec.fieldofstudy.Trim(), rec.yearofstudy));

            fieldofstudybox.ItemsSource = semsetrInfoList;
            /* this.lecturer = new Lecturer();
             this.lecturer.ID_lecturer = lecturer.ID_lecturer;
             this.lecturer.Name = lecturer.Name;
             this.lecturer.Surname = lecturer.Surname;
             this.lecturer.Degree = lecturer.Degree;
               */
            this.lecturer = lecturer;

        }

        private void SML_CreateSubject_button(object sender, RoutedEventArgs e)
        {
            SML_Subject SML_Subject_window = new SML_Subject(lecturer);
            
             //this.Visibility = Visibility.Hidden;
            SML_Subject_window.Show();
        }

        private void SML_SectionManagement_button(object sender, RoutedEventArgs e)
        {
            SML_SectionManagement SML_SectionManagement_window = new SML_SectionManagement();
            //this.Visibility = Visibility.Hidden;
            SML_SectionManagement_window.Show();
        }

        private void SML_Presence_button(object sender, RoutedEventArgs e)
        {
            SML_Presence SML_Presence_window = new SML_Presence();
            //this.Visibility = Visibility.Hidden;
            SML_Presence_window.Show();
        }

        private void ComboBox_SelectionChanged()
        {

        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

            
        }

        private void ComboBox_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
