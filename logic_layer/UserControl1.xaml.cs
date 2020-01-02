using System;
using System.Security.Cryptography;
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

namespace logic_layer
{
    /// <summary>
    /// Logika interakcji dla klasy UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
    }

    [System.Runtime.InteropServices.ComVisible(true)]
    public abstract class hashing : System.Security.Cryptography.HashAlgorithm
    {
        static public string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        static public bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class Login
    {
        class UserIdentifiedValue
        {
            public string Role { get;private set; }
            public int Id { get;private set; }
            public UserIdentifiedValue(string role , int id)
            {
                this.Role = role;
                this.Id = id;
            }

        }
        public static bool login(string log_f, string pass_f,out string role,out int u_id)
        {

           
            
            string hash_pass = hashing.GetMd5Hash( MD5.Create(), pass_f);
            
            DataClassesDataContext context = new DataClassesDataContext();
            var q = from t in context.login_tab
                    where t.login == log_f &&
                    t.password == hash_pass
                    select new UserIdentifiedValue(t.role,t.u_id);

            u_id = 0;
            role = "";

           
            if (q.Count() == 1)
            {
                foreach (var c in q)
                {
                    role = c.Role;
                    u_id = c.Id;
                }
            }

            
            return (q.Count() == 1);


        }
    }


    public class SemsestrInfo
    {
        public int semestrid { get; set; }
        public string fieldofstudy { get; set; }
        public string yearofstudy { get; set; }
    }
    public class MenuLecturerLogic
    {

        public static IQueryable<SemsestrInfo> getSemestrInfo()
        {
            DataClassesDataContext context = new DataClassesDataContext();
            var st = (from s in context.Semester select new SemsestrInfo() { fieldofstudy = s.Field_of_Study, yearofstudy = s.Year ,semestrid = s.ID_Semester}); 

            return st;
        }
        public static Lecturer getLectuterData(int id)
        {
            try
            {
                DataClassesDataContext context = new DataClassesDataContext();
                var li = (from l in context.Lecturer
                         where l.ID_lecturer.Equals(id)
                         select new 
                         {

                             ID_lecturer = l.ID_lecturer,
                             Name = l.Name,
                             Surname = l.Surname,
                             Degree = l.Degree,
                             active = l.active
                         }).AsEnumerable().Select( x => new Lecturer {
                             ID_lecturer = x.ID_lecturer,
                             Name = x.Name,
                             Surname = x.Surname,
                             Degree = x.Degree,
                             active = x.active
                         } ).ToList();

                
                return li.FirstOrDefault();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public class SubjectInfo
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public int Id { get; set; }
            public bool Status { get; set; }

        }
        public static IEnumerable<SubjectInfo> getSubjectList(int id_l)
        {
            DataClassesDataContext context = new DataClassesDataContext();
            var sub_t = (from s in context.Subject where s.ID_Lecturer.Equals(id_l) select new SubjectInfo() {Id = s.ID_Subject,Name = s.Name,Description = s.Description.Trim(),Status = s.Status });
    



            return sub_t;  
        }
        public static bool addSubject(Subject s1)
        {
            DataClassesDataContext context = new DataClassesDataContext();
            var f = context.Subject.OrderByDescending(u => u.ID_Subject).FirstOrDefault();
            s1.ID_Subject = (short)(f.ID_Subject + 1);
            context.Connection.Open();
            context.ExecuteCommand("SET IDENTITY_INSERT Subject ON");
            context.Subject.InsertOnSubmit(s1);
            try
            {
                context.SubmitChanges();
                context.ExecuteCommand("SET IDENTITY_INSERT Subject OFF");
                return true;

            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }

            
        }

        public class SectionDisplay
        {
            public int ID_sekcji { get; set; }
            public int Max_User { get; set; }
            public string Topic { get; set; }


        }
        public static IQueryable getSection(int id_sem)
        {

            DataClassesDataContext context = new DataClassesDataContext();
            var s = (from f in context.Section where f.ID_Semester == id_sem select new SectionDisplay() { ID_sekcji = f.ID_Section, Max_User = f.Max_user , Topic = f.Subject.Name  });



            return s;
        }

        public class StudentDisplay
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
        }
        public static IEnumerable<StudentDisplay> getStudentInSection(int sec_id)
        {
            DataClassesDataContext context = new DataClassesDataContext();
            var sis = (from f in context.Stu_Sec where f.ID_Section == sec_id select new {f.Student.ID_Album, f.Student.Name, f.Student.Surname }).AsEnumerable().Select(x => new StudentDisplay() {Id = x.ID_Album,Name = x.Name,Surname = x.Surname }); 

            return sis;
        }
        public static void addSection(database_layer.Section sec)
        {
            DataClassesDataContext context = new DataClassesDataContext();
            context.Section.InsertOnSubmit(sec);
            context.SubmitChanges();
        }

        public static IEnumerable<Stu_Sem> getFreeStudentInSem(Semester sem)
        {
            DataClassesDataContext context = new DataClassesDataContext();
            var freeStu = from s in context.Stu_Sem where !(from s2 in context.Stu_Sec select s2.ID_Album).Contains(s.ID_Album) select s;


            return freeStu;
        }
    }

}
