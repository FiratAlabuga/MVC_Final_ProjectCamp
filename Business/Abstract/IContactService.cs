using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContactService
    {
        //Önce methodu interface tarafında tanımla sonra Manager'da içini doldur.
        List<Contact> fetchContactList();
        Contact GetByID(int id);
        //Contact sınıfından bir Contact nesnesinn değeri/değerleri tutulur.
        void ContactDelete(Contact contact);
        void ContactAddBL(Contact contact);
        void ContactUpdate(Contact contact);
    }
}
