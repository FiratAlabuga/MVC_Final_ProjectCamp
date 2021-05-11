using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRepository<T>
    {
        //CRUD
        //Type Name();
        List<T> List();
        void Insert(T p);
        T GetById(Expression<Func<T, bool>> filter);//id için getir
        void Delete(T p);
        void Update(T p);
        List<T> List(Expression<Func<T, bool>> filtered);//istediğim ifadedeki değerleri getir.
    }
}
