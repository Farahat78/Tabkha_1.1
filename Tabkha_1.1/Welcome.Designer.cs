namespace Tabkha_1._1
{
    partial class Welcome
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
            this.btn_up = new System.Windows.Forms.Button();
            this.btn_in = new System.Windows.Forms.Button();
            this.guna2GradientPanel2 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.img_minimize = new System.Windows.Forms.PictureBox();
            this.img_logo = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.img_close = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2GradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_minimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_close)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_up
            // 
            this.btn_up.BackColor = System.Drawing.Color.Transparent;
            this.btn_up.FlatAppearance.BorderSize = 0;
            this.btn_up.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_up.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_up.Location = new System.Drawing.Point(925, 66);
            this.btn_up.Name = "btn_up";
            this.btn_up.Size = new System.Drawing.Size(111, 40);
            this.btn_up.TabIndex = 0;
            this.btn_up.Text = "Sign up";
            this.btn_up.UseVisualStyleBackColor = false;
            this.btn_up.Click += new System.EventHandler(this.btn_up_Click);
            // 
            // btn_in
            // 
            this.btn_in.BackColor = System.Drawing.Color.Transparent;
            this.btn_in.FlatAppearance.BorderSize = 0;
            this.btn_in.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_in.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_in.Location = new System.Drawing.Point(783, 66);
            this.btn_in.Name = "btn_in";
            this.btn_in.Size = new System.Drawing.Size(111, 40);
            this.btn_in.TabIndex = 1;
            this.btn_in.Text = "Sign in";
            this.btn_in.UseVisualStyleBackColor = false;
            this.btn_in.Click += new System.EventHandler(this.btn_in_Click);
            // 
            // guna2GradientPanel2
            // 
            this.guna2GradientPanel2.Controls.Add(this.btn_in);
            this.guna2GradientPanel2.Controls.Add(this.btn_up);
            this.guna2GradientPanel2.Controls.Add(this.img_minimize);
            this.guna2GradientPanel2.Controls.Add(this.img_logo);
            this.guna2GradientPanel2.Controls.Add(this.img_close);
            this.guna2GradientPanel2.Controls.Add(this.label1);
            this.guna2GradientPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2GradientPanel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(217)))), ((int)(((byte)(188)))));
            this.guna2GradientPanel2.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(172)))), ((int)(((byte)(124)))));
            this.guna2GradientPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.guna2GradientPanel2.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel2.Name = "guna2GradientPanel2";
            this.guna2GradientPanel2.Size = new System.Drawing.Size(1039, 586);
            this.guna2GradientPanel2.TabIndex = 6;
            // 
            // img_minimize
            // 
            this.img_minimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.img_minimize.BackColor = System.Drawing.Color.Transparent;
            this.img_minimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.img_minimize.Image = global::Tabkha_1._1.Properties.Resources.minus;
            this.img_minimize.Location = new System.Drawing.Point(949, 4);
            this.img_minimize.Name = "img_minimize";
            this.img_minimize.Size = new System.Drawing.Size(36, 24);
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
            this.img_logo.Location = new System.Drawing.Point(22, 22);
            this.img_logo.Name = "img_logo";
            this.img_logo.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.img_logo.Size = new System.Drawing.Size(89, 84);
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
            this.img_close.Location = new System.Drawing.Point(995, 4);
            this.img_close.Name = "img_close";
            this.img_close.Size = new System.Drawing.Size(34, 26);
            this.img_close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img_close.TabIndex = 3;
            this.img_close.TabStop = false;
            this.img_close.Click += new System.EventHandler(this.img_close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(-3, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1302, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "_________________________________________________________________________________" +
    "________________________________________________________________________________" +
    "________________________";
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 586);
            this.Controls.Add(this.guna2GradientPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Welcome";
            this.Text = "Welcome";
            this.guna2GradientPanel2.ResumeLayout(false);
            this.guna2GradientPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_minimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_close)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_in;
        private System.Windows.Forms.Button btn_up;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel2;
        private System.Windows.Forms.PictureBox img_minimize;
        private Guna.UI2.WinForms.Guna2CirclePictureBox img_logo;
        private System.Windows.Forms.PictureBox img_close;
        private System.Windows.Forms.Label label1;
    }
}