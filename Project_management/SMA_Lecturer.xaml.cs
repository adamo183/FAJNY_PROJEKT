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
using System.Windows.Navigation;
using System.Windows.Shapes;
using database_layer;
using logic_layer;

namespace Project_management
{
    /// <summary>
    /// Logika interakcji dla klasy SMA_Lecturer.xaml
    /// </summary>
    public partial class SMA_Lecturer : Page
    {
        public Lecturer lecturer { get; private set; }
        public SMA_Lecturer()
        {
            InitializeComponent();
            this.lecturer = lecturer;
            //IQueryable tab_l = MenuLecturerLogic.getSubjectList(lecturer.ID_lecturer);
            //Lecturer_Grid.IsReadOnly = true;
            //Lecturer_Grid.ItemsSource = tab_l;
        }
    }
}
