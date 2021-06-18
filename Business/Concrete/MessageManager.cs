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
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public List<Message> fetchMessageListInbox()
        {
            return _messageDal.List(x=>x.ReceiverMail=="admin@admin.com");
        }

        public List<Message> fetchMessageListSendbox()
        {
            return _messageDal.List(x => x.SenderMail == "admin@admin.com");
        }

        public Message GetByID(int id)
        {
            return _messageDal.GetById(x => x.MessageId == id);
        }

        public void MessageAddBL(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            throw new NotImplementedException();
        }

        public void MessageUpdate(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
