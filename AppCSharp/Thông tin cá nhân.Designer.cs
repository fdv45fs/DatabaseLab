﻿namespace DatabaseLabProject
{
    partial class Thông_tin_cá_nhân
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
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            textBox2 = new TextBox();
            comboBox1 = new ComboBox();
            button1 = new Button();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            textBox4 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 15);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(156, 29);
            label1.TabIndex = 0;
            label1.Text = "Mã nhân viên:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(212, 12);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(200, 36);
            textBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 62);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(123, 29);
            label2.TabIndex = 2;
            label2.Text = "Họ và Tên:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(420, 57);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(121, 29);
            label3.TabIndex = 3;
            label3.Text = "Ngày sinh:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 99);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(102, 29);
            label4.TabIndex = 4;
            label4.Text = "Giới tính";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 141);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(74, 29);
            label5.TabIndex = 5;
            label5.Text = "Khoa:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(420, 141);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(105, 29);
            label6.TabIndex = 6;
            label6.Text = "Chức vụ:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(420, 99);
            label7.Margin = new Padding(5, 0, 5, 0);
            label7.Name = "label7";
            label7.Size = new Size(151, 29);
            label7.TabIndex = 7;
            label7.Text = "Số điện thoại:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(212, 54);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(200, 36);
            textBox2.TabIndex = 9;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Nam", "Nữ" });
            comboBox1.Location = new Point(212, 96);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(200, 37);
            comboBox1.TabIndex = 11;
            // 
            // button1
            // 
            button1.Location = new Point(212, 181);
            button1.Name = "button1";
            button1.Size = new Size(200, 37);
            button1.TabIndex = 16;
            button1.Text = "Thay đổi";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(212, 139);
            textBox5.Name = "textBox5";
            textBox5.ReadOnly = true;
            textBox5.Size = new Size(200, 36);
            textBox5.TabIndex = 17;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(627, 138);
            textBox6.Name = "textBox6";
            textBox6.ReadOnly = true;
            textBox6.Size = new Size(200, 36);
            textBox6.TabIndex = 18;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(627, 96);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(200, 36);
            textBox4.TabIndex = 14;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(627, 50);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 36);
            dateTimePicker1.TabIndex = 10;
            // 
            // Thông_tin_cá_nhân
            // 
            AutoScaleDimensions = new SizeF(14F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(839, 229);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(comboBox1);
            Controls.Add(textBox2);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(5, 4, 5, 4);
            Name = "Thông_tin_cá_nhân";
            Text = "Thông tin cá nhân";
            Load += Thông_tin_cá_nhân_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox textBox2;
        private ComboBox comboBox1;
        private Button button1;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox4;
        private DateTimePicker dateTimePicker1;
    }
}