namespace DemoRestaurant
{
    partial class ManagementUser
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
            this.button_add_edit = new System.Windows.Forms.Button();
            this.comboBox_post = new System.Windows.Forms.ComboBox();
            this.textBox_lname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_workEnd = new System.Windows.Forms.Label();
            this.label_workStart = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_login = new System.Windows.Forms.TextBox();
            this.textBox_education = new System.Windows.Forms.TextBox();
            this.textBox_patronymic = new System.Windows.Forms.TextBox();
            this.textBox_fname = new System.Windows.Forms.TextBox();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.numericUpDown_age = new System.Windows.Forms.NumericUpDown();
            this.button_dismiss = new System.Windows.Forms.Button();
            this.button_reinstate = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_age)).BeginInit();
            this.SuspendLayout();
            // 
            // button_add_edit
            // 
            this.button_add_edit.Location = new System.Drawing.Point(399, 364);
            this.button_add_edit.Name = "button_add_edit";
            this.button_add_edit.Size = new System.Drawing.Size(181, 32);
            this.button_add_edit.TabIndex = 9;
            this.button_add_edit.Text = "Добавить / Изменить";
            this.button_add_edit.UseVisualStyleBackColor = true;
            this.button_add_edit.Click += new System.EventHandler(this.button_add_edit_Click);
            // 
            // comboBox_post
            // 
            this.comboBox_post.FormattingEnabled = true;
            this.comboBox_post.Location = new System.Drawing.Point(123, 195);
            this.comboBox_post.Name = "comboBox_post";
            this.comboBox_post.Size = new System.Drawing.Size(121, 24);
            this.comboBox_post.TabIndex = 6;
            // 
            // textBox_lname
            // 
            this.textBox_lname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_lname.Location = new System.Drawing.Point(123, 31);
            this.textBox_lname.MaxLength = 45;
            this.textBox_lname.Name = "textBox_lname";
            this.textBox_lname.Size = new System.Drawing.Size(445, 22);
            this.textBox_lname.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "Имя";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(3, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 80);
            this.label2.TabIndex = 4;
            this.label2.Text = "Образование";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(3, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 28);
            this.label3.TabIndex = 5;
            this.label3.Text = "Отчество";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 28);
            this.label4.TabIndex = 6;
            this.label4.Text = "Фамилия";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(3, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 28);
            this.label5.TabIndex = 7;
            this.label5.Text = "Возраст";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(3, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 28);
            this.label6.TabIndex = 8;
            this.label6.Text = "Должность";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.Location = new System.Drawing.Point(3, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 28);
            this.label7.TabIndex = 9;
            this.label7.Text = "Логин";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label8.Location = new System.Drawing.Point(3, 248);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 28);
            this.label8.TabIndex = 10;
            this.label8.Text = "Пароль";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label_workEnd, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.label_workStart, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.textBox_login, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_post, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBox_education, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBox_patronymic, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox_fname, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.textBox_lname, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox_password, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown_age, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(571, 334);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // label_workEnd
            // 
            this.label_workEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_workEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_workEnd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_workEnd.Location = new System.Drawing.Point(123, 304);
            this.label_workEnd.Name = "label_workEnd";
            this.label_workEnd.Size = new System.Drawing.Size(445, 30);
            this.label_workEnd.TabIndex = 23;
            this.label_workEnd.Text = "-";
            this.label_workEnd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_workStart
            // 
            this.label_workStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_workStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_workStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_workStart.Location = new System.Drawing.Point(123, 276);
            this.label_workStart.Name = "label_workStart";
            this.label_workStart.Size = new System.Drawing.Size(445, 28);
            this.label_workStart.TabIndex = 22;
            this.label_workStart.Text = "-";
            this.label_workStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label11.Location = new System.Drawing.Point(3, 304);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(114, 30);
            this.label11.TabIndex = 21;
            this.label11.Text = "Уволен";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.Location = new System.Drawing.Point(3, 276);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 28);
            this.label9.TabIndex = 19;
            this.label9.Text = "Работает с";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_login
            // 
            this.textBox_login.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_login.Location = new System.Drawing.Point(123, 223);
            this.textBox_login.MaxLength = 64;
            this.textBox_login.Name = "textBox_login";
            this.textBox_login.Size = new System.Drawing.Size(445, 22);
            this.textBox_login.TabIndex = 7;
            // 
            // textBox_education
            // 
            this.textBox_education.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_education.Location = new System.Drawing.Point(123, 115);
            this.textBox_education.MaxLength = 150;
            this.textBox_education.Multiline = true;
            this.textBox_education.Name = "textBox_education";
            this.textBox_education.Size = new System.Drawing.Size(445, 74);
            this.textBox_education.TabIndex = 5;
            // 
            // textBox_patronymic
            // 
            this.textBox_patronymic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_patronymic.Location = new System.Drawing.Point(123, 59);
            this.textBox_patronymic.MaxLength = 45;
            this.textBox_patronymic.Name = "textBox_patronymic";
            this.textBox_patronymic.Size = new System.Drawing.Size(445, 22);
            this.textBox_patronymic.TabIndex = 3;
            // 
            // textBox_fname
            // 
            this.textBox_fname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_fname.Location = new System.Drawing.Point(123, 3);
            this.textBox_fname.MaxLength = 45;
            this.textBox_fname.Name = "textBox_fname";
            this.textBox_fname.Size = new System.Drawing.Size(445, 22);
            this.textBox_fname.TabIndex = 1;
            // 
            // textBox_password
            // 
            this.textBox_password.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_password.Location = new System.Drawing.Point(123, 251);
            this.textBox_password.MaxLength = 64;
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(445, 22);
            this.textBox_password.TabIndex = 8;
            // 
            // numericUpDown_age
            // 
            this.numericUpDown_age.Location = new System.Drawing.Point(123, 87);
            this.numericUpDown_age.Minimum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.numericUpDown_age.Name = "numericUpDown_age";
            this.numericUpDown_age.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown_age.TabIndex = 4;
            this.numericUpDown_age.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            // 
            // button_dismiss
            // 
            this.button_dismiss.Enabled = false;
            this.button_dismiss.Location = new System.Drawing.Point(289, 364);
            this.button_dismiss.Name = "button_dismiss";
            this.button_dismiss.Size = new System.Drawing.Size(104, 32);
            this.button_dismiss.TabIndex = 12;
            this.button_dismiss.TabStop = false;
            this.button_dismiss.Text = "Уволить";
            this.button_dismiss.UseVisualStyleBackColor = true;
            this.button_dismiss.Click += new System.EventHandler(this.button_dismiss_Click);
            // 
            // button_reinstate
            // 
            this.button_reinstate.Enabled = false;
            this.button_reinstate.Location = new System.Drawing.Point(67, 364);
            this.button_reinstate.Name = "button_reinstate";
            this.button_reinstate.Size = new System.Drawing.Size(216, 32);
            this.button_reinstate.TabIndex = 13;
            this.button_reinstate.TabStop = false;
            this.button_reinstate.Text = "Восстановить в должности";
            this.button_reinstate.UseVisualStyleBackColor = true;
            this.button_reinstate.Click += new System.EventHandler(this.button_reinstate_Click);
            // 
            // ManagementUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 409);
            this.Controls.Add(this.button_reinstate);
            this.Controls.Add(this.button_dismiss);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.button_add_edit);
            this.Name = "ManagementUser";
            this.Text = "ManagementUser";
            this.Load += new System.EventHandler(this.ManagementUser_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_age)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_add_edit;
        private System.Windows.Forms.ComboBox comboBox_post;
        private System.Windows.Forms.TextBox textBox_lname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBox_login;
        private System.Windows.Forms.TextBox textBox_education;
        private System.Windows.Forms.TextBox textBox_patronymic;
        private System.Windows.Forms.TextBox textBox_fname;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.NumericUpDown numericUpDown_age;
        private System.Windows.Forms.Button button_dismiss;
        private System.Windows.Forms.Label label_workEnd;
        private System.Windows.Forms.Label label_workStart;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button_reinstate;
    }
}