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
        public SML_Stu_Add(Semester sems )
        {
            InitializeComponent();
            this.semester = sems;
            StudentGrid.ItemsSource = MenuLecturerLogic.getFreeStudentInSem(semester);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
