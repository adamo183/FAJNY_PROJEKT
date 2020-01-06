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
    /// Logika interakcji dla klasy SML_AddPresence.xaml
    /// </summary>
    public partial class SML_AddPresence : Window
    {

       public List<MenuLecturerLogic.StudentDisplay> stud_list { get; set; }
        public SML_AddPresence(List<MenuLecturerLogic.StudentDisplay> stud_list)
        {
            InitializeComponent();
            this.stud_list = stud_list; 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataClassesDataContext context = new DataClassesDataContext();
            if(Presence_calendar.SelectedDate == null)
            {
                MessageBox.Show("Wybierz datę");
                return;
            }
            if(Presence_calendar.SelectedDates.Count != 1)
            {
                MessageBox.Show("Możesz wybrać tylko jeden dzień");
                return;
            }
            int id;
            var last_id = context.Presence.OrderByDescending(x => x.ID_presence).FirstOrDefault();
            var q = (from i in context.Stu_Sec where (stud_list.Select(x => x.Id)).Contains(i.ID_Album) select i.ID_Stu_Sek).ToList();
            

            if(last_id == null)
            {
                id = 0;
            }
            else
            {
                id = last_id.ID_presence + 1;
            }
            int s = 0;
            foreach (var i in stud_list)
            {
                Presence stud_pres = new Presence() { ID_presence = (short)id, Date = (DateTime)Presence_calendar.SelectedDate, ID_Stu_Sec = q.ElementAt(s)  };
                context.Presence.InsertOnSubmit(stud_pres);
                id++;
                s++;
            }
            context.SubmitChanges();
            
        }
    }
}
