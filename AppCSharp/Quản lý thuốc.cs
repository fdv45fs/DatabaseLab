using System.Data;
using System.Data.SqlClient;

namespace DatabaseLabProject
{
    public partial class Quản_lý_thuốc : Form
    {
        SqlConnection cn = DbProtocol.cn;
        SqlCommand cmd = new SqlCommand();
        DataTable MedicineList = new DataTable();
        DataTable Warehouse = new DataTable();

        private void UpdateMedicineList()
        {
            cmd.CommandText = "dbo.[Lấy danh mục thuốc]";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            MedicineList.Clear();
            da.Fill(MedicineList);
            dataGridView1.DataSource = MedicineList;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            Mã_thuốc = "";
            textBox1.Focus();
        }
        public Quản_lý_thuốc()
        {
            InitializeComponent();
        }

        private void Quản_lý_thuốc_Load(object sender, EventArgs e)
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
            UpdateMedicineList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.CommandText = "INSERT INTO [dbo].[Danh mục thuốc] ([Tên thuốc], [Ghi chú]) VALUES (N'" + textBox2.Text + "', N'" + textBox3.Text + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đã thêm thuốc mới", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateMedicineList();
            }
            catch
            {
                MessageBox.Show("Không thể thêm thuốc mới", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        string Mã_thuốc;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.CommandText = "UPDATE [dbo].[Danh mục thuốc] SET [Tên thuốc] = N'" + textBox2.Text + "', [Ghi chú] = N'" + textBox3.Text + "' WHERE [Mã thuốc] = " + Mã_thuốc;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đã cập nhật thông tin thuốc", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateMedicineList();
            }
            catch
            {
                MessageBox.Show("Không thể cập nhật thông tin thuốc", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                UpdateMedicineList();
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DataGridViewRow row = dataGridView1.CurrentRow;
                Mã_thuốc = row.Cells[0].Value.ToString();
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
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
            R = 4;
            this.Close();
        }

        private void quảnLýThuốcToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
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
