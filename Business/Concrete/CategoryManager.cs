using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Concrete;
using Entities.Concrete;
using DataAccess.Concrete.Repositories;
using Business.Abstract;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        //interface üzerindeki tanımlanan metotların kalıtsallığı al

        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void CategoryAddBL(Category category)
        {
            _categoryDal.Insert(category);
        }

        //Generic repos new ile türetmeden içindekilere ulaştık bağımlılığı yok ettik Dependency Injection.
        public List<Category> fetchCategoryList()
        {
            return _categoryDal.List();
        }
        




        //DBCC CHECKIDENT (‘tablo adı’,RESEED,0)

    }
}
