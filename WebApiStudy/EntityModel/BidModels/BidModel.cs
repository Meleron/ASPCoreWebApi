using WebApiStudy.EntityModel.UserModels;

namespace WebApiStudy.EntityModel.BidModels
{
    public class BidModel
    {
        public int ID { get; set; }
        public int Amount { get; set; }
        public int UserID { get; set; }
        public UserModel User { get; set; }
    }
}
