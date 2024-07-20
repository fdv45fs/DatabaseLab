using System.Data;

namespace DatabaseLabProject
{
    public partial class Danh_sách_bác_sĩ : Form
    {
        ComboBox ComboBox;
        public Danh_sách_bác_sĩ(ComboBox CCCD, DataTable Doctors)
        {
            InitializeComponent();
            dataGridView1.DataSource = Doctors;
            ComboBox = CCCD;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                ComboBox.SelectedValue = dataGridView1.SelectedRows[0].Cells[0].Value;
            }
            catch
            {
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                ComboBox.SelectedValue = dataGridView1.SelectedRows[0].Cells[0].Value;
                this.Close();
            }
            catch
            {
            }
        }
    }
}
