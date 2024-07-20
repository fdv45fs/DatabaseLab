using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DatabaseLabProject
{
    public partial class Thông_tin_cá_nhân : Form
    {
        public Thông_tin_cá_nhân()
        {
            InitializeComponent();
        }

        SqlConnection cn = DbProtocol.cn;
        SqlCommand cmd = new SqlCommand();
        DataTable data = new DataTable();
        private void Thông_tin_cá_nhân_Load(object sender, EventArgs e)
        {
            cmd.Connection = cn;
            cmd.CommandText = "SELECT * FROM [dbo].[Lấy thông tin cá nhân] (" + MainForm.DoctorID + ")";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(data);
            textBox1.Text = data.Rows[0][0].ToString();
            textBox2.Text = data.Rows[0][1].ToString();
            dateTimePicker1.Value = DateTime.Parse(data.Rows[0][2].ToString());
            comboBox1.Text = data.Rows[0][3].ToString();
            textBox4.Text = data.Rows[0][4].ToString();
            textBox5.Text = data.Rows[0][5].ToString();
            textBox6.Text = data.Rows[0][6].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Kiểm tra thay đổi
            Boolean[] check = new Boolean[4];
            check[0] = textBox2.Text == data.Rows[0][1].ToString();
            check[1] = dateTimePicker1.Value == DateTime.Parse(data.Rows[0][2].ToString());
            check[2] = comboBox1.Text == data.Rows[0][3].ToString();
            check[3] = textBox4.Text == data.Rows[0][4].ToString();
            if (check[0] && check[1] && check[2] && check[3])
            {
                MessageBox.Show("Không có thay đổi nào được thực hiện");
                return;
            }

            //Cập nhật dữ liệu
            StringBuilder query = new StringBuilder("UPDATE [dbo].[Bác sĩ] SET ");
            if (!check[0])
            {
                query.Append("[Tên bác sĩ] = N'" + textBox2.Text + "', ");
            }
            if (!check[1])
            {
                query.Append("[Ngày sinh] = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "', ");
            }
            if (!check[2])
            {
                query.Append("[Giới tính] = N'" + comboBox1.Text + "', ");
            }
            if (!check[3])
            {
                query.Append("[Số điện thoại] = '" + textBox4.Text + "', ");
            }
            query.Remove(query.Length - 2, 2);
            query.Append(" WHERE [Mã bác sĩ] = " + textBox1.Text);
            try
            {
                cmd.CommandText = query.ToString();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thông tin thành công");
            }
            catch
            {
                MessageBox.Show("Cập nhật thông tin thất bại");
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
