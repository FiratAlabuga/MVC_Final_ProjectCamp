using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void ContactAddBL(Contact contact)
        {
            _contactDal.Insert(contact);
        }

        public void ContactDelete(Contact contact)
        {
            _contactDal.Delete(contact);
        }

        public void ContactUpdate(Contact contact)
        {
            _contactDal.Update(contact);
        }

        public List<Contact> fetchContactList()
        {
            return _contactDal.List();
        }

        public Contact GetByID(int id)
        {
            return _contactDal.GetById(x=>x.ContactMesID==id);
        }
    }
}
