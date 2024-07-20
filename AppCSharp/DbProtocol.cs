using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace DatabaseLabProject
{
    internal class DbProtocol
    {
        public static SqlConnection cn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ADMIN\\Desktop\\DatabaseLabProject\\DBLabProjectDB.mdf;Integrated Security=True");
        public static string Encrypt(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] btr = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder sb = new StringBuilder();
            foreach (byte bt in btr)
            {
                sb.Append(bt.ToString("x2"));
            }
            return sb.ToString();
        }

        public static Boolean[] GetPermission(int Permission)
        {
            Boolean[] result = new Boolean[3];
            for (int i=0; i<3; i++)
            {
                result[i] = (Permission % 2) != 0;
                Permission /= 2;
            }
            return result;
        }
    }
}
