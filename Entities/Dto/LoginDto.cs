using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class LoginDto
    {
        public string AdminUsername { get; set; }

        public string AdminPassword { get; set; }

        public string AdminRole { get; set; }
    }
}
