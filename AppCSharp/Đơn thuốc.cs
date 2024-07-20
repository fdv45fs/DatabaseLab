using System.Data;

namespace DatabaseLabProject
{
    public partial class Đơn_thuốc : Form
    {
        public Đơn_thuốc()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("Mã thuốc", "Mã thuốc");
            dataGridView1.Columns.Add("Tên thuốc", "Tên thuốc");
            dataGridView1.Columns.Add("Số lượng", "Số lượng");
            dataGridView1.Columns.Add("Liều dùng", "Liều dùng");
            dataGridView1.Columns.Add("Ghi chú", "Ghi chú");    
        }

        public void UpdatePrescription(object[] Prescription)
        {
            dataGridView1.Rows.Add(Prescription);
        }

        public DataGridView Dữ_liệu_đơn_thuốc
        {
            get { return dataGridView1; }
        }
    }
}
