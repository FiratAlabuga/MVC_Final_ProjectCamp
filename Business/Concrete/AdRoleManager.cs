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
    public class AdRoleManager:IAdRoleService
    {
        IAdRoleDal _adroleDal;

        public AdRoleManager(IAdRoleDal roleDal)
        {
            _adroleDal = roleDal;
        }

        public List<Roles> GetRoles()
        {
            return _adroleDal.List();
        }

    }
}
