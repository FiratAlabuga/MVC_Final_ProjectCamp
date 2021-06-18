using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Contact
    {
        [Key]
        public int ContactMesID { get; set; }
        [StringLength(20)]
        public string UserName { get; set; }
        [StringLength(50)]
        public string UserMail { get; set; }
        [StringLength(500)]
        public string Subject { get; set; }
        public DateTime ContactDateTime { get; set; }
        [StringLength(1000)]
        public string Message { get; set; }

    }
}
