﻿using BasicAuthentictionWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace BasicAuthentictionWebAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        [BasicAuthentication]
        public HttpResponseMessage GetEmployees()
        {
            string username=Thread.CurrentPrincipal.Identity.Name;
            var EmpList = new EmployeeBusinessLayer().GetEmployees();
            //asdjflkjadskfkldfj
            //fasjdflaksdjfkjakldsfjkldsafjkladsfjlkdsjflk
            //asdfasdfdsaf
            //lljkljkjkjl
            switch(username.ToLower())
            {
                case "maleuser":
                    return Request.CreateResponse(HttpStatusCode.OK,
                        EmpList.Where(user=> user.Gender.ToLower()=="male"));
                case "femaleuser":
                    return Request.CreateResponse(HttpStatusCode.OK,
                        EmpList.Where(user => user.Gender.ToLower() == "female"));
                default:
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
