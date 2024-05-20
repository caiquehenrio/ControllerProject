using ControllerProject.Filters;
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

    [LoggedUserFilter]
    public class ContactController : Controller
    {

        private readonly IContactRepository _contactRepository;
        private readonly ISession _session;

        public ContactController(IContactRepository contactRepository, 
                                 ISession session)
        {

            _contactRepository = contactRepository;
            _session = session;

        }

        public IActionResult Index()
        {

            UserModel user = _session.FindUserSession();

            List<ContactModel> contacts = _contactRepository.FindAll(user.Id);

            return View(contacts);

        }

        public IActionResult Add()
        {

            return View();

        }

        public IActionResult Edit(int Id)
        {
            ContactModel contact = _contactRepository.FindId(Id);

            return View(contact);

        }

        public IActionResult DeleteConfirm(int Id)
        {

            ContactModel contact = _contactRepository.FindId(Id);

            return View(contact);

        }

        public IActionResult Delete(int Id)
        {

            try
            {

                bool delete = _contactRepository.Delete(Id);

                if (delete)
                {

                    TempData["SuccessMessage"] = "Contact deleted successfully!";

                }
                else
                {

                    TempData["ErrorMessage"] = "Ops, we were unable to delete your contact.";

                }

                return RedirectToAction("Index");

            }
            catch (System.Exception error)
            {

                TempData["ErrorMessage"] = $"Ops, we were unable to delete your contact. Please, try again. Error details: {error.Message}.";

                return RedirectToAction("Index");

            }

        }

        [HttpPost]
        public IActionResult Add(ContactModel contact)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    UserModel user = _session.FindUserSession();
                    contact.UserId = user.Id;

                    _contactRepository.Add(contact);
                    TempData["SuccessMessage"] = "Contact registered successfully!";

                    return RedirectToAction("Index");

                }

                return View(contact);

            } 
            catch (System.Exception error) 
            {

                TempData["ErrorMessage"] = $"Ops, we were unable to register your contact. Please, try again. Error details: {error.Message}.";

                return RedirectToAction("Index");

            }
        
        }

        [HttpPost]
        public IActionResult Edit(ContactModel contact)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    UserModel user = _session.FindUserSession();
                    contact.UserId = user.Id;

                    contact = _contactRepository.Update(contact);
                    TempData["SuccessMessage"] = "Contact changed successfully!";

                    return RedirectToAction("Index");

                }

                return View(contact);

            }
            catch (System.Exception error)
            {

                TempData["ErrorMessage"] = $"Ops, we were unable to update your contact. Please try again. Error details: {error.Message}.";

                return RedirectToAction("Index");
            }

        }

    }

}
