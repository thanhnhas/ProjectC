using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Tier.Entities
{
    public class Book
    {
        public String ISBN { get; set; }
        public String Name { get; set; }
        public String TypeID { get; set; }
        public String AuthorID { get; set; }
        public String PublisherID { get; set; }
        public int Quantity { get; set; }
    }
}
