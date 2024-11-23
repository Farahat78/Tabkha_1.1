namespace Tabkha_1._1
{
    partial class ManageChefForm
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
            this.dgv_chefs = new System.Windows.Forms.DataGridView();
            this.chefID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.specialty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_chefs)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_chefs
            // 
            this.dgv_chefs.BackgroundColor = System.Drawing.Color.White;
            this.dgv_chefs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_chefs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_chefs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chefID,
            this.nme,
            this.specialty});
            this.dgv_chefs.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgv_chefs.Location = new System.Drawing.Point(0, 0);
            this.dgv_chefs.Name = "dgv_chefs";
            this.dgv_chefs.ReadOnly = true;
            this.dgv_chefs.RowHeadersWidth = 51;
            this.dgv_chefs.RowTemplate.Height = 24;
            this.dgv_chefs.Size = new System.Drawing.Size(573, 450);
            this.dgv_chefs.TabIndex = 0;
            // 
            // chefID
            // 
            this.chefID.HeaderText = "Chef ID";
            this.chefID.MinimumWidth = 6;
            this.chefID.Name = "chefID";
            this.chefID.ReadOnly = true;
            this.chefID.Width = 125;
            // 
            // nme
            // 
            this.nme.HeaderText = "Name";
            this.nme.MinimumWidth = 6;
            this.nme.Name = "nme";
            this.nme.ReadOnly = true;
            this.nme.Width = 125;
            // 
            // specialty
            // 
            this.specialty.HeaderText = "Specialty";
            this.specialty.MinimumWidth = 6;
            this.specialty.Name = "specialty";
            this.specialty.ReadOnly = true;
            this.specialty.Width = 125;
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(580, 29);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(177, 23);
            this.btn_add.TabIndex = 1;
            this.btn_add.Text = "Add Chef";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.Location = new System.Drawing.Point(580, 73);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(177, 23);
            this.btn_edit.TabIndex = 2;
            this.btn_edit.Text = "Edit Chef";
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(580, 130);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(177, 23);
            this.btn_delete.TabIndex = 7;
            this.btn_delete.Text = "Delete Chef";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // ManageChefForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.dgv_chefs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ManageChefForm";
            this.Text = "Manage Chef";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_chefs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_chefs;
        private System.Windows.Forms.DataGridViewTextBoxColumn chefID;
        private System.Windows.Forms.DataGridViewTextBoxColumn nme;
        private System.Windows.Forms.DataGridViewTextBoxColumn specialty;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_delete;
    }
}