using ControllerProject.Helpers;
using ControllerProject.Models;
using ControllerProject.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerProject.Controllers
{

    public class ChangePasswordController : Controller
    {

        private readonly IUserRepository _userRepository;
        private readonly ISession _session;

        public ChangePasswordController(IUserRepository userRepository, 
                                        ISession session) 
        {

            _userRepository = userRepository;
            _session = session;

        }

        public IActionResult Index()
        {

            return View();

        }

        [HttpPost]
        public IActionResult Change(ChangePasswordModel changePassword) 
        {

            try
            {

                UserModel user = _session.FindUserSession();
                changePassword.Id = user.Id;

                if(ModelState.IsValid) 
                {

                    _userRepository.ChangePassword(changePassword);

                    TempData["SuccessMessage"] = $"Password changed successfully!";

                    return View("Index", changePassword);

                }

                return View("Index", changePassword);

            }
            catch(Exception error)
            {

                TempData["ErrorMessage"] = $"Ops, we were unable to change your password. Please, try again. Error detail: {error.Message}";

                return View("Index", changePassword);

            }

        }

    }

}
