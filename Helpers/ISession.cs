using ControllerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerProject.Helpers
{

    public interface ISession
    {

        void CreateUserSession(UserModel user);

        void RemoveUserSession();

        UserModel FindUserSession();

    }

}
