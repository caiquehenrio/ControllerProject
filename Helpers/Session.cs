using ControllerProject.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerProject.Helpers
{

    public class Session : ISession
    {

        private readonly IHttpContextAccessor _httpContext;

        public Session(IHttpContextAccessor httpContext) 
        {

            _httpContext = httpContext;

        }

        public void CreateUserSession(UserModel user)
        {

            string value = JsonConvert.SerializeObject(user);

            _httpContext.HttpContext.Session.SetString("UserSession", value);
            
        }

        public UserModel FindUserSession()
        {

            string userSession = _httpContext.HttpContext.Session.GetString("UserSession");

            if (string.IsNullOrEmpty(userSession)) return null;

            return JsonConvert.DeserializeObject<UserModel>(userSession);

        }

        public void RemoveUserSession()
        {

            _httpContext.HttpContext.Session.Remove("UserSession");

        }

    }

}
