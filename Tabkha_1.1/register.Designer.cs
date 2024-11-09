namespace Tabkha_1._1
{
    partial class register
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
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.img_minimize = new System.Windows.Forms.PictureBox();
            this.img_close = new System.Windows.Forms.PictureBox();
            this.login_card = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.radio_btn_female = new System.Windows.Forms.RadioButton();
            this.radio_btn_male = new System.Windows.Forms.RadioButton();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btn_clear = new System.Windows.Forms.Button();
            this.txt_phone = new System.Windows.Forms.TextBox();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.guna2GradientPanel2 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.btn_signUp = new System.Windows.Forms.Button();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse3 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse4 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.lbl_username = new System.Windows.Forms.Label();
            this.lbl_password = new System.Windows.Forms.Label();
            this.lbl_email = new System.Windows.Forms.Label();
            this.lbl_phoneNumber = new System.Windows.Forms.Label();
            this.lbl_bdate = new System.Windows.Forms.Label();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_minimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_close)).BeginInit();
            this.login_card.SuspendLayout();
            this.guna2GradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Controls.Add(this.guna2CirclePictureBox1);
            this.guna2GradientPanel1.Controls.Add(this.img_minimize);
            this.guna2GradientPanel1.Controls.Add(this.img_close);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(217)))), ((int)(((byte)(188)))));
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(172)))), ((int)(((byte)(124)))));
            this.guna2GradientPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(1147, 42);
            this.guna2GradientPanel1.TabIndex = 13;
            // 
            // img_minimize
            // 
            this.img_minimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.img_minimize.BackColor = System.Drawing.Color.Transparent;
            this.img_minimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.img_minimize.Image = global::Tabkha_1._1.Properties.Resources.minus;
            this.img_minimize.Location = new System.Drawing.Point(1051, 7);
            this.img_minimize.Name = "img_minimize";
            this.img_minimize.Size = new System.Drawing.Size(40, 29);
            this.img_minimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img_minimize.TabIndex = 5;
            this.img_minimize.TabStop = false;
            this.img_minimize.Click += new System.EventHandler(this.img_minimize_Click);
            // 
            // img_close
            // 
            this.img_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.img_close.BackColor = System.Drawing.Color.Transparent;
            this.img_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.img_close.Image = global::Tabkha_1._1.Properties.Resources.close;
            this.img_close.Location = new System.Drawing.Point(1097, 5);
            this.img_close.Name = "img_close";
            this.img_close.Size = new System.Drawing.Size(38, 33);
            this.img_close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img_close.TabIndex = 3;
            this.img_close.TabStop = false;
            this.img_close.Click += new System.EventHandler(this.img_close_Click);
            // 
            // login_card
            // 
            this.login_card.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.login_card.BackColor = System.Drawing.Color.Transparent;
            this.login_card.Controls.Add(this.lbl_bdate);
            this.login_card.Controls.Add(this.lbl_phoneNumber);
            this.login_card.Controls.Add(this.lbl_email);
            this.login_card.Controls.Add(this.lbl_password);
            this.login_card.Controls.Add(this.lbl_username);
            this.login_card.Controls.Add(this.radio_btn_female);
            this.login_card.Controls.Add(this.radio_btn_male);
            this.login_card.Controls.Add(this.dateTimePicker1);
            this.login_card.Controls.Add(this.btn_clear);
            this.login_card.Controls.Add(this.txt_phone);
            this.login_card.Controls.Add(this.txt_email);
            this.login_card.Controls.Add(this.guna2GradientPanel2);
            this.login_card.Controls.Add(this.txt_password);
            this.login_card.Controls.Add(this.txt_username);
            this.login_card.Controls.Add(this.btn_signUp);
            this.login_card.FillColor = System.Drawing.Color.WhiteSmoke;
            this.login_card.Location = new System.Drawing.Point(348, 60);
            this.login_card.Name = "login_card";
            this.login_card.ShadowColor = System.Drawing.Color.Black;
            this.login_card.Size = new System.Drawing.Size(451, 572);
            this.login_card.TabIndex = 12;
            this.login_card.Paint += new System.Windows.Forms.PaintEventHandler(this.login_card_Paint);
            // 
            // radio_btn_female
            // 
            this.radio_btn_female.AutoSize = true;
            this.radio_btn_female.Location = new System.Drawing.Point(99, 439);
            this.radio_btn_female.Name = "radio_btn_female";
            this.radio_btn_female.Size = new System.Drawing.Size(87, 24);
            this.radio_btn_female.TabIndex = 18;
            this.radio_btn_female.TabStop = true;
            this.radio_btn_female.Text = "Female";
            this.radio_btn_female.UseVisualStyleBackColor = true;
            // 
            // radio_btn_male
            // 
            this.radio_btn_male.AutoSize = true;
            this.radio_btn_male.Location = new System.Drawing.Point(99, 410);
            this.radio_btn_male.Name = "radio_btn_male";
            this.radio_btn_male.Size = new System.Drawing.Size(68, 24);
            this.radio_btn_male.TabIndex = 17;
            this.radio_btn_male.TabStop = true;
            this.radio_btn_male.Text = "Male";
            this.radio_btn_male.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(100, 378);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(252, 26);
            this.dateTimePicker1.TabIndex = 14;
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(82)))), ((int)(((byte)(48)))));
            this.btn_clear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_clear.FlatAppearance.BorderSize = 0;
            this.btn_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clear.ForeColor = System.Drawing.Color.White;
            this.btn_clear.Location = new System.Drawing.Point(242, 502);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(104, 45);
            this.btn_clear.TabIndex = 16;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = false;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // txt_phone
            // 
            this.txt_phone.Location = new System.Drawing.Point(100, 319);
            this.txt_phone.Name = "txt_phone";
            this.txt_phone.Size = new System.Drawing.Size(252, 26);
            this.txt_phone.TabIndex = 15;
            // 
            // txt_email
            // 
            this.txt_email.Location = new System.Drawing.Point(100, 261);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(250, 26);
            this.txt_email.TabIndex = 14;
            // 
            // guna2GradientPanel2
            // 
            this.guna2GradientPanel2.Controls.Add(this.label2);
            this.guna2GradientPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2GradientPanel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(82)))), ((int)(((byte)(48)))));
            this.guna2GradientPanel2.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(217)))), ((int)(((byte)(188)))));
            this.guna2GradientPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.guna2GradientPanel2.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel2.Name = "guna2GradientPanel2";
            this.guna2GradientPanel2.Size = new System.Drawing.Size(451, 91);
            this.guna2GradientPanel2.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(144, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 46);
            this.label2.TabIndex = 0;
            this.label2.Text = "Sign Up";
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(103, 204);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(249, 26);
            this.txt_password.TabIndex = 13;
            // 
            // txt_username
            // 
            this.txt_username.Location = new System.Drawing.Point(103, 147);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(247, 26);
            this.txt_username.TabIndex = 12;
            // 
            // btn_signUp
            // 
            this.btn_signUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(82)))), ((int)(((byte)(48)))));
            this.btn_signUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_signUp.FlatAppearance.BorderSize = 0;
            this.btn_signUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_signUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_signUp.ForeColor = System.Drawing.Color.White;
            this.btn_signUp.Location = new System.Drawing.Point(99, 502);
            this.btn_signUp.Name = "btn_signUp";
            this.btn_signUp.Size = new System.Drawing.Size(104, 45);
            this.btn_signUp.TabIndex = 11;
            this.btn_signUp.Text = "Sign Up";
            this.btn_signUp.UseVisualStyleBackColor = false;
            this.btn_signUp.Click += new System.EventHandler(this.btn_signUp_Click);
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 20;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 20;
            this.guna2Elipse2.TargetControl = this.login_card;
            // 
            // guna2Elipse3
            // 
            this.guna2Elipse3.BorderRadius = 20;
            this.guna2Elipse3.TargetControl = this.btn_signUp;
            // 
            // guna2Elipse4
            // 
            this.guna2Elipse4.BorderRadius = 20;
            this.guna2Elipse4.TargetControl = this.btn_clear;
            // 
            // lbl_username
            // 
            this.lbl_username.AutoSize = true;
            this.lbl_username.Location = new System.Drawing.Point(101, 122);
            this.lbl_username.Name = "lbl_username";
            this.lbl_username.Size = new System.Drawing.Size(85, 20);
            this.lbl_username.TabIndex = 14;
            this.lbl_username.Text = "UserName";
            // 
            // lbl_password
            // 
            this.lbl_password.AutoSize = true;
            this.lbl_password.Location = new System.Drawing.Point(101, 181);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(78, 20);
            this.lbl_password.TabIndex = 15;
            this.lbl_password.Text = "Password";
            // 
            // lbl_email
            // 
            this.lbl_email.AutoSize = true;
            this.lbl_email.Location = new System.Drawing.Point(102, 237);
            this.lbl_email.Name = "lbl_email";
            this.lbl_email.Size = new System.Drawing.Size(48, 20);
            this.lbl_email.TabIndex = 15;
            this.lbl_email.Text = "Email";
            // 
            // lbl_phoneNumber
            // 
            this.lbl_phoneNumber.AutoSize = true;
            this.lbl_phoneNumber.Location = new System.Drawing.Point(101, 292);
            this.lbl_phoneNumber.Name = "lbl_phoneNumber";
            this.lbl_phoneNumber.Size = new System.Drawing.Size(115, 20);
            this.lbl_phoneNumber.TabIndex = 15;
            this.lbl_phoneNumber.Text = "Phone Number";
            // 
            // lbl_bdate
            // 
            this.lbl_bdate.AutoSize = true;
            this.lbl_bdate.Location = new System.Drawing.Point(101, 348);
            this.lbl_bdate.Name = "lbl_bdate";
            this.lbl_bdate.Size = new System.Drawing.Size(81, 20);
            this.lbl_bdate.TabIndex = 15;
            this.lbl_bdate.Text = "Birth Date";
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox1.Image = global::Tabkha_1._1.Properties.Resources.IMG_7139_jpg;
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(12, 0);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(45, 45);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2CirclePictureBox1.TabIndex = 14;
            this.guna2CirclePictureBox1.TabStop = false;
            this.guna2CirclePictureBox1.UseTransparentBackground = true;
            // 
            // register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 640);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Controls.Add(this.login_card);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "register";
            this.Text = "register";
            this.guna2GradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.img_minimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_close)).EndInit();
            this.login_card.ResumeLayout(false);
            this.login_card.PerformLayout();
            this.guna2GradientPanel2.ResumeLayout(false);
            this.guna2GradientPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private System.Windows.Forms.PictureBox img_minimize;
        private System.Windows.Forms.PictureBox img_close;
        private Guna.UI2.WinForms.Guna2ShadowPanel login_card;
        private System.Windows.Forms.TextBox txt_phone;
        private System.Windows.Forms.TextBox txt_email;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.Button btn_signUp;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse3;
        private System.Windows.Forms.Button btn_clear;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.RadioButton radio_btn_female;
        private System.Windows.Forms.RadioButton radio_btn_male;
        private System.Windows.Forms.Label lbl_email;
        private System.Windows.Forms.Label lbl_password;
        private System.Windows.Forms.Label lbl_username;
        private System.Windows.Forms.Label lbl_bdate;
        private System.Windows.Forms.Label lbl_phoneNumber;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
    }
}