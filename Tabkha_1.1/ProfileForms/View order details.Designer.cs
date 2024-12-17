namespace Tabkha_1._1
{
    partial class View_order_details
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btn_previousOrder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.PanelTemplate = new System.Windows.Forms.Panel();
            this.btn_Print_reciept = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_total_price = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_order_price = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_phone = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_Address = new System.Windows.Forms.Label();
            this.lbl_order_name = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbl_order_quantity = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.lbl_OrderStatus = new System.Windows.Forms.Label();
            this.PanelTemplate.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(230, 43);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(484, 28);
            this.progressBar1.TabIndex = 6;
            // 
            // btn_previousOrder
            // 
            this.btn_previousOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(82)))), ((int)(((byte)(48)))));
            this.btn_previousOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_previousOrder.ForeColor = System.Drawing.Color.White;
            this.btn_previousOrder.Location = new System.Drawing.Point(76, 107);
            this.btn_previousOrder.Name = "btn_previousOrder";
            this.btn_previousOrder.Size = new System.Drawing.Size(285, 33);
            this.btn_previousOrder.TabIndex = 5;
            this.btn_previousOrder.Text = "view Previous Order";
            this.btn_previousOrder.UseVisualStyleBackColor = false;
            this.btn_previousOrder.Click += new System.EventHandler(this.btn_previousOrder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(91, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Order Status";
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 15;
            this.guna2Elipse1.TargetControl = this.btn_previousOrder;
            // 
            // PanelTemplate
            // 
            this.PanelTemplate.Controls.Add(this.btn_Print_reciept);
            this.PanelTemplate.Controls.Add(this.label8);
            this.PanelTemplate.Controls.Add(this.label6);
            this.PanelTemplate.Controls.Add(this.lbl_total_price);
            this.PanelTemplate.Controls.Add(this.label4);
            this.PanelTemplate.Controls.Add(this.label24);
            this.PanelTemplate.Controls.Add(this.label3);
            this.PanelTemplate.Controls.Add(this.label2);
            this.PanelTemplate.Controls.Add(this.lbl_order_price);
            this.PanelTemplate.Controls.Add(this.lbl_name);
            this.PanelTemplate.Controls.Add(this.lbl_phone);
            this.PanelTemplate.Controls.Add(this.label5);
            this.PanelTemplate.Controls.Add(this.lbl_Address);
            this.PanelTemplate.Controls.Add(this.lbl_order_name);
            this.PanelTemplate.Controls.Add(this.label12);
            this.PanelTemplate.Controls.Add(this.lbl_order_quantity);
            this.PanelTemplate.Controls.Add(this.label11);
            this.PanelTemplate.Location = new System.Drawing.Point(3, 4);
            this.PanelTemplate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PanelTemplate.Name = "PanelTemplate";
            this.PanelTemplate.Size = new System.Drawing.Size(910, 177);
            this.PanelTemplate.TabIndex = 7;
            // 
            // btn_Print_reciept
            // 
            this.btn_Print_reciept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(82)))), ((int)(((byte)(48)))));
            this.btn_Print_reciept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Print_reciept.FlatAppearance.BorderSize = 0;
            this.btn_Print_reciept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Print_reciept.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Print_reciept.ForeColor = System.Drawing.Color.White;
            this.btn_Print_reciept.Location = new System.Drawing.Point(680, 126);
            this.btn_Print_reciept.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Print_reciept.Name = "btn_Print_reciept";
            this.btn_Print_reciept.Size = new System.Drawing.Size(159, 37);
            this.btn_Print_reciept.TabIndex = 49;
            this.btn_Print_reciept.Text = "Print Reciept";
            this.btn_Print_reciept.UseVisualStyleBackColor = false;
            this.btn_Print_reciept.Click += new System.EventHandler(this.btn_Print_reciept_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(775, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 25);
            this.label8.TabIndex = 48;
            this.label8.Text = "Pending";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(3, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 25);
            this.label6.TabIndex = 21;
            this.label6.Text = "Order num :";
            // 
            // lbl_total_price
            // 
            this.lbl_total_price.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_total_price.Location = new System.Drawing.Point(772, 99);
            this.lbl_total_price.Name = "lbl_total_price";
            this.lbl_total_price.Size = new System.Drawing.Size(124, 26);
            this.lbl_total_price.TabIndex = 46;
            this.lbl_total_price.Text = "360";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(150, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 25);
            this.label4.TabIndex = 22;
            this.label4.Text = "55";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.label24.Location = new System.Drawing.Point(685, 97);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(84, 25);
            this.label24.TabIndex = 45;
            this.label24.Text = "Total :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(3, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 22);
            this.label3.TabIndex = 23;
            this.label3.Text = "Client Name :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(3, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 22);
            this.label2.TabIndex = 24;
            this.label2.Text = "Phone :";
            // 
            // lbl_order_price
            // 
            this.lbl_order_price.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_order_price.Location = new System.Drawing.Point(676, 22);
            this.lbl_order_price.Name = "lbl_order_price";
            this.lbl_order_price.Size = new System.Drawing.Size(152, 75);
            this.lbl_order_price.TabIndex = 41;
            this.lbl_order_price.Text = "300";
            // 
            // lbl_name
            // 
            this.lbl_name.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name.Location = new System.Drawing.Point(165, 59);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(165, 21);
            this.lbl_name.TabIndex = 25;
            this.lbl_name.Text = "Ahmed ";
            // 
            // lbl_phone
            // 
            this.lbl_phone.AutoSize = true;
            this.lbl_phone.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_phone.Location = new System.Drawing.Point(107, 97);
            this.lbl_phone.Name = "lbl_phone";
            this.lbl_phone.Size = new System.Drawing.Size(157, 22);
            this.lbl_phone.TabIndex = 26;
            this.lbl_phone.Text = "+201010104706";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(3, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 22);
            this.label5.TabIndex = 27;
            this.label5.Text = "Address :";
            // 
            // lbl_Address
            // 
            this.lbl_Address.AutoSize = true;
            this.lbl_Address.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Address.Location = new System.Drawing.Point(128, 133);
            this.lbl_Address.Name = "lbl_Address";
            this.lbl_Address.Size = new System.Drawing.Size(137, 22);
            this.lbl_Address.TabIndex = 28;
            this.lbl_Address.Text = "Kafr El-Shiekh";
            // 
            // lbl_order_name
            // 
            this.lbl_order_name.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_order_name.Location = new System.Drawing.Point(569, 22);
            this.lbl_order_name.Name = "lbl_order_name";
            this.lbl_order_name.Size = new System.Drawing.Size(99, 133);
            this.lbl_order_name.TabIndex = 36;
            this.lbl_order_name.Text = "Makarona";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(420, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(130, 22);
            this.label12.TabIndex = 29;
            this.label12.Text = "Order Info :";
            // 
            // lbl_order_quantity
            // 
            this.lbl_order_quantity.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_order_quantity.Location = new System.Drawing.Point(546, 22);
            this.lbl_order_quantity.Name = "lbl_order_quantity";
            this.lbl_order_quantity.Size = new System.Drawing.Size(22, 142);
            this.lbl_order_quantity.TabIndex = 35;
            this.lbl_order_quantity.Text = "2";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label11.Location = new System.Drawing.Point(7, 148);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(819, 19);
            this.label11.TabIndex = 17;
            this.label11.Text = "_________________________________________________________________________________" +
    "_________";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.PanelTemplate);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1, 146);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(928, 223);
            this.flowLayoutPanel1.TabIndex = 8;
            this.flowLayoutPanel1.Visible = false;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 30;
            this.guna2Elipse2.TargetControl = this.btn_Print_reciept;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // lbl_OrderStatus
            // 
            this.lbl_OrderStatus.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_OrderStatus.Location = new System.Drawing.Point(221, 80);
            this.lbl_OrderStatus.Name = "lbl_OrderStatus";
            this.lbl_OrderStatus.Size = new System.Drawing.Size(493, 24);
            this.lbl_OrderStatus.TabIndex = 26;
            this.lbl_OrderStatus.Text = "Ahmed ";
            // 
            // View_order_details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(947, 428);
            this.Controls.Add(this.lbl_OrderStatus);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btn_previousOrder);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "View_order_details";
            this.Text = "View_order_details";
            this.Load += new System.EventHandler(this.View_order_details_Load);
            this.PanelTemplate.ResumeLayout(false);
            this.PanelTemplate.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btn_previousOrder;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Panel PanelTemplate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_total_price;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_order_price;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_phone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_Address;
        private System.Windows.Forms.Label lbl_order_name;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbl_order_quantity;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btn_Print_reciept;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label lbl_OrderStatus;
    }
}