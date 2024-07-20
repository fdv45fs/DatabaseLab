using System.Data.SqlClient;

namespace DatabaseLabProject
{
    public partial class MainForm : Form
    {
        public static string DoctorID = "";
        public static int Permission = 0;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SqlConnection cn = DbProtocol.cn;
            cn.Open();
            int result = 0;
            do
            {
                switch (result)
                {
                    case 0:
                        using (var Form = new Login())
                        {
                            Form.ShowDialog();
                            result = Form.ReturnResult;
                            DoctorID = Form.DoctorID;
                            Permission = Form.ReturnResult;
                        }
                        break;
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                        using (var Form = new Tiếp_Đón_Bệnh_Nhân())
                        {
                            Form.ShowDialog();
                            result = Form.ReturnResult;
                        }
                        break;
                    case 2:
                    case 6:
                        using (var Form = new Quản_lý_thuốc())
                        {
                            Form.ShowDialog();
                            result = Form.ReturnResult;
                        }
                        break;
                    case 4:
                        using (var Form = new Quản_lý_xét_nghiệm())
                        {
                            result = -1;
                            Form.ShowDialog();
                            result = Form.ReturnResult;
                        }
                        break;
                    case 8:
                    case 9:
                        using (var Form = new Xử_lý_bệnh_án())
                        {
                            Form.ShowDialog();
                            result = Form.ReturnResult;
                        }
                        break;
                    case 10:
                        using (var Form = new Cơ_sở_dữ_liệu())
                        {
                            Form.ShowDialog();
                            result = Form.ReturnResult;
                        }    
                        break;
                    default:
                        break;
                }
            }
            while (result != -1);
            cn.Close();
            Application.Exit();
        }
    }
}
