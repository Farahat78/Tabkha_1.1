using GMap.NET.MapProviders;
using GMap.NET;
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
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void img_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void img_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_up_Click(object sender, EventArgs e)
        {
            option_for_register o = new option_for_register();
            o.Show();
            this.Hide();
        }

        private void btn_in_Click(object sender, EventArgs e)
        {
            login o = new login();
            o.Show();
            this.Hide();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            login o = new login();
            o.Show();
            this.Hide();
        }

        private void btn_signup_Click(object sender, EventArgs e)
        {
            option_for_register o = new option_for_register();
            o.Show();
            this.Hide();
        }

        private void Welcome_Load(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            GMaps.Instance.Mode = AccessMode.ServerOnly;

            // ضبط الإحداثيات
            gMapControl1.Position = new PointLatLng(31.1125, 30.9398);
            gMapControl1.MinZoom = 1;
            gMapControl1.MaxZoom = 18;
            gMapControl1.Zoom = 17;

            // تفعيل السحب والتكبير/التصغير
            gMapControl1.CanDragMap = true;
            gMapControl1.DragButton = MouseButtons.Left;
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
    }
}