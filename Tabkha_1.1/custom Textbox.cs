using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace Tabkha_1._1
{
    public class CustomTextBox : TextBox
    {
        private string watermarkText = "Enter text here";
        private Color watermarkColor = Color.Gray;

        public string WatermarkText
        {
            get { return watermarkText; }
            set { watermarkText = value;  }
        }

        public Color WatermarkColor
        {
            get { return watermarkColor; }
            set { watermarkColor = value;  }
        }

        public CustomTextBox()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (string.IsNullOrEmpty(this.Text))
            {
                // رسم النص الوصفي إذا كان الحقل فارغًا
                using (Brush brush = new SolidBrush(watermarkColor))
                {
                    e.Graphics.DrawString(watermarkText, this.Font, brush, new PointF(1, 1));
                }
            }
            else
            {
                // رسم النص العادي بنفس اللون الأسود إذا كان الحقل غير فارغ
                using (Brush brush = new SolidBrush(Color.Black))
                {
                    e.Graphics.DrawString(this.Text, this.Font, brush, new PointF(1, 1));
                }
            }
        }
    }
}
