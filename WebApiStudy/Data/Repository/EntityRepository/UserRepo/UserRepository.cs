using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApiStudy.Data.Entity;
using WebApiStudy.Data.Repository.EntityRepository.UserRepo;

namespace WebApiStudy.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {

        protected readonly ApiDbContext apiContext;
        protected readonly IMapper mapper;

        public UserRepository(ApiDbContext _dbContext, IMapper _mapper): base(_dbContext)
        {
            apiContext = _dbContext;
            mapper = _mapper;
        }
        public override User Get(int id)
        {
            return apiContext.UsersList.Include(u => u.BidsList).FirstOrDefault(u => u.ID == id);
        }

        public override IEnumerable<User> GetAll()
        {
            return apiContext.UsersList.Include(u => u.BidsList).ToList();
        }

        public IEnumerable<User> GetUsersAgeSorted(bool isDescenfing)
        {
            var usersAgeSorted = apiContext.UsersList.OrderByDescending(u => u.Age);
            return isDescenfing ? usersAgeSorted.ToList() : usersAgeSorted.Reverse().ToList();
        }

        public bool UserExists(int id)
        {
            return apiContext.UsersList.Any(u => u.ID == id);
        }
    }
}
