using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        //Önce methodu interface tarafında tanımla sonra Manager'da içini doldur.
        List<Category> fetchCategoryList();
        Category GetByID(int id);
        //category sınıfından bir category nesnesinn değeri/değerleri tutulur.
        void CategoryDelete(Category category);
        void CategoryAddBL(Category category);
        void CategoryUpdate(Category category);
    }
}
