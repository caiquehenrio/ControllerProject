using ControllerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerProject.Repository
{

    public interface IUserRepository
    {

        UserModel FindEmailAndLogin(string email, string login);

        UserModel FindLogin(string login);

        UserModel FindId(int Id);

        List<UserModel> FindAll();

        UserModel Add(UserModel user);

        UserModel Update(UserModel user);

        UserModel ChangePassword(ChangePasswordModel changePassword);

        bool Delete(int Id);
        
    }

}
