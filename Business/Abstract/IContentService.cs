using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContentService
    {
        //Önce methodu interface tarafında tanımla sonra Manager'da içini doldur.
        List<Content> fetchContentList();
        Content GetByID(int id);
        //content sınıfından bir content nesnesinn değeri/değerleri tutulur.
        void ContentDelete(Content content);
        void ContentAddBL(Content content);
        void ContentUpdate(Content content);
        List<Content> fetchListByHeadId(int id);
    }
}
