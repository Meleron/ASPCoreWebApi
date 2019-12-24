using System;

namespace WebApiStudy.EntityModel.UserModels
{
    public class UserPutModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
