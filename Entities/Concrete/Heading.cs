using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Heading
    {
        [Key]
        public int HeadID { get; set; }
        [StringLength(50)]
        public string HeadName { get; set; }
        public DateTime HeadDate { get; set; }
        public bool HeadStatus { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }//sanal key sınıf türünden
        public int WriterID { get; set; }
        public virtual Writer Writer { get; set; }//başlığı oluşturan yazar

        public ICollection<Content> Contents { get; set; }
    }
}
