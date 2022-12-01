using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicAuthenticationAzure.Models
{
    public class UserValidate
    {
        public static bool Login(string username, string password)
        {
            UserBusinessLayer ubl= new UserBusinessLayer();
            var users = ubl.GetUser();
            return users.Any(e=>e.userName.Equals(username) && e.password==password);
        }
    }
}