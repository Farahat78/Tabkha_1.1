using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabkha_1._1
{
    public class RealPageNavigator : IPageNavigator
    {
        public void NavigateToHome()
        {
            user_home userHome = new user_home();
            userHome.Show();
        }

        public void NavigateToProfile()
        {
            Owner_Profile ownerProfile = new Owner_Profile();
            ownerProfile.Show();
        }

        public void NavigateToAdminPanel()
        {
            Admin adminPage = new Admin();
            adminPage.Show();
        }   
    }
}
