using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace BasicAuthentictionWebAPI.Models
{
    public class UserValidate
    {
        public static bool Login(string username, string password)
        {
            UserBusinessLayer UBL= new UserBusinessLayer();
            var UserLists = UBL.GetUsers();
            return UserLists.Any(user=> user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)
            && user.Password.Equals(password, StringComparison.OrdinalIgnoreCase));
        }
    }
}