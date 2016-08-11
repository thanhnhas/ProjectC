using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Tier.Entities
{
    public class NewBook
    {
        public string username { get; set; }
        public string BookName { get; set; }
        public string author { get; set; }
        public string year { get; set; }
        public string description { get; set; }
        public bool status { get; set; }
    }
}
