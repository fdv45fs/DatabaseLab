using System.Data;

namespace DatabaseLabProject
{
    public partial class Danh_sách_bệnh_án : Form
    {
        public Danh_sách_bệnh_án(DataTable Patient)
        {
            InitializeComponent();
            dataGridView1.DataSource = Patient;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                R = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                this.Close();
            }   
        }

        string R = "NULL";
        public string Result
        {
            get { return R; }
        }
    }
}