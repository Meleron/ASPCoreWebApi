using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApiStudy.Data.Entity;

namespace WebApiStudy.Data.Repository.EntityRepository.BidRepo
{
    public class BidRepository : Repository<Bid>, IBidRepository
    {
        protected readonly ApiDbContext apiContext;
        protected readonly IMapper mapper;

        public BidRepository(ApiDbContext _dbContext, IMapper _mapper) : base(_dbContext)
        {
            apiContext = _dbContext;
            mapper = _mapper;
        }

        public override Bid Get(int id)
        {
            return apiContext.BidsList.Include(b => b.User).FirstOrDefault(b => b.ID == id);
        }

        public override IEnumerable<Bid> GetAll()
        {
            return apiContext.BidsList.Include(b => b.User).ToList();
        }

        public IEnumerable<Bid> GetMostExpensiveBids(int count)
        {
            return apiContext.BidsList.OrderByDescending(b => b.Amount).Take(count).ToList();
        }

        public bool BidExists(Bid bid)
        {
            return apiContext.BidsList.Any(b => b.ID == bid.ID);
        }
    }
}
