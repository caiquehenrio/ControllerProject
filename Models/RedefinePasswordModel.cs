using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerProject.Models
{

    public class RedefinePasswordModel
    {

        [Required(ErrorMessage = "Enter login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Type the email")]
        public string Email { get; set; }

    }

}
