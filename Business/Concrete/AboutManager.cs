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
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager()
        {
        }

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void AboutAddBL(About about)
        {
            _aboutDal.Insert(about);
        }

        public void AboutDelete(About about)
        {
            _aboutDal.Delete(about);
        }

        public void AboutUpdate(About about)
        {
            _aboutDal.Update(about);
        }

        public List<About> fetchAboutList()
        {
            return _aboutDal.List();
        }

        public About GetByID(int id)
        {
            return _aboutDal.GetById(x=>x.AboutID==id);
        }
    }
}
