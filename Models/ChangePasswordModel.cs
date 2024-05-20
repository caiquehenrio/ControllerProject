using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerProject.Models
{

    public class ChangePasswordModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Enter the user's current password")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "Enter the new user password")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Confirm the user's new password")]
        [Compare("NewPassword", ErrorMessage = "Password different from the new password")]
        public string ConfirmNewPassword { get; set; }

    }

}
