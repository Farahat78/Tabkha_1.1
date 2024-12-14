namespace Tabkha_1._1
{
    partial class forget
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(forget));
            this.img_logo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.customTextBox1 = new Tabkha_1._1.CustomTextBox();
            this.customTextBox2 = new Tabkha_1._1.CustomTextBox();
            this.btn_confirm = new System.Windows.Forms.Button();
            this.btn_sendcode = new System.Windows.Forms.Button();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.img_minimize = new System.Windows.Forms.PictureBox();
            this.img_close = new System.Windows.Forms.PictureBox();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse3 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.img_logo)).BeginInit();
            this.guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_minimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_close)).BeginInit();
            this.SuspendLayout();
            // 
            // img_logo
            // 
            this.img_logo.Image = global::Tabkha_1._1.Properties.Resources.IMG_7139_jpg;
            this.img_logo.Location = new System.Drawing.Point(375, 61);
            this.img_logo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.img_logo.Name = "img_logo";
            this.img_logo.Size = new System.Drawing.Size(150, 150);
            this.img_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img_logo.TabIndex = 16;
            this.img_logo.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(241, 257);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 22);
            this.label1.TabIndex = 19;
            this.label1.Text = "Email :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(241, 332);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 22);
            this.label2.TabIndex = 20;
            this.label2.Text = "Code :";
            // 
            // customTextBox1
            // 
            this.customTextBox1.Location = new System.Drawing.Point(341, 252);
            this.customTextBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.customTextBox1.Name = "customTextBox1";
            this.customTextBox1.Size = new System.Drawing.Size(256, 27);
            this.customTextBox1.TabIndex = 21;
            this.customTextBox1.WatermarkColor = System.Drawing.Color.Gray;
            this.customTextBox1.WatermarkText = "example@gmail.com";
            // 
            // customTextBox2
            // 
            this.customTextBox2.Location = new System.Drawing.Point(341, 331);
            this.customTextBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.customTextBox2.Name = "customTextBox2";
            this.customTextBox2.Size = new System.Drawing.Size(256, 27);
            this.customTextBox2.TabIndex = 22;
            this.customTextBox2.WatermarkColor = System.Drawing.Color.Gray;
            this.customTextBox2.WatermarkText = "";
            // 
            // btn_confirm
            // 
            this.btn_confirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(82)))), ((int)(((byte)(48)))));
            this.btn_confirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_confirm.ForeColor = System.Drawing.Color.White;
            this.btn_confirm.Location = new System.Drawing.Point(285, 396);
            this.btn_confirm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_confirm.Name = "btn_confirm";
            this.btn_confirm.Size = new System.Drawing.Size(140, 48);
            this.btn_confirm.TabIndex = 23;
            this.btn_confirm.Text = "Confirm";
            this.btn_confirm.UseVisualStyleBackColor = false;
            this.btn_confirm.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // btn_sendcode
            // 
            this.btn_sendcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(82)))), ((int)(((byte)(48)))));
            this.btn_sendcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sendcode.ForeColor = System.Drawing.Color.White;
            this.btn_sendcode.Location = new System.Drawing.Point(457, 396);
            this.btn_sendcode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_sendcode.Name = "btn_sendcode";
            this.btn_sendcode.Size = new System.Drawing.Size(140, 48);
            this.btn_sendcode.TabIndex = 24;
            this.btn_sendcode.Text = "Send Code";
            this.btn_sendcode.UseVisualStyleBackColor = false;
            this.btn_sendcode.Click += new System.EventHandler(this.button1_Click);
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Controls.Add(this.pictureBox2);
            this.guna2GradientPanel1.Controls.Add(this.pictureBox1);
            this.guna2GradientPanel1.Controls.Add(this.guna2CirclePictureBox1);
            this.guna2GradientPanel1.Controls.Add(this.img_minimize);
            this.guna2GradientPanel1.Controls.Add(this.img_close);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(217)))), ((int)(((byte)(188)))));
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(172)))), ((int)(((byte)(124)))));
            this.guna2GradientPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(900, 40);
            this.guna2GradientPanel1.TabIndex = 25;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::Tabkha_1._1.Properties.Resources.arrow;
            this.pictureBox2.Location = new System.Drawing.Point(7, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(38, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::Tabkha_1._1.Properties.Resources.arrow;
            this.pictureBox1.Location = new System.Drawing.Point(-266, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2CirclePictureBox1.Image")));
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(47, 0);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(45, 43);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2CirclePictureBox1.TabIndex = 15;
            this.guna2CirclePictureBox1.TabStop = false;
            this.guna2CirclePictureBox1.UseTransparentBackground = true;
            // 
            // img_minimize
            // 
            this.img_minimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.img_minimize.BackColor = System.Drawing.Color.Transparent;
            this.img_minimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.img_minimize.Image = ((System.Drawing.Image)(resources.GetObject("img_minimize.Image")));
            this.img_minimize.Location = new System.Drawing.Point(813, 7);
            this.img_minimize.Name = "img_minimize";
            this.img_minimize.Size = new System.Drawing.Size(40, 28);
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
            this.img_close.Image = ((System.Drawing.Image)(resources.GetObject("img_close.Image")));
            this.img_close.Location = new System.Drawing.Point(859, 5);
            this.img_close.Name = "img_close";
            this.img_close.Size = new System.Drawing.Size(38, 31);
            this.img_close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img_close.TabIndex = 3;
            this.img_close.TabStop = false;
            this.img_close.Click += new System.EventHandler(this.img_close_Click);
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 150;
            this.guna2Elipse1.TargetControl = this.img_logo;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 30;
            this.guna2Elipse2.TargetControl = this.btn_confirm;
            // 
            // guna2Elipse3
            // 
            this.guna2Elipse3.BorderRadius = 30;
            this.guna2Elipse3.TargetControl = this.btn_sendcode;
            // 
            // forget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 486);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Controls.Add(this.btn_sendcode);
            this.Controls.Add(this.btn_confirm);
            this.Controls.Add(this.customTextBox2);
            this.Controls.Add(this.customTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.img_logo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "forget";
            this.Text = "forget";
            ((System.ComponentModel.ISupportInitialize)(this.img_logo)).EndInit();
            this.guna2GradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_minimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_close)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox img_logo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private CustomTextBox customTextBox1;
        private CustomTextBox customTextBox2;
        private System.Windows.Forms.Button btn_confirm;
        private System.Windows.Forms.Button btn_sendcode;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private System.Windows.Forms.PictureBox img_minimize;
        private System.Windows.Forms.PictureBox img_close;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse3;
    }
}