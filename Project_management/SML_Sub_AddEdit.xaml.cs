using database_layer;
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


namespace Project_management
{
    /// <summary>
    /// Logika interakcji dla klasy SML_Sub_AddEdit.xaml
    /// </summary>
    public partial class SML_Sub_AddEdit : Window
    {
        private Subject subject;
        private int mode;

        public SML_Sub_AddEdit(int mod)
        {


            InitializeComponent();
        }
        public SML_Sub_AddEdit(int mod, Subject sub)
        {
            mode = mod;
            subject = sub;
            InitializeComponent();
            view();
        }
          private void view()
          {
            if (mode == 0)
            {

                this.s_name.Text = subject.Name;
                this.Desctrip.Text = subject.Description;
                this.Availbe.IsChecked = subject.Status;
            }
          }
          

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(mode == 0)
            {
                DataClassesDataContext context = new DataClassesDataContext();
                var upd = (from s in context.Subject where s.ID_Subject == subject.ID_Subject select s).Single();
                upd.Name = s_name.Text;
                upd.Description = Desctrip.Text;
                upd.Status = (bool)Availbe.IsChecked;
                context.SubmitChanges();
                this.Close();
            }
            if(mode == 1)
            {
                if(this.s_name.Text == "" || this.Desctrip.Text == "")
                {
                    MessageBox.Show("Wypełnij wszystkie pola");
                }
                else
                {
                    subject.Description = this.Desctrip.Text;
                    subject.Name = this.s_name.Text;
                    subject.Status = (bool)this.Availbe.IsChecked;
                    bool IsAddGood = MenuLecturerLogic.addSubject(subject);
                    if(!IsAddGood)
                    {
                        MessageBox.Show("Nie udało sie dodac przedmiotu");
                    }
                    this.Close();
                }
                
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
