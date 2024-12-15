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
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.lbl_username = new System.Windows.Forms.Label();
            this.lbl_comments = new System.Windows.Forms.Label();
            this.pnl_template = new System.Windows.Forms.Panel();
            this.guna2RatingStar1 = new Guna.UI2.WinForms.Guna2RatingStar();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.img_profile)).BeginInit();
            this.pnl_template.SuspendLayout();
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
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 100;
            this.guna2Elipse1.TargetControl = this.img_profile;
            // 
            // lbl_username
            // 
            this.lbl_username.AutoSize = true;
            this.lbl_username.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_username.Location = new System.Drawing.Point(83, 10);
            this.lbl_username.Name = "lbl_username";
            this.lbl_username.Size = new System.Drawing.Size(138, 21);
            this.lbl_username.TabIndex = 3;
            this.lbl_username.Text = "Ahmed Mohamed";
            // 
            // lbl_comments
            // 
            this.lbl_comments.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_comments.Location = new System.Drawing.Point(86, 34);
            this.lbl_comments.Name = "lbl_comments";
            this.lbl_comments.Size = new System.Drawing.Size(642, 44);
            this.lbl_comments.TabIndex = 4;
            this.lbl_comments.Text = "Greet Restaurant wish you all the best";
            // 
            // pnl_template
            // 
            this.pnl_template.Controls.Add(this.guna2RatingStar1);
            this.pnl_template.Controls.Add(this.img_profile);
            this.pnl_template.Controls.Add(this.lbl_comments);
            this.pnl_template.Controls.Add(this.lbl_username);
            this.pnl_template.Location = new System.Drawing.Point(3, 3);
            this.pnl_template.Name = "pnl_template";
            this.pnl_template.Size = new System.Drawing.Size(804, 83);
            this.pnl_template.TabIndex = 5;
            // 
            // guna2RatingStar1
            // 
            this.guna2RatingStar1.Location = new System.Drawing.Point(694, 10);
            this.guna2RatingStar1.Name = "guna2RatingStar1";
            this.guna2RatingStar1.ReadOnly = true;
            this.guna2RatingStar1.Size = new System.Drawing.Size(107, 24);
            this.guna2RatingStar1.TabIndex = 5;
            this.guna2RatingStar1.Value = 3F;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.pnl_template);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 116);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(828, 263);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // comments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(828, 379);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "comments";
            this.Text = "comments";
            this.Load += new System.EventHandler(this.comments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.img_profile)).EndInit();
            this.pnl_template.ResumeLayout(false);
            this.pnl_template.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox img_profile;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Label lbl_username;
        private System.Windows.Forms.Label lbl_comments;
        private System.Windows.Forms.Panel pnl_template;
        private Guna.UI2.WinForms.Guna2RatingStar guna2RatingStar1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}