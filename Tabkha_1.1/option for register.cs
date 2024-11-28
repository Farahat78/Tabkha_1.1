using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tabkha_1._1
{
    public partial class option_for_register : Form
    {
        public option_for_register()
        {
            InitializeComponent();
        }

        private void img_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_customer_Click(object sender, EventArgs e)
        {
            register register = new register();
            register.Show();
            this.Hide();
        }

        private void btn_tabkhachef_Click(object sender, EventArgs e)
        {
            Owner_Register owner_Register = new Owner_Register();
            owner_Register.Show();
            this.Hide();
        }
    }
}
