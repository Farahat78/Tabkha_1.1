namespace Tabkha_1._1
{
    partial class Cart
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
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.img_minimize = new System.Windows.Forms.PictureBox();
            this.img_logo = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.img_close = new System.Windows.Forms.PictureBox();
            this.guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_minimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_close)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Controls.Add(this.img_minimize);
            this.guna2GradientPanel1.Controls.Add(this.img_logo);
            this.guna2GradientPanel1.Controls.Add(this.img_close);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(217)))), ((int)(((byte)(188)))));
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(172)))), ((int)(((byte)(124)))));
            this.guna2GradientPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(1169, 40);
            this.guna2GradientPanel1.TabIndex = 2;
            // 
            // img_minimize
            // 
            this.img_minimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.img_minimize.BackColor = System.Drawing.Color.Transparent;
            this.img_minimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.img_minimize.Image = global::Tabkha_1._1.Properties.Resources.minus;
            this.img_minimize.Location = new System.Drawing.Point(1074, 5);
            this.img_minimize.Name = "img_minimize";
            this.img_minimize.Size = new System.Drawing.Size(40, 28);
            this.img_minimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img_minimize.TabIndex = 5;
            this.img_minimize.TabStop = false;
            this.img_minimize.Click += new System.EventHandler(this.img_minimize_Click);
            // 
            // img_logo
            // 
            this.img_logo.BackColor = System.Drawing.Color.Transparent;
            this.img_logo.Image = global::Tabkha_1._1.Properties.Resources.IMG_7139_jpg;
            this.img_logo.ImageRotate = 0F;
            this.img_logo.Location = new System.Drawing.Point(-1, -3);
            this.img_logo.Name = "img_logo";
            this.img_logo.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.img_logo.Size = new System.Drawing.Size(85, 47);
            this.img_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img_logo.TabIndex = 6;
            this.img_logo.TabStop = false;
            this.img_logo.UseTransparentBackground = true;
            // 
            // img_close
            // 
            this.img_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.img_close.BackColor = System.Drawing.Color.Transparent;
            this.img_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.img_close.Image = global::Tabkha_1._1.Properties.Resources.close;
            this.img_close.Location = new System.Drawing.Point(1119, 5);
            this.img_close.Name = "img_close";
            this.img_close.Size = new System.Drawing.Size(38, 31);
            this.img_close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img_close.TabIndex = 3;
            this.img_close.TabStop = false;
            this.img_close.Click += new System.EventHandler(this.img_close_Click);
            // 
            // Cart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 696);
            this.Controls.Add(this.guna2GradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Cart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "cart";
            this.guna2GradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.img_minimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_close)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private System.Windows.Forms.PictureBox img_minimize;
        private Guna.UI2.WinForms.Guna2CirclePictureBox img_logo;
        private System.Windows.Forms.PictureBox img_close;
    }
}