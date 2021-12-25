using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLibrary
{
    public class Users:BaseEntity
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}
