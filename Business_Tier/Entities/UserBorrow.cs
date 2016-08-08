using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Tier.Entities
{
    class UserBorrow
    {
        public int ID { get; set; }
        public String username { get; set; }
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
        public bool status { get; set; }
        public DateTime deadline { get; set; }
    }
}
