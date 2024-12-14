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
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "Comments";
            // 
            // lbl_username
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(0, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "________________________";
            // 
            // lbl_comments
            // 
            this.lbl_comments.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_comments.Location = new System.Drawing.Point(97, 40);
            this.lbl_comments.Name = "lbl_comments";
            this.lbl_comments.Size = new System.Drawing.Size(722, 52);
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
            this.pnl_template.Size = new System.Drawing.Size(904, 98);
            this.pnl_template.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(98, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ahmed Mohamed";
            // 
            // flowLayoutPanel1
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(102, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(287, 22);
            this.label4.TabIndex = 4;
            this.label4.Text = "Greet Restaurant wish you all the best";
            // 
            // comments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.img_profile);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "comments";
            this.Text = "comments";
            this.Load += new System.EventHandler(this.comments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.img_profile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox img_profile;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}