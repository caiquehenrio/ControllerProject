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

    public class LoginController : Controller
    {

        private readonly IUserRepository _userRepository;

        private readonly ISession _session;

        private readonly IEmail _email;

        public LoginController(IUserRepository userRepository, 
                               ISession session,
                               IEmail email) 
        {

            _userRepository = userRepository;
            _session = session;
            _email = email;

        }

        public IActionResult Index()
        {

            if (_session.FindUserSession() != null) return RedirectToAction("Index", "Home");

            return View();

        }

        public IActionResult RedefinePassword() 
        {

            return View();

        }

        public IActionResult Logout() 
        {

            _session.RemoveUserSession();

            return RedirectToAction("Index", "Login");

        }

        [HttpPost]
        public IActionResult Enter(LoginModel loginModel) 
        {

            try
            {

                if(ModelState.IsValid) 
                {

                    UserModel user = _userRepository.FindLogin(loginModel.Login);

                    if(user != null) 
                    {

                        if(user.PasswordValid(loginModel.Password)) 
                        {

                            _session.CreateUserSession(user);

                            return RedirectToAction("Index", "Home");

                        }

                        TempData["ErrorMessage"] = $"User password is invalid. Please, try again.";

                    }

                    TempData["ErrorMessage"] = $"Invalid username and/or password. Please, try again.";

                }

                return View("Index");

            }
            catch(Exception error)
            {

                TempData["ErrorMessage"] = $"Ops, we were unable to log in. Please, try again. Error details: {error.Message}.";

                return RedirectToAction("Index");

            }

        }

        [HttpPost]
        public IActionResult ResetPasswordLink(RedefinePasswordModel redefinePassword) 
        {

            try
            {

                if (ModelState.IsValid)
                {

                    UserModel user = _userRepository.FindEmailAndLogin(redefinePassword.Email, redefinePassword.Login);

                    if (user != null)
                    {

                        string newPassword = user.GenerateNewPassword();

                        

                        string message = $"Your new password is: {newPassword}";

                        bool emailSent = _email.SendTo(user.Email, "Controller Project - New Password", message);

                        if(emailSent)
                        {

                            _userRepository.Update(user);
                            TempData["SuccessMessage"] = $"We will send a new password to your email!";

                        }
                        else 
                        {

                            TempData["ErrorMessage"] = $"Unable to send email. Please, try again.";

                        }

                        return RedirectToAction("Index", "Login");

                    }

                    TempData["ErrorMessage"] = $"Unable to reset your password. Please, check the information provided.";

                }

                return View("Index");

            }
            catch (Exception error)
            {

                TempData["ErrorMessage"] = $"Ops, we are unable to reset your password.Please, try again. Error details: {error.Message}.";

                return RedirectToAction("Index");

            }

        }

    }

}
