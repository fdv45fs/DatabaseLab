namespace DatabaseLabProject
{
    partial class Quản_lý_thuốc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            timer1 = new System.Windows.Forms.Timer(components);
            menuStrip1 = new MenuStrip();
            tàiKhoảnToolStripMenuItem = new ToolStripMenuItem();
            thôngTinCáNhânToolStripMenuItem = new ToolStripMenuItem();
            đổiMậtKhẩuToolStripMenuItem = new ToolStripMenuItem();
            đăngXuấtToolStripMenuItem = new ToolStripMenuItem();
            chứcNăngToolStripMenuItem = new ToolStripMenuItem();
            tiếpĐónBệnhNhânToolStripMenuItem = new ToolStripMenuItem();
            xửLýBệnhÁnToolStripMenuItem = new ToolStripMenuItem();
            quảnLýXétNghiệmToolStripMenuItem = new ToolStripMenuItem();
            quảnLýThuốcToolStripMenuItem = new ToolStripMenuItem();
            cơSởDữLiệuToolStripMenuItem = new ToolStripMenuItem();
            tabPage1 = new TabPage();
            panel1 = new Panel();
            button2 = new Button();
            button1 = new Button();
            textBox3 = new TextBox();
            label3 = new Label();
            textBox2 = new TextBox();
            label2 = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            tabControl1 = new TabControl();
            menuStrip1.SuspendLayout();
            tabPage1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Interval = 60000;
            timer1.Tick += timer1_Tick;
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { tàiKhoảnToolStripMenuItem, chứcNăngToolStripMenuItem, cơSởDữLiệuToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(10, 3, 0, 3);
            menuStrip1.Size = new Size(932, 32);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // tàiKhoảnToolStripMenuItem
            // 
            tàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { thôngTinCáNhânToolStripMenuItem, đổiMậtKhẩuToolStripMenuItem, đăngXuấtToolStripMenuItem });
            tàiKhoảnToolStripMenuItem.Name = "tàiKhoảnToolStripMenuItem";
            tàiKhoảnToolStripMenuItem.Size = new Size(102, 26);
            tàiKhoảnToolStripMenuItem.Text = "Tài khoản";
            // 
            // thôngTinCáNhânToolStripMenuItem
            // 
            thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
            thôngTinCáNhânToolStripMenuItem.Size = new Size(232, 26);
            thôngTinCáNhânToolStripMenuItem.Text = "Thông tin cá nhân";
            thôngTinCáNhânToolStripMenuItem.Click += thôngTinCáNhânToolStripMenuItem_Click;
            // 
            // đổiMậtKhẩuToolStripMenuItem
            // 
            đổiMậtKhẩuToolStripMenuItem.Name = "đổiMậtKhẩuToolStripMenuItem";
            đổiMậtKhẩuToolStripMenuItem.Size = new Size(232, 26);
            đổiMậtKhẩuToolStripMenuItem.Text = "Đổi mật khẩu";
            đổiMậtKhẩuToolStripMenuItem.Click += đổiMậtKhẩuToolStripMenuItem_Click;
            // 
            // đăngXuấtToolStripMenuItem
            // 
            đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            đăngXuấtToolStripMenuItem.Size = new Size(232, 26);
            đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            đăngXuấtToolStripMenuItem.Click += đăngXuấtToolStripMenuItem_Click;
            // 
            // chứcNăngToolStripMenuItem
            // 
            chứcNăngToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tiếpĐónBệnhNhânToolStripMenuItem, xửLýBệnhÁnToolStripMenuItem, quảnLýXétNghiệmToolStripMenuItem, quảnLýThuốcToolStripMenuItem });
            chứcNăngToolStripMenuItem.Name = "chứcNăngToolStripMenuItem";
            chứcNăngToolStripMenuItem.Size = new Size(107, 26);
            chứcNăngToolStripMenuItem.Text = "Chức năng";
            // 
            // tiếpĐónBệnhNhânToolStripMenuItem
            // 
            tiếpĐónBệnhNhânToolStripMenuItem.Name = "tiếpĐónBệnhNhânToolStripMenuItem";
            tiếpĐónBệnhNhânToolStripMenuItem.Size = new Size(247, 26);
            tiếpĐónBệnhNhânToolStripMenuItem.Text = "Tiếp đón bệnh nhân";
            tiếpĐónBệnhNhânToolStripMenuItem.Click += tiếpĐónBệnhNhânToolStripMenuItem_Click;
            // 
            // xửLýBệnhÁnToolStripMenuItem
            // 
            xửLýBệnhÁnToolStripMenuItem.Name = "xửLýBệnhÁnToolStripMenuItem";
            xửLýBệnhÁnToolStripMenuItem.Size = new Size(247, 26);
            xửLýBệnhÁnToolStripMenuItem.Text = "Xử lý bệnh án";
            xửLýBệnhÁnToolStripMenuItem.Click += xửLýBệnhÁnToolStripMenuItem_Click;
            // 
            // quảnLýXétNghiệmToolStripMenuItem
            // 
            quảnLýXétNghiệmToolStripMenuItem.Name = "quảnLýXétNghiệmToolStripMenuItem";
            quảnLýXétNghiệmToolStripMenuItem.Size = new Size(247, 26);
            quảnLýXétNghiệmToolStripMenuItem.Text = "Quản lý xét nghiệm";
            quảnLýXétNghiệmToolStripMenuItem.Click += quảnLýXétNghiệmToolStripMenuItem_Click;
            // 
            // quảnLýThuốcToolStripMenuItem
            // 
            quảnLýThuốcToolStripMenuItem.Name = "quảnLýThuốcToolStripMenuItem";
            quảnLýThuốcToolStripMenuItem.Size = new Size(247, 26);
            quảnLýThuốcToolStripMenuItem.Text = "Quản lý thuốc";
            quảnLýThuốcToolStripMenuItem.Click += quảnLýThuốcToolStripMenuItem_Click;
            // 
            // cơSởDữLiệuToolStripMenuItem
            // 
            cơSởDữLiệuToolStripMenuItem.Name = "cơSởDữLiệuToolStripMenuItem";
            cơSởDữLiệuToolStripMenuItem.Size = new Size(133, 26);
            cơSởDữLiệuToolStripMenuItem.Text = "Cơ sở dữ liệu";
            cơSởDữLiệuToolStripMenuItem.Click += cơSởDữLiệuToolStripMenuItem_Click;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Controls.Add(panel1);
            tabPage1.Location = new Point(4, 38);
            tabPage1.Margin = new Padding(5, 4, 5, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(5, 4, 5, 4);
            tabPage1.Size = new Size(924, 564);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Danh mục thuốc";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(5, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(914, 146);
            panel1.TabIndex = 1;
            // 
            // button2
            // 
            button2.Location = new Point(124, 97);
            button2.Name = "button2";
            button2.Size = new Size(125, 39);
            button2.TabIndex = 6;
            button2.Text = "Thêm";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(255, 97);
            button1.Name = "button1";
            button1.Size = new Size(125, 39);
            button1.TabIndex = 7;
            button1.Text = "Cập nhật";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(124, 55);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(787, 36);
            textBox3.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 58);
            label3.Name = "label3";
            label3.Size = new Size(93, 29);
            label3.TabIndex = 4;
            label3.Text = "Ghi chú";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(381, 13);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(530, 36);
            textBox2.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(255, 16);
            label2.Name = "label2";
            label2.Size = new Size(120, 29);
            label2.TabIndex = 2;
            label2.Text = "Tên thuốc:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(124, 13);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(125, 36);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 16);
            label1.Name = "label1";
            label1.Size = new Size(115, 29);
            label1.TabIndex = 0;
            label1.Text = "Mã thuốc:";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(5, 150);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(914, 410);
            dataGridView1.TabIndex = 0;
            dataGridView1.Click += dataGridView1_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 32);
            tabControl1.Margin = new Padding(5, 4, 5, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(932, 606);
            tabControl1.TabIndex = 0;
            // 
            // Quản_lý_thuốc
            // 
            AutoScaleDimensions = new SizeF(14F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(932, 638);
            Controls.Add(tabControl1);
            Controls.Add(menuStrip1);
            Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(5, 4, 5, 4);
            Name = "Quản_lý_thuốc";
            Text = "Quản lý thuốc";
            Load += Quản_lý_thuốc_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tabPage1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem tàiKhoảnToolStripMenuItem;
        private ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
        private ToolStripMenuItem đổiMậtKhẩuToolStripMenuItem;
        private ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private ToolStripMenuItem chứcNăngToolStripMenuItem;
        private ToolStripMenuItem tiếpĐónBệnhNhânToolStripMenuItem;
        private ToolStripMenuItem xửLýBệnhÁnToolStripMenuItem;
        private ToolStripMenuItem quảnLýXétNghiệmToolStripMenuItem;
        private ToolStripMenuItem quảnLýThuốcToolStripMenuItem;
        private ToolStripMenuItem cơSởDữLiệuToolStripMenuItem;
        private TabPage tabPage1;
        private Panel panel1;
        private Button button2;
        private Button button1;
        private TextBox textBox3;
        private Label label3;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox1;
        private Label label1;
        private DataGridView dataGridView1;
        private TabControl tabControl1;
    }
}