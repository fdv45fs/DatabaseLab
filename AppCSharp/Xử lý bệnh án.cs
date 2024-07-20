using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DatabaseLabProject
{
    public partial class Xử_lý_bệnh_án : Form
    {
        DataTable Patients = new DataTable();
        DataTable medicine = new DataTable();
        DataTable PatientMedicalRecord = new DataTable();
        SqlConnection cn = DbProtocol.cn;
        SqlCommand cmd = new SqlCommand();
        public Xử_lý_bệnh_án()
        {
            InitializeComponent();
        }

        private void UpdatePatientList()
        {
            cmd.CommandText = "dbo.[Lấy danh sách bệnh án chưa xử lý] @DoctorID = " + MainForm.DoctorID;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            Patients.Clear();
            da.Fill(Patients);
            dataGridView1.DataSource = Patients;
        }

        private void UpdateMedicineList()
        {
            cmd.CommandText = "dbo.[Lấy danh mục thuốc]";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            medicine.Clear();
            da.Fill(medicine);
            medicine.PrimaryKey = new DataColumn[] { medicine.Columns[0] };
            comboBox2.DataSource = medicine;
            comboBox2.DisplayMember = "Tên thuốc";
            comboBox2.ValueMember = "Mã thuốc";
            comboBox2.SelectedIndex = -1;
        }
        private void UpdatePatientMedicalRecord()
        {
            cmd.CommandText = "SELECT * FROM [dbo].[Lấy thông tin bệnh án của bệnh nhân] (" + PatientID + ") ORDER BY [Mã bệnh án] DESC";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            PatientMedicalRecord.Clear();
            da.Fill(PatientMedicalRecord);
            dataGridView2.DataSource = PatientMedicalRecord;
        }
        private void Xử_lý_bệnh_án_Load(object sender, EventArgs e)
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
            UpdatePatientList();
            comboBox1.SelectedIndex = 0;
            tabPage2.Enabled = false;
            tabPage3.Enabled = false;
        }

        string PatientID;
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                UpdateMedicineList();
                tabControl1.SelectedTab = tabPage2;
                PatientID = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                textBox7.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                UpdatePatientMedicalRecord();
                radioButton1.Checked = true;
                radioButton2.Checked = false;
                tabPage2.Enabled = true;
                tabPage3.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.CommandText = "DECLARE @Result TABLE ([Mã xét nghiệm] INT) INSERT INTO [Xét nghiệm]([Mã bệnh án]) OUTPUT INSERTED.[Mã xét nghiệm] INTO @Result VALUES (" + PatientID + ") INSERT INTO [Xét nghiệm " + comboBox1.Text + "]([Mã xét nghiệm]) VALUES ((SELECT [Mã xét nghiệm] FROM @Result))";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đã thêm xét nghiệm", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Không thể thêm xét nghiệm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "SELECT [Xét nghiệm].[Mã xét nghiệm], [Xét nghiệm].[Thời gian], [Xét nghiệm máu].Glucose, [Xét nghiệm máu].[Nhóm máu], [Xét nghiệm máu].[Số lượng hồng cầu], [Xét nghiệm].[Ghi chú] FROM [Xét nghiệm] JOIN [Xét nghiệm máu] ON [Xét nghiệm].[Mã xét nghiệm] = [Xét nghiệm máu].[Mã xét nghiệm] WHERE [Xét nghiệm].[Mã bệnh án] = " + PatientID;
            SqlDataAdapter da1 = new SqlDataAdapter(cmd);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);

            cmd.CommandText = "SELECT [Xét nghiệm].[Mã xét nghiệm], [Xét nghiệm].[Thời gian], [Xét nghiệm nước tiểu].Glucose, [Xét nghiệm nước tiểu].pH, [Xét nghiệm].[Ghi chú] FROM [Xét nghiệm] JOIN [Xét nghiệm nước tiểu] ON [Xét nghiệm].[Mã xét nghiệm] = [Xét nghiệm nước tiểu].[Mã xét nghiệm] WHERE [Xét nghiệm].[Mã bệnh án] = " + PatientID;
            SqlDataAdapter da2 = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            if (dt1.Rows.Count == 0 && dt2.Rows.Count == 0)
            {
                MessageBox.Show("Không có xét nghiệm nào", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Kết_quả_xét_nghiệm form = new Kết_quả_xét_nghiệm(dt1, dt2);
            form.Show();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow row = medicine.Rows.Find(comboBox2.SelectedValue);
                textBox9.Text = row[2].ToString();
            }
            catch
            {
                textBox9.Text = "";
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox10.Text, out int a) && int.TryParse(textBox11.Text, out int b))
                if (a < b)
                    textBox11.Text = a.ToString();
        }

        Đơn_thuốc đơn_Thuốc = new Đơn_thuốc();
        int Thời_gian = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa chọn loại thuốc", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (int.TryParse(textBox10.Text, out int a) && int.TryParse(textBox11.Text, out int b))
            {
                đơn_Thuốc.Show();
                đơn_Thuốc.UpdatePrescription(new object[] { comboBox2.SelectedValue, comboBox2.Text, textBox10.Text, textBox11.Text, textBox12.Text });
                if (Thời_gian < a / b)
                    Thời_gian = a / b;
            }
            else
                MessageBox.Show("Số lượng không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataGridViewRow row in đơn_Thuốc.Dữ_liệu_đơn_thuốc.Rows)
            {
                sb.Append(row.Cells[1].Value.ToString() + " - Số lượng: " + row.Cells[2].Value.ToString() + " - Liều dùng: " + row.Cells[3].Value.ToString() + " - " + row.Cells[4].Value.ToString() + "|");
            }
            try
            {
                string Kết_luận = textBox8.Text;
                while (Kết_luận.IndexOf("  ") != -1)
                    Kết_luận = Kết_luận.Replace("  ", " ");
                Kết_luận = Kết_luận.ToLower();
                cmd.CommandText = "UPDATE [Hồ sơ bệnh án] SET [Tình trạng hiện tại] = N'" + textBox3.Text + "', [Kết luận] = N'" + Kết_luận + "', [Đơn thuốc] = N'" + sb.ToString() + "' WHERE [Mã bệnh án] = " + PatientID;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đã cập nhật bệnh án", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdatePatientList();
            }
            catch
            {
                MessageBox.Show("Cập nhật bệnh án thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.CurrentCell != null)
                textBox13.Text = dataGridView2.CurrentCell.Value.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdatePatientList();
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

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                string Tái_khám = PatientMedicalRecord.Rows[0][0].ToString();
                int i = 0;
                DataTable data = new DataTable();
                data.Columns.Add("Mã bệnh án");
                data.Columns.Add("Bác sĩ điều trị");
                data.Columns.Add("Ngày khám");
                data.Columns.Add("Tình trạng");
                data.Columns.Add("Nhiệt độ");
                data.Columns.Add("Huyết áp");
                data.Columns.Add("Kết luận");
                data.Columns.Add("Đơn thuốc");
                data.Columns.Add("Mã hồ sơ bệnh án lần khám trước");
                do
                {
                    DataRow row = PatientMedicalRecord.Rows[i];
                    if (row[0].ToString() == Tái_khám)
                    {
                        Tái_khám = row[8].ToString();
                        data.Rows.Add(row.ItemArray);
                    }
                    i++;
                }
                while (Tái_khám != "");
                dataGridView2.DataSource = data;
            }
            else
            {
                dataGridView2.DataSource = PatientMedicalRecord;
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        public int ReturnResult
        {
            get { return R; }
        }
    }
}
