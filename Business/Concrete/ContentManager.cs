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
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void ContentAddBL(Content content)
        {
            _contentDal.Insert(content);
        }

        public void ContentDelete(Content content)
        {
            _contentDal.Delete(content);
        }

        public void ContentUpdate(Content content)
        {
            _contentDal.Update(content);
        }

        public List<Content> fetchContentList()
        {
            return _contentDal.List();
        }

        public List<Content> fetchListByHeadId(int id)
        {
            return _contentDal.List(x => x.HeadID == id);
        }

        public Content GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
