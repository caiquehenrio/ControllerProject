using ControllerProject.DataBase;
using ControllerProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerProject.Repository
{

    public class UserRepository : IUserRepository
    {

        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext) 
        {

            _dataContext = dataContext;

        }

        public UserModel FindEmailAndLogin(string email, string login)
        {

            return _dataContext.Users.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper() && x.Login.ToUpper() == login.ToUpper());
        
        }

        public UserModel FindLogin(string login)
        {

            return _dataContext.Users.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());

        }

        public UserModel FindId(int Id)
        {

            return _dataContext.Users.FirstOrDefault(x => x.Id == Id);

        }

        public List<UserModel> FindAll()
        {

            return _dataContext.Users.Include(x => x.Contacts).ToList();

        }

        public UserModel Add(UserModel user)
        {

            user.DateRegister = DateTime.Now;
            user.SetPasswordHash();
            _dataContext.Users.Add(user);
            _dataContext.SaveChanges();

            return user;

        }

        public UserModel Update(UserModel user)
        {

            UserModel userDB = FindId(user.Id);

            if (userDB == null) throw new System.Exception("An error occurred while updating the user!");

            userDB.Name = user.Name;
            userDB.Login = user.Login;
            userDB.Email = user.Email;
            userDB.Profile = user.Profile;
            userDB.UpdateDate = DateTime.Now;

            _dataContext.Users.Update(userDB);
            _dataContext.SaveChanges();

            return userDB;

        }

        public UserModel ChangePassword(ChangePasswordModel changePassword)
        {

            UserModel userDB = FindId(changePassword.Id);

            if(userDB == null) throw new Exception("An error occurred while updating the password. User not found.");

            if(!userDB.PasswordValid(changePassword.CurrentPassword)) throw new Exception("Different current password.");

            if(userDB.PasswordValid(changePassword.NewPassword)) throw new Exception("New password must be different from the current password.");

            userDB.SetNewPassword(changePassword.NewPassword);
            userDB.UpdateDate = DateTime.Now;

            _dataContext.Users.Update(userDB);
            _dataContext.SaveChanges();

            return userDB;

        }

        public bool Delete(int Id)
        {

            UserModel userDB = FindId(Id);

            if (userDB == null) throw new System.Exception("An error occurred while deleting the user!");

            _dataContext.Users.Remove(userDB);
            _dataContext.SaveChanges();

            return true;

        }

    }

}
