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
            SML_Stu_Add stu_add_window = new SML_Stu_Add();
            stu_add_window.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

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
            SML_AddPresence addpresence_windows = new SML_AddPresence();
            addpresence_windows.Show();
        }

        private void sectionsgrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select_row = (MenuLecturerLogic.SectionDisplay)sectionsgrid.SelectedItem;
            int seleted_secId = select_row.ID_sekcji;

            StuSecGrid.ItemsSource = MenuLecturerLogic.getStudentInSection(seleted_secId);


        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("Nic tu nie ma ");
        }
    }
}
