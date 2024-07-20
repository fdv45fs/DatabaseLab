using System.Data.SqlClient;

namespace DatabaseLabProject
{
    public partial class Đổi_mật_khẩu : Form
    {
        public Đổi_mật_khẩu()
        {
            InitializeComponent();
        }

        SqlConnection cn = DbProtocol.cn;
        SqlCommand cmd = new SqlCommand();
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Mật khẩu mới không được để trống");
                return;
            }
            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Mật khẩu mới không khớp");
                return;
            }
            cmd.CommandText = "SELECT dbo.[Kiểm tra đăng nhập]('" + MainForm.DoctorID + "', '" + DbProtocol.Encrypt(textBox1.Text) + "')";
            int result = 0;
            try
            {
                result = (int)cmd.ExecuteScalar();
            }
            catch
            { }
            if (result != 0)
            {
                if (textBox2.Text == textBox3.Text)
                {
                    cmd.CommandText = "UPDATE [dbo].[Bác sĩ] SET [Mật khẩu] = '" + DbProtocol.Encrypt(textBox2.Text) + "' WHERE [Mã bác sĩ] = " + MainForm.DoctorID;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đổi mật khẩu thành công");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra, vui lòng thử lại sau");
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu cũ không đúng");
            }
        }

        private void Đổi_mật_khẩu_Load(object sender, EventArgs e)
        {
            cmd.Connection = cn;
        }
    }
}
