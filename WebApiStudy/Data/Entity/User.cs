using System;
using System.Collections.Generic;

namespace WebApiStudy.Data.Entity
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public DateTime CreationDate { get; set; }
        public List<Bid> BidsList { get; set; }
    }
}
