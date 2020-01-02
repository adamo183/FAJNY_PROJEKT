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
    /// Logika interakcji dla klasy SML_SecMan_SecAdd.xaml
    /// </summary>
    /// 
    
    
    public partial class SML_SecMan_SecAdd : Window
    {
        public Lecturer lecturer;
        public Semester semester;
        public SML_SecMan_SecAdd(Lecturer lecturer,Semester semester)
        {
            InitializeComponent();
            this.lecturer = lecturer;
            this.semester = semester;

            Topiccombobox.ItemsSource = MenuLecturerLogic.getSubjectList(lecturer.ID_lecturer);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
 