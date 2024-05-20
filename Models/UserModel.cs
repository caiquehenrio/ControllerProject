using ControllerProject.Enums;
using ControllerProject.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerProject.Models
{

    public class UserModel
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

        [Required(ErrorMessage = "Enter the user password")]
        public string Password { get; set; }

        public DateTime DateRegister { get; set; }

        public DateTime? UpdateDate { get; set; }

        public virtual List<ContactModel> Contacts { get; set; }

        public bool PasswordValid(string password) 
        {

            return Password == password.GenerateHash();

        }

        public void SetPasswordHash() 
        {

            Password = Password.GenerateHash();

        }

        public void SetNewPassword(string newPassword) 
        {

            Password = newPassword.GenerateHash();

        }

        public string GenerateNewPassword()
        {

            string newPassword = Guid.NewGuid().ToString().Substring(0, 8);

            Password = newPassword.GenerateHash();

            return newPassword;
        
        }

    }

}
