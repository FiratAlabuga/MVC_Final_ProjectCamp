using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IWriterService
    {
        //Önce methodu interface tarafında tanımla sonra Manager'da içini doldur.
        List<Writer> fetchWriterList();
        Writer GetByID(int id);
        //Writer sınıfından bir Writer nesnesinn değeri/değerleri tutulur.
        void WriterDelete(Writer writer);
        void WriterAddBL(Writer writer);
        void WriterUpdate(Writer writer);
    }
}
