using System.Collections.Generic;
using WebApiStudy.Data.Entity;
using WebApiStudy.Data.Repository.EntityRepository.UserRepo;

namespace WebApiStudy.Data.Repository.EntityRepository.BidRepo
{
    public interface IBidRepository : IRepository<Bid>
    {
        //public Entity.Bid Add(Entity.Bid entity);
        //public void AddRange(IEnumerable<BidModel> models);
        public IEnumerable<Entity.Bid> GetMostExpensiveBids(int count);
        public bool BidExists(Entity.Bid bid);
    }
}
