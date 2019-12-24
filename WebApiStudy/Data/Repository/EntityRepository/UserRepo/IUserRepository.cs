using System.Collections.Generic;

namespace WebApiStudy.Data.Repository.EntityRepository.UserRepo
{
    public interface IUserRepository : IRepository<Entity.User>
    {
        public IEnumerable<Entity.User> GetUsersAgeSorted(bool isDescenfing);
        public bool UserExists(int id);
    }
}
