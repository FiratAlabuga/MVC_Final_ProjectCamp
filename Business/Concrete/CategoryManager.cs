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

        public void CategoryDelete(Category category)
        {
            //irepoda tanımlanan delete idye karşılık geleni silecek.
            _categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }

        //Generic repos new ile türetmeden içindekilere ulaştık bağımlılığı yok ettik Dependency Injection.
        public List<Category> fetchCategoryList()
        {
            return _categoryDal.List();
        }

        public Category GetByID(int id)
        {
            //gelen id'ye göre silme işlemi
            return _categoryDal.GetById(x=>x.CategoryID==id);
        }





        //DBCC CHECKIDENT (‘tablo adı’,RESEED,0)

    }
}
