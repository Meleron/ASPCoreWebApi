namespace WebApiStudy.Data.Entity
{
    public class Bid
    {
        public int ID { get; set; }
        public int Amount { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
    }
}
