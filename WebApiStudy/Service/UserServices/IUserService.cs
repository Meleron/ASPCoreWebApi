using WebApiStudy.Data.Entity;
using WebApiStudy.EntityModel.UserModels;

namespace WebApiStudy.Service.UserServices
{
    public interface IUserService : ICrudService<User, UserModel>
    {
    }
}
