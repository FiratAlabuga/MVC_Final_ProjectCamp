using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAboutService
    {
        //Önce methodu interface tarafında tanımla sonra Manager'da içini doldur.
        List<About> fetchAboutList();
        About GetByID(int id);
        //About sınıfından bir About nesnesinn değeri/değerleri tutulur.
        void AboutDelete(About about);
        void AboutAddBL(About about);
        void AboutUpdate(About about);
    }
}
