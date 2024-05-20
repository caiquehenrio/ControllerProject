using ControllerProject.Filters;
using ControllerProject.Models;
using ControllerProject.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerProject.Controllers
{

    [AdminUserLoggedFilter]
    public class UserController : Controller
    {

        private readonly IUserRepository _userRepository;
        private readonly IContactRepository _contactRepository;

        public UserController(IUserRepository userRepository,
                              IContactRepository contactRepository)
        {

            _userRepository = userRepository;
            _contactRepository = contactRepository;

        }

        public IActionResult Index()
        {

            List<UserModel> user = _userRepository.FindAll();

            return View(user);


        }

        public IActionResult Add()
        {

            return View();

        }

        public IActionResult Edit(int Id)
        {

            UserModel user = _userRepository.FindId(Id);

            return View(user);

        }

        public IActionResult DeleteConfirm(int Id)
        {

            UserModel user = _userRepository.FindId(Id);

            return View(user);

        }

        public IActionResult Delete(int Id)
        {

            try
            {

                bool delete = _userRepository.Delete(Id);

                if(delete)
                {

                    TempData["SuccessMessage"] = "User deleted successfully!";

                }
                else
                {

                    TempData["ErrorMessage"] = "Ops, we were unable to delete your user.";

                }

                return RedirectToAction("Index");

            }
            catch(System.Exception error)
            {

                TempData["ErrorMessage"] = $"Ops, we were unable to delete your user. Please, try again. Error details: {error.Message}.";

                return RedirectToAction("Index");

            }

        }

        public IActionResult ListContactsbyUserId(int Id) 
        {

            List<ContactModel> contacts = _contactRepository.FindAll(Id);

            return PartialView("_UserContacts", contacts);

        }

        [HttpPost]
        public IActionResult Add(UserModel user)
        {

            try
            {

                if(ModelState.IsValid)
                {

                    _userRepository.Add(user);
                    TempData["SuccessMessage"] = "User registered successfully!";

                    return RedirectToAction("Index");

                }

                return View(user);

            }
            catch(System.Exception error)
            {

                TempData["ErrorMessage"] = $"Ops, we were unable to register your user. Please, try again. Error details: {error.Message}.";

                return RedirectToAction("Index");

            }

        }

        [HttpPost]
        public IActionResult Edit(UserWithoutPasswordModel userWithoutPassword)
        {

            try
            {

                UserModel user = null;

                if(ModelState.IsValid)
                {

                    user = new UserModel()
                    {

                        Id = userWithoutPassword.Id,
                        Name = userWithoutPassword.Name,
                        Login = userWithoutPassword.Login,
                        Email = userWithoutPassword.Email,
                        Profile = userWithoutPassword.Profile

                    };

                    user = _userRepository.Update(user);
                    TempData["SuccessMessage"] = "User changed successfully!";

                    return RedirectToAction("Index");

                }

                return View(user);

            }
            catch(System.Exception error)
            {

                TempData["ErrorMessage"] = $"Ops, we were unable to update your user. Please, try again. Error details: {error.Message}.";

                return RedirectToAction("Index");
            }

        }

    }

}
