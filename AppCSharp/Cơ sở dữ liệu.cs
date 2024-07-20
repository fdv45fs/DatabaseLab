using System.Data.SqlClient;
using System.Data;

namespace DatabaseLabProject
{
    public partial class Cơ_sở_dữ_liệu : Form
    {
        SqlConnection cn = DbProtocol.cn;
        SqlCommand cmd = new SqlCommand();
        public Cơ_sở_dữ_liệu()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    cmd.CommandText = "dbo.[Lấy danh mục thuốc]";
                    break;
                case 1:
                    cmd.CommandText = "dbo.[Lấy chức vụ]";
                    break;
                case 2:
                    cmd.CommandText = "dbo.[Lấy danh sách khoa]";
                    break;
                case 3:
                    cmd.CommandText = "dbo.[Lấy thông tin bác sĩ]";
                    break;
                case 4:
                    cmd.CommandText = "SELECT [Hồ sơ bệnh án].[Mã bệnh án], [Bệnh nhân].[Họ và tên] AS N'Họ và tên bệnh nhân', [Bác sĩ].[Tên bác sĩ] AS N'Họ và tên bác sĩ', CONVERT(VARCHAR, [Hồ sơ bệnh án].[Ngày khám], 103) AS N'Ngày khám', [Hồ sơ bệnh án].[Tình trạng hiện tại] AS N'Tình trạng', [Hồ sơ bệnh án].[Nhiệt độ], [Hồ sơ bệnh án].[Huyết áp], [Hồ sơ bệnh án].[Kết luận], [Hồ sơ bệnh án].[Đơn thuốc], [Hồ sơ bệnh án].[Tái khám] AS N'Mã hồ sơ lần khám trước' FROM [Hồ sơ bệnh án] JOIN [Bệnh nhân] ON [Hồ sơ bệnh án].[Mã bệnh nhân] = [Bệnh nhân].[Mã bệnh nhân] JOIN [Bác sĩ] ON [Hồ sơ bệnh án].[Mã bác sĩ] = [Bác sĩ].[Mã bác sĩ]";
                    break;
                case 5:
                    cmd.CommandText = "dbo.[Lấy thông tin bệnh nhân]";
                    break;
                case 6:
                    cmd.CommandText = "SELECT [Xét nghiệm].[Mã bệnh án], [Bác sĩ].[Tên bác sĩ] AS N'Người xét nghiệm', FORMAT([Xét nghiệm].[Thời gian], 'HH:mm:ss  dd/MM/yyyy') AS N'Thời gian xét nghiệm', [Xét nghiệm máu].Glucose, [Xét nghiệm máu].[Số lượng hồng cầu], [Xét nghiệm máu].[Nhóm máu], [Xét nghiệm].[Ghi chú] FROM [Xét nghiệm] JOIN [Xét nghiệm máu] ON [Xét nghiệm].[Mã xét nghiệm] = [Xét nghiệm máu].[Mã xét nghiệm] LEFT JOIN [Bác sĩ] ON [Xét nghiệm].[Mã bác sĩ] = [Bác sĩ].[Mã bác sĩ]";
                    break;
                case 7:
                    cmd.CommandText = "SELECT [Xét nghiệm].[Mã bệnh án], [Bác sĩ].[Tên bác sĩ] AS N'Người xét nghiệm', FORMAT([Xét nghiệm].[Thời gian], 'HH:mm:ss  dd/MM/yyyy') AS N'Thời gian xét nghiệm',  [Xét nghiệm nước tiểu].Glucose, [Xét nghiệm nước tiểu].pH, [Xét nghiệm].[Ghi chú] FROM [Xét nghiệm] JOIN [Xét nghiệm nước tiểu] ON [Xét nghiệm].[Mã xét nghiệm] = [Xét nghiệm nước tiểu].[Mã xét nghiệm] LEFT JOIN [Bác sĩ] ON [Xét nghiệm].[Mã bác sĩ] = [Bác sĩ].[Mã bác sĩ]";
                    break;
                default:
                    break;
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void Cơ_sở_dữ_liệu_Load(object sender, EventArgs e)
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
            R = 2;
            this.Close();
        }

        private void cơSởDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        int R;

        public int ReturnResult
        {
            get { return R; }
        }
    }
}
