using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicAuthenticationAzure.Models
{
    public class UserBusinessLayer
    {
        public List<User> GetUser()
        {
            List<User> users = new List<User>();
            users.Add(new User()
            {
                Id = 1, userName = "female", password = "123456"  
            });
            users.Add(new User()
            {
                Id = 2,
                userName = "male",
                password = "1234567"
            });
            return users;
        }
    }
}