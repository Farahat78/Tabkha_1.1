using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabkha_1._1
{
    public class PageNavigatorProxy : IPageNavigator
    {
        private readonly RealPageNavigator _realPageNavigator;

        public PageNavigatorProxy()
        {
            _realPageNavigator = new RealPageNavigator();
        }

        public void NavigateToHome()
        {
            if (Session.Role == "Users")
            {
                _realPageNavigator.NavigateToHome();
            }
            else
            {
                throw new UnauthorizedAccessException("Access denied to home page.");
            }
        }

        public void NavigateToProfile()
        {
            if (Session.Role == "Chefs")
            {
                _realPageNavigator.NavigateToProfile();
            }
            else
            {
                throw new UnauthorizedAccessException("Access denied to profile page.");
            }
        }

        public void NavigateToAdminPanel()
        {
            if (Session.Role == "Admins")
            {
                _realPageNavigator.NavigateToAdminPanel();
            }
            else
            {
                throw new UnauthorizedAccessException("Access denied to admin panel.");
            }
        }
    }
}
