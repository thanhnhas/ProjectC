using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Tier.Entities
{
    public class UserBorrow
    {
        public int ID { get; set; }
        public string username { get; set; }
        public string fromDate { get; set; }
        public DateTime toDate { get; set; }
        public bool status { get; set; }
        public string bookName { get; set; }
    }
}
