using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFTR.DAL.Users
{
    public class Users
    {
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public bool IsActive { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
    }
}
