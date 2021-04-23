using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Content
    {
        [Key]
        public int ContentID { get; set; }
        [StringLength(1000)]
        public string ContentValue { get; set; }
        public string ContentDate { get; set; }
        //contentyazar hangi yazar
        //contenthead hangi başlık
        public int HeadID { get; set; }
        public virtual Heading Heading { get; set; }
        public int? WriterID { get; set; }//nullable 
        //Yorum yapan writer'ın ID'sini almak
        public virtual Writer Writer { get; set; }
    }
}
