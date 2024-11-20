namespace Tabkha_1._1
{
    partial class customer_profile
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
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.img_minimize = new System.Windows.Forms.PictureBox();
            this.img_maximize = new System.Windows.Forms.PictureBox();
            this.img_close = new System.Windows.Forms.PictureBox();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.GShadowPanel_user = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_minimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_maximize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_close)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Controls.Add(this.guna2CirclePictureBox1);
            this.guna2GradientPanel1.Controls.Add(this.img_minimize);
            this.guna2GradientPanel1.Controls.Add(this.img_maximize);
            this.guna2GradientPanel1.Controls.Add(this.img_close);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(217)))), ((int)(((byte)(188)))));
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(172)))), ((int)(((byte)(124)))));
            this.guna2GradientPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(1169, 42);
            this.guna2GradientPanel1.TabIndex = 6;
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
            this.guna2CirclePictureBox1.TabIndex = 22;
            this.guna2CirclePictureBox1.TabStop = false;
            this.guna2CirclePictureBox1.UseTransparentBackground = true;
            // 
            // img_minimize
            // 
            this.img_minimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.img_minimize.BackColor = System.Drawing.Color.Transparent;
            this.img_minimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.img_minimize.Image = global::Tabkha_1._1.Properties.Resources.minus;
            this.img_minimize.Location = new System.Drawing.Point(1023, 5);
            this.img_minimize.Name = "img_minimize";
            this.img_minimize.Size = new System.Drawing.Size(40, 29);
            this.img_minimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img_minimize.TabIndex = 5;
            this.img_minimize.TabStop = false;
            this.img_minimize.Click += new System.EventHandler(this.img_minimize_Click);
            // 
            // img_maximize
            // 
            this.img_maximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.img_maximize.BackColor = System.Drawing.Color.Transparent;
            this.img_maximize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.img_maximize.Image = global::Tabkha_1._1.Properties.Resources.maximize;
            this.img_maximize.Location = new System.Drawing.Point(1069, 5);
            this.img_maximize.Name = "img_maximize";
            this.img_maximize.Size = new System.Drawing.Size(44, 33);
            this.img_maximize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img_maximize.TabIndex = 4;
            this.img_maximize.TabStop = false;
            this.img_maximize.Click += new System.EventHandler(this.img_maximize_Click);
            // 
            // img_close
            // 
            this.img_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.img_close.BackColor = System.Drawing.Color.Transparent;
            this.img_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.img_close.Image = global::Tabkha_1._1.Properties.Resources.close;
            this.img_close.Location = new System.Drawing.Point(1119, 5);
            this.img_close.Name = "img_close";
            this.img_close.Size = new System.Drawing.Size(38, 33);
            this.img_close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img_close.TabIndex = 3;
            this.img_close.TabStop = false;
            this.img_close.Click += new System.EventHandler(this.img_close_Click);
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 90;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 30;
            this.guna2Elipse2.TargetControl = this.GShadowPanel_user;
            // 
            // GShadowPanel_user
            // 
            this.GShadowPanel_user.BackColor = System.Drawing.Color.Transparent;
            this.GShadowPanel_user.Dock = System.Windows.Forms.DockStyle.Left;
            this.GShadowPanel_user.FillColor = System.Drawing.Color.White;
            this.GShadowPanel_user.Location = new System.Drawing.Point(0, 42);
            this.GShadowPanel_user.Name = "GShadowPanel_user";
            this.GShadowPanel_user.ShadowColor = System.Drawing.Color.Black;
            this.GShadowPanel_user.Size = new System.Drawing.Size(321, 654);
            this.GShadowPanel_user.TabIndex = 7;
            // 
            // customer_profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 696);
            this.Controls.Add(this.GShadowPanel_user);
            this.Controls.Add(this.guna2GradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "customer_profile";
            this.Text = "customer profile";
            this.guna2GradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_minimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_maximize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_close)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private System.Windows.Forms.PictureBox img_minimize;
        private System.Windows.Forms.PictureBox img_maximize;
        private System.Windows.Forms.PictureBox img_close;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private Guna.UI2.WinForms.Guna2ShadowPanel GShadowPanel_user;
    }
}