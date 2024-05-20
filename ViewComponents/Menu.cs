using ControllerProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerProject.ViewComponents
{

    public class Menu : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync() 
        {

            string userSession = HttpContext.Session.GetString("UserSession");

            if (string.IsNullOrEmpty(userSession)) return null;

            UserModel user = JsonConvert.DeserializeObject<UserModel>(userSession);

            return View(user);

        }

    }

}
