using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerProject.Models
{

    public class ContactModel
    {

        public int Id { get; set; }

        public int? UserId { get; set; }

        [Required(ErrorMessage = "Enter the contact name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter the contact's email")]
        [EmailAddress(ErrorMessage = "The email provided is invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter the contact's cell phone")]
        [Phone(ErrorMessage = "The cell phone number provided is invalid")]
        public string Cellphone { get; set; }

        public UserModel User { get; set; }

    }

}
