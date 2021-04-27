using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Concrete;
using Entities.Concrete;
using DataAccess.Concrete.Repositories;

namespace Business.Concrete
{
    public class CategoryManager
    {
        //DBCC CHECKIDENT (‘tablo adı’,RESEED,0)
        GenericRepository<Category> repo = new GenericRepository<Category>();
        public List<Category> GetAll()
        {
            return repo.List();
        }
        public void CategoryAddBL(Category p)
        {
            //if(p.CategoryName==" " || p.CategoryName.Length<=3||p.CategoryDescription==" " || p.CategoryName.Length >= 51)
            //{
            //    //hatamesajı
            //}
            //else
            //{
                repo.Insert(p);
           // }
        }
    }
}
