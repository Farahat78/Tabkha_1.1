﻿namespace Tabkha_1._1
{
    partial class AddEditChef
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
            this.txt_name = new Tabkha_1._1.CustomTextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.lbl_specialty = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.img_close = new System.Windows.Forms.PictureBox();
            this.img_logo = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.img_minimize = new System.Windows.Forms.PictureBox();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.txt_specialty = new Tabkha_1._1.CustomTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.img_close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_minimize)).BeginInit();
            this.guna2GradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(153, 86);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(134, 22);
            this.txt_name.TabIndex = 6;
            this.txt_name.WatermarkColor = System.Drawing.Color.Gray;
            this.txt_name.WatermarkText = "Enter name here";
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(141, 182);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(71, 41);
            this.btn_save.TabIndex = 8;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // lbl_specialty
            // 
            this.lbl_specialty.AutoSize = true;
            this.lbl_specialty.Location = new System.Drawing.Point(73, 138);
            this.lbl_specialty.Name = "lbl_specialty";
            this.lbl_specialty.Size = new System.Drawing.Size(63, 16);
            this.lbl_specialty.TabIndex = 5;
            this.lbl_specialty.Text = "Specialty";
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(73, 89);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(74, 16);
            this.lbl_name.TabIndex = 4;
            this.lbl_name.Text = "Chef Name";
            // 
            // img_close
            // 
            this.img_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.img_close.BackColor = System.Drawing.Color.Transparent;
            this.img_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.img_close.Image = global::Tabkha_1._1.Properties.Resources.close;
            this.img_close.Location = new System.Drawing.Point(298, 3);
            this.img_close.Name = "img_close";
            this.img_close.Size = new System.Drawing.Size(34, 26);
            this.img_close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img_close.TabIndex = 3;
            this.img_close.TabStop = false;
            this.img_close.Click += new System.EventHandler(this.img_close_Click);
            // 
            // img_logo
            // 
            this.img_logo.BackColor = System.Drawing.Color.Transparent;
            this.img_logo.Image = global::Tabkha_1._1.Properties.Resources.IMG_7139_jpg;
            this.img_logo.ImageRotate = 0F;
            this.img_logo.Location = new System.Drawing.Point(12, 3);
            this.img_logo.Name = "img_logo";
            this.img_logo.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.img_logo.Size = new System.Drawing.Size(35, 26);
            this.img_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img_logo.TabIndex = 6;
            this.img_logo.TabStop = false;
            this.img_logo.UseTransparentBackground = true;
            // 
            // img_minimize
            // 
            this.img_minimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.img_minimize.BackColor = System.Drawing.Color.Transparent;
            this.img_minimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.img_minimize.Image = global::Tabkha_1._1.Properties.Resources.minus;
            this.img_minimize.Location = new System.Drawing.Point(251, 3);
            this.img_minimize.Name = "img_minimize";
            this.img_minimize.Size = new System.Drawing.Size(36, 24);
            this.img_minimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img_minimize.TabIndex = 5;
            this.img_minimize.TabStop = false;
            this.img_minimize.Click += new System.EventHandler(this.img_minimize_Click);
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
            this.guna2GradientPanel1.Size = new System.Drawing.Size(341, 34);
            this.guna2GradientPanel1.TabIndex = 3;
            // 
            // txt_specialty
            // 
            this.txt_specialty.Location = new System.Drawing.Point(153, 135);
            this.txt_specialty.Name = "txt_specialty";
            this.txt_specialty.Size = new System.Drawing.Size(134, 22);
            this.txt_specialty.TabIndex = 7;
            this.txt_specialty.WatermarkColor = System.Drawing.Color.Gray;
            this.txt_specialty.WatermarkText = "Enter specialty here";
            this.txt_specialty.TextChanged += new System.EventHandler(this.txt_specialty_TextChanged);
            // 
            // AddEditChef
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(341, 273);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.txt_specialty);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.lbl_specialty);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.guna2GradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddEditChef";
            this.Text = "AddEdit";
            ((System.ComponentModel.ISupportInitialize)(this.img_close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_minimize)).EndInit();
            this.guna2GradientPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomTextBox txt_name;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label lbl_specialty;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.PictureBox img_close;
        private Guna.UI2.WinForms.Guna2CirclePictureBox img_logo;
        private System.Windows.Forms.PictureBox img_minimize;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private CustomTextBox txt_specialty;
    }
}