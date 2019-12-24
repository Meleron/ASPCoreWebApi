using System;
using System.Collections.Generic;
using WebApiStudy.EntityModel.BidModels;

namespace WebApiStudy.EntityModel.UserModels
{
    public class UserModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public DateTime CreationDate { get; set; }
        public List<BidModel> BidsList { get; set; }
    }
}
