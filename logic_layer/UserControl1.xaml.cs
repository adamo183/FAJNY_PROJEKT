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

}
