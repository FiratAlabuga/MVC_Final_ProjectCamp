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
            var deletedEntity = c.Entry(p);
            deletedEntity.State = EntityState.Deleted;
            //_object.Remove(p);
            c.SaveChanges();
        }

        public T GetById(Expression<Func<T, bool>> filter)
        {
            //bir dizide veya listede sadece bir tane değer döndermek için kullanılan efLINQ methodudur.
            return _object.SingleOrDefault(filter);
        }

        public void Insert(T p)
        {
            //eklenecek değeri atama işlemi
            var addedEntity = c.Entry(p);
            //eklemeyi entitystate üzerinde gerçekleştireceğiz.
            addedEntity.State = EntityState.Added;
            //_object.Add(p);
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
            var updatedEntity = c.Entry(p);
            updatedEntity.State = EntityState.Modified;
            c.SaveChanges();
        }
    }
}
