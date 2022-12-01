using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace BasicAuthenticationAzure.Models
{
    public class BasicAuthentication: AuthorizationFilterAttribute
    {
        private const string Realm = "MyRealm";
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //If the Authorization header is empty or null
            //then return Unauthorized
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
                // If the request was unauthorized, add the WWW-Authenticate header 
                // to the response which indicates that it require basic authentication
                if (actionContext.Response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    actionContext.Response.Headers.Add("WWW-Authenticate", string.Format("Basic Realm =\"{0}\"", Realm));
                }
            }
            else
            {
                //Get the authentication token from the request header
                string AuthToken = actionContext.Request.Headers.Authorization.Parameter;
                //Decode the string
                string DecodeAuthToken = Encoding.UTF8.GetString(Convert.FromBase64String(AuthToken));
                //Convert the string into an string array
                string[] usernamepasswordarray = DecodeAuthToken.Split(':');
                //First element of the array is the username
                string username = usernamepasswordarray[0];
                //Second element of the array is the password
                string password = usernamepasswordarray[1];
                //call the login method to check the username and password
                if (UserValidate.Login(username, password))
                {
                    var identity = new GenericIdentity(username);
                    IPrincipal principal = new GenericPrincipal(identity, null);
                    Thread.CurrentPrincipal = principal;
                    if (HttpContext.Current != null)
                    {
                        HttpContext.Current.User = principal;
                    }
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
            base.OnAuthorization(actionContext);
        }
    }
}