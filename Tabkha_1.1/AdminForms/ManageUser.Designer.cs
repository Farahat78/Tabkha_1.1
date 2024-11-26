namespace Tabkha_1._1
{
    partial class ManageUser
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.dgv_users = new System.Windows.Forms.DataGridView();
            this.userID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_delete = new System.Windows.Forms.Button();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.img_pic = new System.Windows.Forms.PictureBox();
            this.txt_search = new Tabkha_1._1.CustomTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_users)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_pic)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_edit
            // 
            this.btn_edit.Location = new System.Drawing.Point(292, 415);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(177, 23);
            this.btn_edit.TabIndex = 4;
            this.btn_edit.Text = "Edit User";
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(49, 415);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(177, 23);
            this.btn_add.TabIndex = 3;
            this.btn_add.Text = "Add User";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // dgv_users
            // 
            this.dgv_users.AllowUserToAddRows = false;
            this.dgv_users.BackgroundColor = System.Drawing.Color.White;
            this.dgv_users.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(172)))), ((int)(((byte)(124)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_users.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_users.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_users.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userID,
            this.nme,
            this.email,
            this.number,
            this.address,
            this.password});
            this.dgv_users.EnableHeadersVisualStyles = false;
            this.dgv_users.Location = new System.Drawing.Point(-6, 35);
            this.dgv_users.Name = "dgv_users";
            this.dgv_users.ReadOnly = true;
            this.dgv_users.RowHeadersWidth = 51;
            this.dgv_users.RowTemplate.Height = 24;
            this.dgv_users.Size = new System.Drawing.Size(806, 374);
            this.dgv_users.TabIndex = 5;
            // 
            // userID
            // 
            this.userID.HeaderText = "User ID";
            this.userID.MinimumWidth = 6;
            this.userID.Name = "userID";
            this.userID.ReadOnly = true;
            this.userID.Width = 125;
            // 
            // nme
            // 
            this.nme.HeaderText = "Name";
            this.nme.MinimumWidth = 6;
            this.nme.Name = "nme";
            this.nme.ReadOnly = true;
            this.nme.Width = 125;
            // 
            // email
            // 
            this.email.HeaderText = "Email";
            this.email.MinimumWidth = 6;
            this.email.Name = "email";
            this.email.ReadOnly = true;
            this.email.Width = 125;
            // 
            // number
            // 
            this.number.HeaderText = "Phone Number";
            this.number.MinimumWidth = 6;
            this.number.Name = "number";
            this.number.ReadOnly = true;
            this.number.Width = 125;
            // 
            // address
            // 
            this.address.HeaderText = "Address";
            this.address.MinimumWidth = 6;
            this.address.Name = "address";
            this.address.ReadOnly = true;
            this.address.Width = 125;
            // 
            // password
            // 
            this.password.HeaderText = "Password";
            this.password.MinimumWidth = 6;
            this.password.Name = "password";
            this.password.ReadOnly = true;
            this.password.Width = 125;
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(560, 415);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(177, 23);
            this.btn_delete.TabIndex = 6;
            this.btn_delete.Text = "Delete User";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.img_pic);
            this.guna2Panel1.Controls.Add(this.txt_search);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(172)))), ((int)(((byte)(124)))));
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(800, 39);
            this.guna2Panel1.TabIndex = 11;
            // 
            // img_pic
            // 
            this.img_pic.BackColor = System.Drawing.Color.Transparent;
            this.img_pic.Image = global::Tabkha_1._1.Properties.Resources.search;
            this.img_pic.Location = new System.Drawing.Point(283, 5);
            this.img_pic.Name = "img_pic";
            this.img_pic.Size = new System.Drawing.Size(29, 24);
            this.img_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img_pic.TabIndex = 9;
            this.img_pic.TabStop = false;
            // 
            // txt_search
            // 
            this.txt_search.Location = new System.Drawing.Point(318, 7);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(100, 22);
            this.txt_search.TabIndex = 8;
            this.txt_search.WatermarkColor = System.Drawing.Color.Gray;
            this.txt_search.WatermarkText = "Search";
            // 
            // ManageUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.dgv_users);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.btn_add);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ManageUser";
            this.Text = "ManageUser";
            this.Load += new System.EventHandler(this.ManageUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_users)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_pic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.DataGridView dgv_users;
        private System.Windows.Forms.Button btn_delete;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.PictureBox img_pic;
        private CustomTextBox txt_search;
        private System.Windows.Forms.DataGridViewTextBoxColumn userID;
        private System.Windows.Forms.DataGridViewTextBoxColumn nme;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn number;
        private System.Windows.Forms.DataGridViewTextBoxColumn address;
        private System.Windows.Forms.DataGridViewTextBoxColumn password;
    }
}