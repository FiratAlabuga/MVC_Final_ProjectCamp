using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMessageService
    {
        //Önce methodu interface tarafında tanımla sonra Manager'da içini doldur.
        List<Message> fetchMessageListInbox();
        List<Message> fetchMessageListSendbox();
        Message GetByID(int id);
        //Message sınıfından bir Message nesnesinn değeri/değerleri tutulur.
        void MessageDelete(Message message);
        void MessageAddBL(Message message);
        void MessageUpdate(Message message);
    }
}
