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
        public static bool checklogin(string login)
        {
            DataClassesDataContext context = new DataClassesDataContext();
            var q = (from i in context.login_tab where i.login==login select i).Count();
            if (q == 0)
            {
               
                return true;
            }
            else
            {
                MessageBox.Show("Login jest już zajety");
                return false;
            }

            
        }
        class UserIdentifiedValue
        {
            public string Role { get; private set; }
            public int Id { get; private set; }
            public UserIdentifiedValue(string role, int id)
            {
                this.Role = role;
                this.Id = id;
            }

        }
        public static bool login(string log_f, string pass_f, out string role, out int u_id)
        {



            string hash_pass = hashing.GetMd5Hash(MD5.Create(), pass_f);

            DataClassesDataContext context = new DataClassesDataContext();
            var q = from t in context.login_tab
                    where t.login == log_f &&
                    t.password == hash_pass
                    select new UserIdentifiedValue(t.role, t.u_id);

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

    public class MenuAdminLogic
    {
       
        public class UserDisplay
        {
            public int User_ID { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public bool active { get; set; }
            public string login { get; set; }
        }
       
        public static void changePassword(string new_pass,int login_id)
        {
            string pass = hashing.GetMd5Hash(MD5.Create(), new_pass);
            DataClassesDataContext context = new DataClassesDataContext();
            var q = (from i in context.login_tab where i.Id == login_id select i);
            foreach(var x in q)
            {
                x.password = pass;
            }
            context.SubmitChanges();

        }
        public static void addStuInSem(int stu_id, int sem_id)
        {
            DataClassesDataContext context = new DataClassesDataContext();
            Stu_Sem new_stu_sem = new Stu_Sem();
            new_stu_sem.ID_Stu_Sem = (short)((context.Stu_Sem.OrderByDescending(x => x.ID_Stu_Sem).FirstOrDefault()).ID_Stu_Sem + 1);
            new_stu_sem.ID_Album = (short)stu_id;
            new_stu_sem.ID_Semester = (short)sem_id;
            context.Stu_Sem.InsertOnSubmit(new_stu_sem);
            context.SubmitChanges();
            
        }
        public static void addLogin(string login,string pass,string role,bool status,short u_id)
        {
            login_tab new_log = new login_tab();
            new_log.login = login;
            new_log.password = hashing.GetMd5Hash(MD5.Create(), pass);
            new_log.role = role;
            new_log.status = status;
            new_log.u_id = u_id;
            DataClassesDataContext context = new DataClassesDataContext();
            new_log.Id = (short)((context.login_tab.OrderByDescending(u => u.Id).FirstOrDefault()).Id + 1);
            context.login_tab.InsertOnSubmit(new_log);
            context.SubmitChanges();

        }
        public static void  addLecturer(Lecturer lec)
        {
            DataClassesDataContext context = new DataClassesDataContext();
            context.Lecturer.InsertOnSubmit(lec);
            context.SubmitChanges();
        }
        public static void addStudent(Student stu)
        {
            DataClassesDataContext context = new DataClassesDataContext();
            context.Student.InsertOnSubmit(stu);
            context.SubmitChanges();
        }
        public static void addAdmin(admin_tab admin)
        {
            DataClassesDataContext context = new DataClassesDataContext();
            context.admin_tab.InsertOnSubmit(admin);
            context.SubmitChanges();
        }
        public static IQueryable<UserDisplay>  getAdminList()
        {
            DataClassesDataContext context = new DataClassesDataContext();
            var q = (from i in context.admin_tab select new { i.admin_id, i.admin_name, i.admin_surname }).Select(x => new UserDisplay() { User_ID = (from a in context.login_tab where a.u_id == x.admin_id && a.role == "admin" select a.Id).FirstOrDefault(), Name = x.admin_name, Surname = x.admin_surname, login = (from a in context.login_tab where a.u_id == x.admin_id && a.role == "admin" select a.login).FirstOrDefault(), active = (from s in context.login_tab where s.u_id == x.admin_id select s.status).FirstOrDefault() }); ;
         
            return q;
        }

        public static IQueryable<UserDisplay> getLecturerList()
        {
            DataClassesDataContext context = new DataClassesDataContext();
            var q = (from i in context.Lecturer select new { i.ID_lecturer, i.Name, i.Surname }).Select(x => new UserDisplay() { User_ID = (from a in context.login_tab where a.u_id == x.ID_lecturer && a.role == "lecturer" select a.Id).FirstOrDefault(), Name = x.Name, Surname = x.Surname, login = (from a in context.login_tab where a.u_id == x.ID_lecturer && a.role == "lecturer" select a.login).FirstOrDefault(), active = (from s in context.login_tab where s.u_id == x.ID_lecturer select s.status).FirstOrDefault() }); ;
            return q;
        }

        public static IQueryable<UserDisplay> getStudentList()
        {
            DataClassesDataContext context = new DataClassesDataContext();
            var q = (from i in context.Student select new { i.ID_Album, i.Name, i.Surname }).Select(x => new UserDisplay() { User_ID = (from a in context.login_tab where a.u_id == x.ID_Album && a.role == "student" select a.Id).FirstOrDefault(), Name = x.Name, Surname = x.Surname, login = (from a in context.login_tab where a.u_id == x.ID_Album && a.role == "student" select a.login).FirstOrDefault(), active = (from s in context.login_tab where s.u_id == x.ID_Album select s.status).FirstOrDefault() });
            return q;

        }

    }

    public class MenuStudentLogic
    {
        public static void removeStudFromSec(int id_stud)
        {
            DataClassesDataContext context = new DataClassesDataContext();
            var q = (from i in context.Presence where i.Stu_Sec.ID_Album == id_stud select i);
            var s = (from i in context.Stu_Sec where i.ID_Album == id_stud select i);
            foreach (var i in q)
                context.Presence.DeleteOnSubmit(i);
            
            foreach (var i in s)
                context.Stu_Sec.DeleteOnSubmit(i);

            context.SubmitChanges();
        }
        public static void addStudentToSec(int id_sek,int id_stud)
        {
            DataClassesDataContext context = new DataClassesDataContext();
            context.Connection.Open();
           // context.ExecuteCommand("SET IDENTITY_INSERT Stu_Sec ON");
            int last_ID = context.Stu_Sec.OrderByDescending(x => x.ID_Stu_Sek).FirstOrDefault().ID_Stu_Sek + 1;
            Stu_Sec newStuInSec = new Stu_Sec();
            newStuInSec.ID_Album = (short)id_stud;
            newStuInSec.ID_Section = (short)id_sek;
            newStuInSec.ID_Stu_Sek = (short)last_ID;
            newStuInSec.Mark = 0;
            context.Stu_Sec.InsertOnSubmit(newStuInSec);
            context.SubmitChanges();
         //   context.ExecuteCommand("SET IDENTITY_INSERT Stu_Sec OFF");

        }

        public static bool isStudentinSec(int id_student)
        {
            DataClassesDataContext context = new DataClassesDataContext();
            var q = (from i in context.Stu_Sec where i.ID_Album == id_student select i);
            if (q.Any())
                return true;
            else
                return false;

        }
        public static IQueryable<MenuLecturerLogic.SectionDisplay> getSectionWithCondition(int id_sem,string name)
        {
            DataClassesDataContext context = new DataClassesDataContext();

            if (name.Length != 0)
            {
                var q = (from i in context.Section where i.ID_Semester == id_sem && i.Subject.Name.Contains(name) select new MenuLecturerLogic.SectionDisplay() { ID_sekcji = i.ID_Section, Max_User = i.Max_user, Topic = i.Subject.Name.Trim() });
                return q;
            }
            else
            {
                var q = (from i in context.Section where i.ID_Semester == id_sem select new MenuLecturerLogic.SectionDisplay() { ID_sekcji = i.ID_Section, Max_User = i.Max_user, Topic = i.Subject.Name.Trim() });
                return q;
            }

        }
        public static IQueryable<MenuLecturerLogic.SectionDisplay> getSectionList(int id_student)
        {
            DataClassesDataContext context = new DataClassesDataContext();
            var q = (from i in context.Stu_Sem where i.ID_Album == id_student select i.ID_Semester).FirstOrDefault();
            var sec_list = (from k in context.Section where k.ID_Semester == q select new MenuLecturerLogic.SectionDisplay() { ID_sekcji = k.ID_Section, Topic = k.Subject.Name, Max_User = k.Max_user });

            return sec_list;
        }
        public static Student getStudentInfo(int id)
        {
            DataClassesDataContext context = new DataClassesDataContext();
            var q = (from i in context.Student where i.ID_Album == id select i);

            Student student = new Student();
            student.ID_Album = q.First().ID_Album;
            student.Name = q.First().Name;
            student.Surname = q.First().Surname;
            return student;
        }

        public static int getStudentSemestr(int s_id)
        {
            DataClassesDataContext context = new DataClassesDataContext();
            var q = (from i in context.Stu_Sem where i.ID_Album == s_id select i.ID_Semester).FirstOrDefault();

            return q;
        }
    }



    public class MenuLecturerLogic
    {

        public static IQueryable<SemsestrInfo> getSemestrInfo()
        {
            DataClassesDataContext context = new DataClassesDataContext();
            var st = (from s in context.Semester select new SemsestrInfo() { fieldofstudy = s.Field_of_Study, yearofstudy = s.Year, semestrid = s.ID_Semester });

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
                              
                          }).AsEnumerable().Select(x => new Lecturer
                          {
                              ID_lecturer = x.ID_lecturer,
                              Name = x.Name,
                              Surname = x.Surname,
                              Degree = x.Degree,
                              
                          }).ToList();


                return li.FirstOrDefault();
            }
            catch (Exception ex)
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
            var sub_t = (from s in context.Subject where s.ID_Lecturer.Equals(id_l) && s.Status.Equals(1) select new SubjectInfo() { Id = s.ID_Subject, Name = s.Name, Description = s.Description.Trim(), Status = (bool)s.Status });

            return sub_t;
        }
        public static IEnumerable<SubjectInfo> getAllSubjectList(int id_l)
        {
            DataClassesDataContext context = new DataClassesDataContext();
            var sub_t = (from s in context.Subject where s.ID_Lecturer.Equals(id_l) select new SubjectInfo() { Id = s.ID_Subject, Name = s.Name, Description = s.Description.Trim(), Status = (bool)s.Status });

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
            catch (Exception e)
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
            var s = (from f in context.Section where f.ID_Semester == id_sem select new SectionDisplay() { ID_sekcji = f.ID_Section, Max_User = f.Max_user, Topic = f.Subject.Name });



            return s;
        }

        public class StudentDisplay
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public short Mark { get; set; }
        }
        public static IEnumerable<StudentDisplay> getStudentInSection(int sec_id)
        {
            DataClassesDataContext context = new DataClassesDataContext();
            var sis = (from f in context.Stu_Sec where f.ID_Section == sec_id select new { f.Student.ID_Album, f.Student.Name, f.Student.Surname, f.Mark }).AsEnumerable().Select(x => new StudentDisplay() { Id = x.ID_Album, Name = x.Name, Surname = x.Surname, Mark = (short)x.Mark });

            return sis;
        }
        public static void addSection(database_layer.Section sec)
        {
            DataClassesDataContext context = new DataClassesDataContext();
            context.Section.InsertOnSubmit(sec);
            context.SubmitChanges();
        }

        public static IEnumerable<StudentDisplay> getFreeStudentInSem(Semester sem, int sec_id)
        {
            DataClassesDataContext context = new DataClassesDataContext();
            var freeStu = (from s in context.Stu_Sem where !(from s2 in context.Stu_Sec select s2.ID_Album).Contains(s.ID_Album) && (s.ID_Semester == sem.ID_Semester) select new { s.Student.ID_Album, s.Student.Name, s.Student.Surname }).AsEnumerable().Select(x => new StudentDisplay() { Id = x.ID_Album, Name = x.Name, Surname = x.Surname });


            return freeStu;
        }

        public static void addDegree(List<MenuLecturerLogic.StudentDisplay> stud_list, int degree)
        {

            DataClassesDataContext context = new DataClassesDataContext();
            (from i in context.Stu_Sec where (stud_list.Select(x => x.Id)).Contains(i.ID_Album) select i).ToList().ForEach(S => S.Mark = (short)degree);

            context.SubmitChanges();

        }
        public class PresenceDispaly
        {
            public string name { get; set; }
            public string surname { get; set; }
            public DateTime date { get; set; }
        }
            public static IQueryable getPresenceofSection(int id)
            {
                DataClassesDataContext context = new DataClassesDataContext();
                var q = (from i in context.Presence where i.Stu_Sec.ID_Section == id select new PresenceDispaly() { name = i.Stu_Sec.Student.Name, surname = i.Stu_Sec.Student.Surname, date = i.Date });
           

                return q;
            }

            public static void removeStudents(List<MenuLecturerLogic.StudentDisplay> stud_list)
            {
                DataClassesDataContext context = new DataClassesDataContext();
                var q = from i in context.Stu_Sec where (stud_list.Select(x => x.Id)).Contains(i.ID_Album) select i;
                var r = from a in context.Presence where (stud_list.Select(x => x.Id)).Contains(a.Stu_Sec.ID_Album) select a;
                foreach (var i in r)
                {
                    context.Presence.DeleteOnSubmit(i);
                }
                context.SubmitChanges();
                foreach (var i in q)
                {
                    context.Stu_Sec.DeleteOnSubmit(i);
                }
                context.SubmitChanges();
            }

            public static IQueryable<SectionDisplay> getSectionsWithCondition(int id_sem, int id_lecturer, string topic, bool NonFull)
            {
                DataClassesDataContext context = new DataClassesDataContext();
                if ((NonFull == true) && (topic.Length != 0))
                {
                    var s = (from f in context.Section where (f.ID_Semester == id_sem) && ( f.Subject.Name.Trim().Contains(topic.Trim())) && (f.Subject.ID_Lecturer == id_lecturer) && (f.Max_user > (from k in context.Stu_Sec where k.ID_Section == f.ID_Section select k).Count()) select new SectionDisplay() { ID_sekcji = f.ID_Section, Max_User = f.Max_user, Topic = f.Subject.Name });
                    return s;
                }
                else if ((NonFull == true) && (topic.Length == 0))
                {
                    var s = (from f in context.Section where (f.ID_Semester == id_sem) && (f.Subject.ID_Lecturer == id_lecturer) && (f.Max_user > (from k in context.Stu_Sec where k.ID_Section == f.ID_Section select k).Count()) select new SectionDisplay() { ID_sekcji = f.ID_Section, Max_User = f.Max_user, Topic = f.Subject.Name });
                    return s;
                }
                else if ((NonFull == false) && (topic.Length != 0))
                {
                    var s = (from f in context.Section where (f.ID_Semester == id_sem) && (f.Subject.Name.Trim().Contains(topic.Trim())) && (f.Subject.ID_Lecturer == id_lecturer) select new SectionDisplay() { ID_sekcji = f.ID_Section, Max_User = f.Max_user, Topic = f.Subject.Name });
                    return s;
                }
                else
                {
                    var s = (from f in context.Section where (f.ID_Semester == id_sem) && (f.Subject.ID_Lecturer == id_lecturer) select new SectionDisplay() { ID_sekcji = f.ID_Section, Max_User = f.Max_user, Topic = f.Subject.Name });
                    return s;
                }



            }
        }

    }

