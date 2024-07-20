using System.Data;
using System.Data.SqlClient;

namespace DatabaseLabProject
{
    public partial class Tiếp_Đón_Bệnh_Nhân : Form
    {
        SqlConnection cn = DbProtocol.cn;
        SqlCommand cmd = new SqlCommand();
        DataTable Patients = new DataTable();
        DataTable Doctors = new DataTable();
        public Tiếp_Đón_Bệnh_Nhân()
        {
            InitializeComponent();
        }

        private void UpdatePatients()
        {
            Patients.Clear();
            cmd.CommandText = "dbo.[Lấy danh sách bệnh nhân]";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(Patients);
            Patients.PrimaryKey = new DataColumn[] { Patients.Columns[0] };

            comboBox1.DataSource = Patients;
            comboBox1.ValueMember = "Mã bệnh Nhân";
            comboBox1.DisplayMember = "Mã bệnh Nhân";

            comboBox2.DataSource = Patients;
            comboBox2.ValueMember = "Mã bệnh Nhân";
            comboBox2.DisplayMember = "Họ và Tên";
        }

        private void Tiếp_Đón_Bệnh_Nhân_Load(object sender, EventArgs e)
        {
            Boolean[] permission = DbProtocol.GetPermission(MainForm.Permission);
            if (!permission[0])
            {
                tiếpĐónBệnhNhânToolStripMenuItem.Enabled = false;
                xửLýBệnhÁnToolStripMenuItem.Enabled = false;
            }
            if (!permission[1])
            {
                quảnLýThuốcToolStripMenuItem.Enabled = false;
            }
            if (!permission[2])
            {
                quảnLýXétNghiệmToolStripMenuItem.Enabled = false;
            }

            cmd.Connection = cn;
            UpdatePatients();
           
            cmd.CommandText = "dbo.[Lấy danh sách bác sĩ]";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(Doctors);
            comboBox5.DataSource = Doctors;
            comboBox5.ValueMember = "Mã bác sĩ";
            comboBox5.DisplayMember = "Mã bác sĩ";

            comboBox4.DataSource = Doctors;
            comboBox4.ValueMember = "Mã bác sĩ";
            comboBox4.DisplayMember = "Tên bác sĩ";

            comboBox1.SelectedIndex = -1;
            comboBox2.Text = "";
            textBox4.Text = "";
            textBox2.Text = "";
            textBox1.Text = "";
            textBox3.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            comboBox3.Text = "";
        }

        private Boolean CheckPatientInfoChange()
        {
            DataRow row = Patients.Rows.Find(comboBox1.SelectedValue);
            return comboBox2.Text != row["Họ và Tên"].ToString() || textBox1.Text != row["Số BHYT"].ToString() || dateTimePicker1.Value != (DateTime)row["Ngày sinh"] || comboBox3.Text != row["Giới tính"].ToString() || textBox2.Text != row["Số điện thoại"].ToString() || textBox3.Text != row["Thuốc dị ứng"].ToString() || textBox4.Text != row["Bệnh lý đặc biệt"].ToString();
        }

        string Tái_khám = "NULL";
        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                cmd.CommandText = "SELECT dbo.[Kiểm tra bệnh nhân] (N'" + comboBox2.Text + "', '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "')";
                if ((int)cmd.ExecuteScalar() != 0)
                {
                    if (MessageBox.Show("Bệnh nhân " + comboBox2.Text + " đã có trong cơ sở dữ liệu. Thêm mới bệnh nhân này?", "Hồ sơ đã tồn tại", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                        return;
                }    
                cmd.CommandText = "INSERT INTO dbo.[Bệnh Nhân] ([Họ và Tên], [Số BHYT], [Ngày sinh], [Giới tính], [Số điện thoại], [Thuốc dị ứng], [Bệnh lý đặc biệt]) OUTPUT INSERTED.[Mã bệnh nhân] VALUES (N'" + comboBox2.Text + "', '" + textBox1.Text + "', '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "', N'" + comboBox3.Text + "', '" + textBox2.Text + "', N'" + textBox3.Text + "', N'" + textBox4.Text + "')";
                int Mã_bệnh_nhân = (int)cmd.ExecuteScalar();
                UpdatePatients();
                comboBox2.SelectedValue = Mã_bệnh_nhân;
            }
            else if (CheckPatientInfoChange())
            {
                cmd.CommandText = "UPDATE dbo.[Bệnh Nhân] SET [Số BHYT] = '" + textBox1.Text + "', [Họ và Tên] = N'" + comboBox2.Text + "', [Ngày sinh] = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "', [Giới tính] = N'" + comboBox3.Text + "', [Số điện thoại] = N'" + textBox2.Text + "', [Thuốc dị ứng] = N'" + textBox3.Text + "', [Bệnh lý đặc biệt] = N'" + textBox4.Text + "' WHERE [Mã Bệnh Nhân] = " + comboBox1.SelectedValue;
                cmd.ExecuteNonQuery();
                UpdatePatients();
            }
            try
            {
                cmd.CommandText = "INSERT INTO dbo.[Hồ sơ bệnh án] ([Mã bệnh nhân], [Mã bác sĩ], [Ngày khám], [Tình trạng hiện tại], [Nhiệt độ], [Huyết áp], [Tái khám]) VALUES ('" + comboBox1.SelectedValue + "', '" + comboBox5.SelectedValue + "', GETDATE(), N'" + textBox5.Text + "', " + textBox7.Text + ", " + textBox8.Text + ", " + Tái_khám + ")";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm bệnh án thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                textBox1.Text = "";
                dateTimePicker1.Value = DateTime.Now;
                comboBox3.SelectedIndex = -1;
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
            }
            catch
            {
                MessageBox.Show("Không thể thêm bệnh án", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboBox1.SelectedValue = comboBox2.SelectedValue;
                DataRow row = Patients.Rows.Find(comboBox1.SelectedValue);
                textBox1.Text = row["Số BHYT"].ToString();
                dateTimePicker1.Value = (DateTime)row["Ngày sinh"];
                comboBox3.Text = row["Giới tính"].ToString();
                textBox2.Text = row["Số điện thoại"].ToString();
                textBox3.Text = row["Thuốc dị ứng"].ToString();
                textBox4.Text = row["Bệnh lý đặc biệt"].ToString();
                Tái_khám = "NULL";
            }
            catch
            { }
        }

        private void comboBox2_TextUpdate(object sender, EventArgs e)
        {
            if (comboBox2.Text == "")
            {
                comboBox1.SelectedIndex = -1;
                textBox1.Text = "";
                dateTimePicker1.Value = DateTime.Now;
                comboBox3.SelectedIndex = -1;
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                Tái_khám = "NULL";
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboBox5.SelectedIndex = comboBox4.SelectedIndex;
            }
            catch
            { }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboBox4.SelectedIndex = comboBox5.SelectedIndex;
            }
            catch
            { }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Danh_sách_bác_sĩ danh_Sách_Bác_Sĩ = new Danh_sách_bác_sĩ(comboBox5, Doctors);
            danh_Sách_Bác_Sĩ.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
                return;
            DataTable Patient = new DataTable();
            cmd.CommandText = "SELECT [Hồ sơ bệnh án].[Mã bệnh án], [Bệnh nhân].[Họ và tên] AS N'Họ và tên bệnh nhân', [Bác sĩ].[Tên bác sĩ] AS N'Họ và tên bác sĩ', CONVERT(VARCHAR, [Hồ sơ bệnh án].[Ngày khám], 103) AS N'Ngày khám', [Hồ sơ bệnh án].[Tình trạng hiện tại], [Hồ sơ bệnh án].[Nhiệt độ], [Hồ sơ bệnh án].[Huyết áp], [Hồ sơ bệnh án].[Đơn thuốc], [Hồ sơ bệnh án].[Tái khám] FROM [Hồ sơ bệnh án] JOIN [Bác sĩ] ON [Hồ sơ bệnh án].[Mã bác sĩ] = [Bác sĩ].[Mã bác sĩ] JOIN [Bệnh nhân] ON [Hồ sơ bệnh án].[Mã bệnh nhân] = [Bệnh nhân].[Mã bệnh nhân] WHERE [Bệnh nhân].[Mã bệnh nhân] = " + comboBox1.SelectedValue + " AND NOT ([Hồ sơ bệnh án].[Mã bệnh án] IN (SELECT [Tái khám] FROM [Hồ sơ bệnh án] WHERE [Tái khám] IS NOT NULL))";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(Patient);
            Danh_sách_bệnh_án danh_Sách_Bệnh_Án = new Danh_sách_bệnh_án(Patient);
            danh_Sách_Bệnh_Án.ShowDialog();
            Tái_khám = danh_Sách_Bệnh_Án.Result;
            textBox6.Text = Tái_khám == "NULL" ? "Không" : "Mã hồ sơ: " + Tái_khám;
        }
        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thông_tin_cá_nhân thông_Tin_Cá_Nhân = new Thông_tin_cá_nhân();
            thông_Tin_Cá_Nhân.Show();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Đổi_mật_khẩu đổi_Mật_Khẩu = new Đổi_mật_khẩu();
            đổi_Mật_Khẩu.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.Delete(Application.StartupPath + "\\user.txt");
            R = 0;
            this.Close();
        }

        private void tiếpĐónBệnhNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void xửLýBệnhÁnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            R = 9;
            this.Close();
        }

        private void quảnLýXétNghiệmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            R = 4;
            this.Close();
        }

        private void quảnLýThuốcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            R = 2;
            this.Close();
        }

        private void cơSởDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            R = 10;
            this.Close();
        }

        int R;
        public int ReturnResult
        {
            get { return R; }
        }
    }
}
