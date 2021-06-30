using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Talent
    {
        [Key]
        public int TalentId { get; set; }
        [StringLength(50)]
        public string TalentName { get; set; }
        public byte Range { get; set; }
    }
}
