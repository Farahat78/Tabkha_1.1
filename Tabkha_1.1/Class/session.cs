using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tabkha_1._1
{
    public class Session
    {
        public static int Id { get; set; }
        public static string Name { get; set; }
        public static string Role { get; set; }
        public static string pic { get; set; }

        public static void Logout()
        {
            Id = 0;
            Name = null;
            Role = null;
            pic = null;
        }
    }
}
