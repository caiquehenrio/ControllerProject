using ControllerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerProject.Repository
{

    public interface IContactRepository
    {

        ContactModel FindId(int Id);

        List<ContactModel> FindAll(int userId);

        ContactModel Add(ContactModel contact);

        ContactModel Update(ContactModel contact);

        bool Delete(int Id);
        
    }

}
