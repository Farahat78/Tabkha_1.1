using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabkha_1._1
{
    public class AdminDataStrategy : IUserDataStrategy
    {
        public string GetQuery()
        {
            return "SELECT Username, Email, Password, ProfilePic FROM Admins WHERE AdminID = @UserID";
        }
    }

    public class UserDataStrategy : IUserDataStrategy
    {
        public string GetQuery()
        {
            return "SELECT Fname, Lname, Email, Phone, Password, ProfilePic FROM Users WHERE UserID = @UserID";
        }
    }

    public class ChefDataStrategy : IUserDataStrategy
    {
        public string GetQuery()
        {
            return "SELECT Fname, Lname, Email, Phone, Password, ProfilePic, Rname, Bio FROM Chefs WHERE ChefID = @UserID";
        }
    }
}
