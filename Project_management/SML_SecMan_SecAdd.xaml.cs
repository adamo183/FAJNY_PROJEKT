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

        public class SubjectComboShow
        {
            public int id_s { get; set; }
            public string name { get; set; }
        }
        public SML_SecMan_SecAdd(Lecturer lecturer, Semester semester)
        {
            InitializeComponent();
            this.lecturer = lecturer;
            this.semester = semester;

            var sub_list = MenuLecturerLogic.getSubjectList(lecturer.ID_lecturer).ToList();
            List<Tuple<int, string>> topic_list = new List<Tuple<int, string>>();
            foreach (var rec in sub_list) topic_list.Add(Tuple.Create(rec.Id, rec.Name.Trim()));
            Topiccombobox.ItemsSource = topic_list; 


        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Tuple<int, string> selected_sub = (Tuple<int, string>)Topiccombobox.SelectedItem;
            if (selected_sub == null)
            {
                MessageBox.Show("Wybierz temat");
                return;
            }

            string capa = Capacity_field.Text;
            bool capaIsNumber = true;
            for (int i = 0; i < capa.Length; i++)
            {
                if (!char.IsDigit(capa, i))
                {
                    MessageBox.Show("Rozmiar sekcji nie jest liczbą");
                    capaIsNumber = false;
                    break;
                }
            }
            if ((selected_sub != null) || (!capaIsNumber))
            {
                int capa_numb = Int32.Parse(capa);
                database_layer.Section sec = new database_layer.Section();
                sec.ID_Semester = semester.ID_Semester;
                sec.Max_user = (short)capa_numb;
                sec.ID_Subject = (short)selected_sub.Item1;
                DataClassesDataContext context = new DataClassesDataContext();
                var s = context.Section.OrderByDescending(se => se.ID_Section).FirstOrDefault();
                sec.ID_Section = (short)(s.ID_Section + 1);
                MenuLecturerLogic.addSection(sec);

            }
            this.Close();
        }
    }
}
 