using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public bool AdminStatus { get; set; }
        public byte[] AdminUsername { get; set; }
        public byte[] AdminPasswordHash { get; set; } 
        public byte[] AdminPasswordSalt { get; set; }
        [StringLength(1)]
        public string AdminRole { get; set; }
        public int? RoleId { get; set; }
        public virtual Roles Role { get; set; }
    }
}
