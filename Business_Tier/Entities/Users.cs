using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Tier.Entities
{
    public class Users
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string Name { get; set; }
        public int UserType { get; set; }
        public string UserAddress { get; set; }
        public string UserPhone { get; set; }
        public int UserCount { get; set; }
    }
}
