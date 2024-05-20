using ControllerProject.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerProject.Controllers
{

    [LoggedUserFilter]
    public class RestrictedController : Controller
    {

        public IActionResult Index()
        {

            return View();
        
        }

    }

}
