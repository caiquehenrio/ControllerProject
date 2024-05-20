using ControllerProject.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerProject.Models
{

    public class UserWithoutPasswordModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Enter the user name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter the user login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Enter the user's email")]
        [EmailAddress(ErrorMessage = "The email provided is invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter the user profile")]
        public ProfileEnum? Profile { get; set; }

    }

}
