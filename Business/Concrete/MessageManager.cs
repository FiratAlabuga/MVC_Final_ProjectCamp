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

        public List<Message> fetchMessageListInbox(string receiver)
        {
            return _messageDal.List(m => m.ReceiverMail == receiver);
        }
        public List<Message> fetchMessageListSendbox(string sender)
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
            _messageDal.Delete(message);
        }

        public void MessageUpdate(Message message)
        {
            _messageDal.Update(message);
        }
        public List<Message> IsDraft()
        {
            return _messageDal.List(m => m.IsDraft == true);
        }
        public List<Message> GetAllRead()
        {
            return _messageDal.List(m => m.ReceiverMail == "admin@admin.com").Where(m => m.IsRead == false).ToList();
        }
    }
}
