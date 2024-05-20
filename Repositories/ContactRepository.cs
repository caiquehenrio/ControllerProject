using ControllerProject.DataBase;
using ControllerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerProject.Repository
{

    public class ContactRepository : IContactRepository
    {

        private readonly DataContext _dataContext;

        public ContactRepository(DataContext dataContext) 
        {

            _dataContext = dataContext;

        }

        public ContactModel FindId(int Id)
        {

            return _dataContext.Contacts.FirstOrDefault(x => x.Id == Id);

        }

        public List<ContactModel> FindAll(int userId)
        {

            return _dataContext.Contacts.Where(x => x.UserId == userId).ToList();

        }

        public ContactModel Add(ContactModel contact)
        {

            _dataContext.Contacts.Add(contact);
            _dataContext.SaveChanges();

            return contact;

        }

        public ContactModel Update(ContactModel contact)
        {

            ContactModel contactDB = FindId(contact.Id);

            if (contactDB == null) throw new System.Exception("An error occurred while updating the contact!");

            contactDB.Name = contact.Name;
            contactDB.Email = contact.Email;
            contactDB.Cellphone = contact.Cellphone;

            _dataContext.Contacts.Update(contactDB);
            _dataContext.SaveChanges();

            return contactDB;

        }

        public bool Delete(int Id)
        {

            ContactModel contactDB = FindId(Id);

            if (contactDB == null) throw new System.Exception("An error occurred while deleting the contact!");

            _dataContext.Contacts.Remove(contactDB);
            _dataContext.SaveChanges();

            return true;

        }

    }

}
