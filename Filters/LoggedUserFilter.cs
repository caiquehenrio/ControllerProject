using ControllerProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerProject.Filters
{

    public class LoggedUserFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {

            string userSession = context.HttpContext.Session.GetString("UserSession");

            if (string.IsNullOrEmpty(userSession))
            {

                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });

            }
            else 
            {

                UserModel user = JsonConvert.DeserializeObject<UserModel>(userSession);

                if(user == null) 
                {

                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
                    
                }

            }

            base.OnActionExecuting(context);
        
        }

    }

}
