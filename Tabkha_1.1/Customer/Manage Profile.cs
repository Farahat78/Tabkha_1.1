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
    public partial class Manage_Profile : Form
    {
        public Manage_Profile()
        {
            InitializeComponent();
        }

        private void btn_edit_img_Click(object sender, EventArgs e)
        {

        }

        public void edit_invisible()
        {
            btn_editBdate.Visible = false;
            btn_editEmail.Visible = false;
            btn_editName.Visible = false;
            btn_editPnumber.Visible = false;
            btn_edit_img.Visible = false;
        }
    }
}
