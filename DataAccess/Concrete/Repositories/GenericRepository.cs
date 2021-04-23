using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class //T değeri bir class olmalı
    {
        Context c = new Context();
        DbSet<T> _object;//T değerine karşılık gelen sınıfı tutuyor.
        public GenericRepository()
        {
            _object = c.Set<T>();//dışarıdan gönderilen entity olacaktır.
        }
        public void Delete(T p)
        {
            _object.Remove(p);
            c.SaveChanges();
        }

        public void Insert(T p)
        {
            _object.Add(p);
            c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filtered)
        {
            return _object.Where(filtered).ToList();//filtered göre listeleme yapar.
        }

        public void Update(T p)
        {
            c.SaveChanges();
        }
    }
}
