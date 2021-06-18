using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IHeadingService
    {
        //Önce methodu interface tarafında tanımla sonra Manager'da içini doldur.
        List<Heading> fetchHeadingList();
        Heading GetByID(int id);
        //heading sınıfından bir heading nesnesinn değeri/değerleri tutulur.
        void HeadingDelete(Heading heading);
        void HeadingAddBL(Heading heading);
        void HeadingUpdate(Heading heading);
    }
}
