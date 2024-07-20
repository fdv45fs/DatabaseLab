using System.Data;
using System.Data.SqlClient;

namespace DatabaseLabProject
{
    public partial class Quản_lý_xét_nghiệm : Form
    {
        SqlConnection cn = DbProtocol.cn;
        SqlCommand cmd = new SqlCommand();
        DataTable test = new DataTable();
        public Quản_lý_xét_nghiệm()
        {
            InitializeComponent();
        }

        private void UpdateTestList1()
        {
            cmd.CommandText = "dbo.[Lấy xét nghiệm máu]";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            test = new DataTable();
            da.Fill(test);
            dataGridView1.DataSource = test;
        }
        private void UpdateTestList2()
        {
            cmd.CommandText = "dbo.[Lấy xét nghiệm nước tiểu]";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            test = new DataTable();
            da.Fill(test);
            dataGridView2.DataSource = test;
        }
        private void Quản_lý_xét_nghiệm_Load(object sender, EventArgs e)
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

            timer1.Start();
            cmd.Connection = cn;
            UpdateTestList1();
            UpdateTestList2();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("Chưa chọn xét nghiệm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (textBox5.Text == "" && textBox6.Text == "" && textBox7.Text == "")
            {
                MessageBox.Show("Chưa nhập thông tin xét nghiệm");
            }
            else
            {
                try
                {
                    cmd.CommandText = "BEGIN UPDATE dbo.[Xét nghiệm máu] SET Glucose = " + textBox5.Text + ", [Số lượng hồng cầu] = " + textBox6.Text + ", [Nhóm máu] = '" + textBox7.Text.ToUpper() + "' WHERE [Mã xét nghiệm] = " + textBox3.Text + " UPDATE dbo.[Xét nghiệm] SET [Mã bác sĩ] = " + MainForm.DoctorID + ", [Thời gian] = '" + DateTime.Now + "', [Ghi chú] = N'" + textBox4.Text + "' WHERE [Mã xét nghiệm] = " + textBox3.Text + " END";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                    UpdateTestList1();
                }
                catch
                {
                    MessageBox.Show("Không thể cập nhật thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow != null)
            {
                textBox10.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                textBox11.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                textBox9.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox10.Text == "")
            {
                MessageBox.Show("Chưa chọn xét nghiệm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (textBox8.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("Chưa nhập thông tin xét nghiệm");
            }
            else
            {
                cmd.CommandText = "BEGIN UPDATE dbo.[Xét nghiệm nước tiểu] SET Glucose = " + textBox8.Text + ", pH = " + textBox2.Text + " WHERE [Mã xét nghiệm] = " + textBox11.Text + " UPDATE dbo.[Xét nghiệm] SET [Mã bác sĩ] = " + MainForm.DoctorID + ", [Thời gian] = '" + DateTime.Now + "', [Ghi chú] = N'" + textBox9.Text + "' WHERE [Mã xét nghiệm] = " + textBox11.Text + " END";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                UpdateTestList2();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                UpdateTestList1();
            }
            else
            {
                UpdateTestList2();
            }
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
            R = 1;
            this.Close();
        }

        private void xửLýBệnhÁnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            R = 9;
            this.Close();
        }

        private void quảnLýXétNghiệmToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
