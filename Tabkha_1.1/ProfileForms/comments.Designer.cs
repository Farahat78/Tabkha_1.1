namespace Tabkha_1._1
{
    partial class comments
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
            this.img_profile = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.lbl_nme = new System.Windows.Forms.Label();
            this.lbl_comments = new System.Windows.Forms.Label();
            this.panelTemplate = new System.Windows.Forms.Panel();
            this.stars = new Guna.UI2.WinForms.Guna2RatingStar();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.img_profile)).BeginInit();
            this.panelTemplate.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // img_profile
            // 
            this.img_profile.Image = global::Tabkha_1._1.Properties.Resources.Max_R_Headshot__1_;
            this.img_profile.Location = new System.Drawing.Point(3, 3);
            this.img_profile.Name = "img_profile";
            this.img_profile.Size = new System.Drawing.Size(71, 67);
            this.img_profile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img_profile.TabIndex = 0;
            this.img_profile.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Comments";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(0, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "________________________";
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 100;
            this.guna2Elipse1.TargetControl = this.img_profile;
            // 
            // lbl_nme
            // 
            this.lbl_nme.AutoSize = true;
            this.lbl_nme.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nme.Location = new System.Drawing.Point(83, 10);
            this.lbl_nme.Name = "lbl_nme";
            this.lbl_nme.Size = new System.Drawing.Size(138, 21);
            this.lbl_nme.TabIndex = 3;
            this.lbl_nme.Text = "Ahmed Mohamed";
            this.lbl_nme.Click += new System.EventHandler(this.label3_Click);
            // 
            // lbl_comments
            // 
            this.lbl_comments.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_comments.Location = new System.Drawing.Point(87, 34);
            this.lbl_comments.Name = "lbl_comments";
            this.lbl_comments.Size = new System.Drawing.Size(449, 63);
            this.lbl_comments.TabIndex = 4;
            this.lbl_comments.Text = "Greet Restaurant wish you all the best";
            // 
            // panelTemplate
            // 
            this.panelTemplate.Controls.Add(this.stars);
            this.panelTemplate.Controls.Add(this.img_profile);
            this.panelTemplate.Controls.Add(this.lbl_comments);
            this.panelTemplate.Controls.Add(this.lbl_nme);
            this.panelTemplate.Location = new System.Drawing.Point(3, 3);
            this.panelTemplate.Name = "panelTemplate";
            this.panelTemplate.Size = new System.Drawing.Size(708, 105);
            this.panelTemplate.TabIndex = 5;
            // 
            // stars
            // 
            this.stars.Location = new System.Drawing.Point(542, 24);
            this.stars.Name = "stars";
            this.stars.Size = new System.Drawing.Size(120, 28);
            this.stars.TabIndex = 5;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.panelTemplate);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 48);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(711, 331);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // comments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(711, 379);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "comments";
            this.Text = "comments";
            ((System.ComponentModel.ISupportInitialize)(this.img_profile)).EndInit();
            this.panelTemplate.ResumeLayout(false);
            this.panelTemplate.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox img_profile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Label lbl_nme;
        private System.Windows.Forms.Label lbl_comments;
        private System.Windows.Forms.Panel panelTemplate;
        private Guna.UI2.WinForms.Guna2RatingStar stars;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}