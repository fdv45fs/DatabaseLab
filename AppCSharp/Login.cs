using System.Data.SqlClient;

namespace DatabaseLabProject
{
    public partial class Login : Form
    {
        static Boolean Check = true;
        SqlConnection cn = DbProtocol.cn;
        SqlCommand cmd = new SqlCommand();
        public Login()
        {
            InitializeComponent();
        }

        private int CheckLogin(string username, string password)
        {
            textBox1.Text = username;
            cmd.CommandText = "SELECT dbo.[Kiểm tra đăng nhập](" + username + ", '" + password + "')";
            object result = cmd.ExecuteScalar();
            try 
            {
                return (int)result;
            }
            catch
            {
                return -1;
            }
        }
        private void Login_Load(object sender, EventArgs e)
        {
            cmd.Connection = cn;
            if (Check)
            {
                if (File.Exists(Application.StartupPath + "\\user.txt"))
                {
                    string[] lines = File.ReadAllLines(Application.StartupPath + "\\user.txt");
                    R = CheckLogin(lines[0], lines[1]);
                    if (R != -1)
                    {
                        this.Close();
                    }
                }
                Check = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string password = DbProtocol.Encrypt(textBox2.Text);
            R = CheckLogin(textBox1.Text, password);
            if (R != -1)
            {
                MessageBox.Show("Đăng nhập thành công");
                if (checkBox1.Checked)
                {
                    File.WriteAllText(Application.StartupPath + "\\user.txt", textBox1.Text + "\n" + password);
                }
                else
                {
                    File.Delete(Application.StartupPath + "\\user.txt");
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Mã bác sĩ hoặc mật khẩu không đúng");
            }
        }
        
        int R = -1;
        public int ReturnResult
        {
            get { return R; }
        }
        public string DoctorID
        {
            get { return textBox1.Text; }
        }
    }
}
