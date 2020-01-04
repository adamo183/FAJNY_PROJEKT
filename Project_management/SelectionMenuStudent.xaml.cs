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
        public SelectionMenuStudent(Student stu)
        {
            InitializeComponent();
            this.student = stu;

            topicGrid.ItemsSource = MenuStudentLogic.getSectionList(student.ID_Album);

        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var i = (MenuLecturerLogic.SectionDisplay)topicGrid.SelectedItem;
            MessageBox.Show(i.Topic.ToString());
        }
    }
}
