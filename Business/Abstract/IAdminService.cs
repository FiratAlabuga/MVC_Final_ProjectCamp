using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAdminService
    {
        void AdminAddBL(Admin admin);
        void AdminUpdate(Admin admin);
        void AdminDelete(Admin admin);
        List<Admin> fetchAdminList();
        Admin GetByID(int id);
    }
}
