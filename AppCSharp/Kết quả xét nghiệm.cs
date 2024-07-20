using System.Data;

namespace DatabaseLabProject
{
    public partial class Kết_quả_xét_nghiệm : Form
    {
        public Kết_quả_xét_nghiệm(DataTable XNM, DataTable XNNT)
        {
            InitializeComponent();
            dataGridView1.DataSource = XNM;
            dataGridView2.DataSource = XNNT;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                dateTimePicker1.Value = DateTime.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                textBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            }
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow != null)
            {
                dateTimePicker2.Value = DateTime.Parse(dataGridView2.CurrentRow.Cells[1].Value.ToString());
                textBox2.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            }
        }
    }
}
