using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class WriterManager:IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void WriterAddBL(Writer writer)
        {
            _writerDal.Insert(writer);
        }

        public void WriterDelete(Writer writer)
        {
            //irepoda tanımlanan delete idye karşılık geleni silecek.
            _writerDal.Delete(writer);
        }

        public void WriterUpdate(Writer writer)
        {
            _writerDal.Update(writer);
        }

        //Generic repos new ile türetmeden içindekilere ulaştık bağımlılığı yok ettik Dependency Injection.
        public List<Writer> fetchWriterList()
        {
            return _writerDal.List();
        }

        public Writer GetByID(int id)
        {
            //gelen id'ye göre silme işlemi
            return _writerDal.GetById(x => x.WriterID == id);
        }

    }
}
