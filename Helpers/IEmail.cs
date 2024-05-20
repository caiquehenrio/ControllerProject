using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerProject.Helpers
{

    public interface IEmail
    {

        bool SendTo(string email, string subject, string message);

    }

}
