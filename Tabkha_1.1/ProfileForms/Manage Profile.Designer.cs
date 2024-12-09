namespace Tabkha_1._1
{
    partial class Manage_Profile
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
            this.components = new System.ComponentModel.Container();
            this.btn_edit_img = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_email = new System.Windows.Forms.Label();
            this.lbl_Pnumber = new System.Windows.Forms.Label();
            this.lbl_password = new System.Windows.Forms.Label();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse3 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.pic_pro = new System.Windows.Forms.PictureBox();
            this.txtbox_email = new Tabkha_1._1.CustomTextBox();
            this.txtbox_Pnumber = new Tabkha_1._1.CustomTextBox();
            this.txtbox_password = new Tabkha_1._1.CustomTextBox();
            this.txtbox_name = new Tabkha_1._1.CustomTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_pro)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_edit_img
            // 
            this.btn_edit_img.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(82)))), ((int)(((byte)(48)))));
            this.btn_edit_img.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_edit_img.ForeColor = System.Drawing.Color.White;
            this.btn_edit_img.Location = new System.Drawing.Point(13, 13);
            this.btn_edit_img.Name = "btn_edit_img";
            this.btn_edit_img.Size = new System.Drawing.Size(75, 30);
            this.btn_edit_img.TabIndex = 0;
            this.btn_edit_img.Text = "Upload";
            this.btn_edit_img.UseVisualStyleBackColor = false;
            this.btn_edit_img.Click += new System.EventHandler(this.btn_edit_img_Click);
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(82)))), ((int)(((byte)(48)))));
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Location = new System.Drawing.Point(373, 148);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(84, 32);
            this.btn_save.TabIndex = 1;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(82)))), ((int)(((byte)(48)))));
            this.btn_edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_edit.ForeColor = System.Drawing.Color.White;
            this.btn_edit.Location = new System.Drawing.Point(266, 148);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(84, 32);
            this.btn_edit.TabIndex = 2;
            this.btn_edit.Text = "Edit";
            this.btn_edit.UseVisualStyleBackColor = false;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(108, 13);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(76, 16);
            this.lbl_name.TabIndex = 7;
            this.lbl_name.Text = "User Name";
            // 
            // lbl_email
            // 
            this.lbl_email.AutoSize = true;
            this.lbl_email.Location = new System.Drawing.Point(108, 41);
            this.lbl_email.Name = "lbl_email";
            this.lbl_email.Size = new System.Drawing.Size(41, 16);
            this.lbl_email.TabIndex = 8;
            this.lbl_email.Text = "Email";
            // 
            // lbl_Pnumber
            // 
            this.lbl_Pnumber.AutoSize = true;
            this.lbl_Pnumber.Location = new System.Drawing.Point(108, 71);
            this.lbl_Pnumber.Name = "lbl_Pnumber";
            this.lbl_Pnumber.Size = new System.Drawing.Size(97, 16);
            this.lbl_Pnumber.TabIndex = 9;
            this.lbl_Pnumber.Text = "Phone Number";
            // 
            // lbl_password
            // 
            this.lbl_password.AutoSize = true;
            this.lbl_password.Location = new System.Drawing.Point(108, 107);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(67, 16);
            this.lbl_password.TabIndex = 10;
            this.lbl_password.Text = "Password";
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 20;
            this.guna2Elipse1.TargetControl = this.btn_save;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 20;
            this.guna2Elipse2.TargetControl = this.btn_edit;
            // 
            // guna2Elipse3
            // 
            this.guna2Elipse3.BorderRadius = 20;
            this.guna2Elipse3.TargetControl = this.btn_edit_img;
            // 
            // pic_pro
            // 
            this.pic_pro.Location = new System.Drawing.Point(492, 141);
            this.pic_pro.Name = "pic_pro";
            this.pic_pro.Size = new System.Drawing.Size(100, 50);
            this.pic_pro.TabIndex = 11;
            this.pic_pro.TabStop = false;
            this.pic_pro.Visible = false;
            // 
            // txtbox_email
            // 
            this.txtbox_email.Location = new System.Drawing.Point(222, 38);
            this.txtbox_email.Name = "txtbox_email";
            this.txtbox_email.Size = new System.Drawing.Size(328, 22);
            this.txtbox_email.TabIndex = 6;
            this.txtbox_email.WatermarkColor = System.Drawing.Color.Gray;
            this.txtbox_email.WatermarkText = "example@gmail.com";
            // 
            // txtbox_Pnumber
            // 
            this.txtbox_Pnumber.Location = new System.Drawing.Point(222, 68);
            this.txtbox_Pnumber.Name = "txtbox_Pnumber";
            this.txtbox_Pnumber.Size = new System.Drawing.Size(328, 22);
            this.txtbox_Pnumber.TabIndex = 5;
            this.txtbox_Pnumber.WatermarkColor = System.Drawing.Color.Gray;
            this.txtbox_Pnumber.WatermarkText = "+2010104706";
            // 
            // txtbox_password
            // 
            this.txtbox_password.Location = new System.Drawing.Point(222, 104);
            this.txtbox_password.Name = "txtbox_password";
            this.txtbox_password.Size = new System.Drawing.Size(328, 22);
            this.txtbox_password.TabIndex = 4;
            this.txtbox_password.UseSystemPasswordChar = true;
            this.txtbox_password.WatermarkColor = System.Drawing.Color.Gray;
            this.txtbox_password.WatermarkText = "Enter password here";
            // 
            // txtbox_name
            // 
            this.txtbox_name.Location = new System.Drawing.Point(222, 10);
            this.txtbox_name.Name = "txtbox_name";
            this.txtbox_name.Size = new System.Drawing.Size(328, 22);
            this.txtbox_name.TabIndex = 3;
            this.txtbox_name.WatermarkColor = System.Drawing.Color.Gray;
            this.txtbox_name.WatermarkText = "Enter name here";
            // 
            // Manage_Profile
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(621, 203);
            this.Controls.Add(this.pic_pro);
            this.Controls.Add(this.lbl_password);
            this.Controls.Add(this.lbl_Pnumber);
            this.Controls.Add(this.lbl_email);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.txtbox_email);
            this.Controls.Add(this.txtbox_Pnumber);
            this.Controls.Add(this.txtbox_password);
            this.Controls.Add(this.txtbox_name);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_edit_img);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Manage_Profile";
            this.Load += new System.EventHandler(this.Manage_Profile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_pro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_edit_img;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_edit;
        private CustomTextBox txtbox_name;
        private CustomTextBox txtbox_password;
        private CustomTextBox txtbox_Pnumber;
        private CustomTextBox txtbox_email;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_email;
        private System.Windows.Forms.Label lbl_Pnumber;
        private System.Windows.Forms.Label lbl_password;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse3;
        private System.Windows.Forms.PictureBox pic_pro;
    }
}