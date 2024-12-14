using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tabkha_1._1
{

    public partial class forget : Form
    {
        public static class globalvariables
        {
            public static string global_email;
        }
        public forget()
        {
            InitializeComponent();
        }
        private int code = 147852;

        private void button1_Click(object sender, EventArgs e)
        {
            string email = customTextBox1.Text;
            globalvariables.global_email = email;
            if (email == "")
            {
                MessageBox.Show("please write your email");
            }

            Sendcode(email);


        }
        private void Sendcode(string user_email)
        {

            string subject = "Welcome to Our System!";
            string body = $"  your verification code is{code}    ...!";
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("asma37amd@gmail.com");
                mail.To.Add(user_email);
                mail.Subject = subject;
                mail.Body = body;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com"))
                {
                    smtp.Port = 587;
                    smtp.Credentials = new System.Net.NetworkCredential("asma37amd@gmail.com", "hugveqskeeqrabuk");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }

        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            string text = customTextBox2.Text;
            if (text == code.ToString())
            {
                ResetPassword resetpassword = new ResetPassword();
                resetpassword.Show();
                this.Hide();
                

            }
        }

        private void img_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void img_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
            this.Hide();
        }
    }
}
