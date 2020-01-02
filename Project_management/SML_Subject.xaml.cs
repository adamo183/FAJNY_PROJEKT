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
    /// Logika interakcji dla klasy SML_Subject.xaml
    /// </summary>
    public partial class SML_Subject : Window
    {

        public Lecturer lecturer { get;private set; }
        public SML_Subject(Lecturer lecturer)
        {
            InitializeComponent();
            this.lecturer = lecturer;
            IEnumerable<MenuLecturerLogic.SubjectInfo> tab_s = MenuLecturerLogic.getSubjectList(lecturer.ID_lecturer);
            subject_grid.IsReadOnly = true;
            subject_grid.ItemsSource = tab_s;
            //subject_grid
        }
        
       
        private void SML_Sub_EditButton(object sender, RoutedEventArgs e)
        {


            if (subject_grid.SelectedItem != null )
            {
                var row_list = (MenuLecturerLogic.SubjectInfo)subject_grid.SelectedItem;
                string name = row_list.Name;
                //MessageBox.Show(name);
                Subject s1 = new Subject();
                s1.ID_Subject = (short)row_list.Id;
                s1.Name = row_list.Name;
                s1.Description = row_list.Description;
                s1.ID_Lecturer = lecturer.ID_lecturer;
                s1.Status = row_list.Status;

                SML_Sub_AddEdit SML_Sub_AddEdit_window = new SML_Sub_AddEdit(0, s1);
                this.Visibility = Visibility.Hidden;

                SML_Sub_AddEdit_window.Show();
            }
            else
            {
                MessageBox.Show("Wybierz coś");
            }
        }
        private void SML_Sub_AddSubjectButton(object sender, RoutedEventArgs e) 
        {

            Subject s1 = new Subject();
            s1.ID_Lecturer = lecturer.ID_lecturer;
            SML_Sub_AddEdit SML_Sub_AddEdit_window = new SML_Sub_AddEdit(1,s1);
            


           this.Visibility = Visibility.Hidden;
           SML_Sub_AddEdit_window.Show();
        }

        private void subject_grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
