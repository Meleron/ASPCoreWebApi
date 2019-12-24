using WebApiStudy.Data.Entity;
using WebApiStudy.EntityModel.BidModels;

namespace WebApiStudy.Service.BidServices
{
    public interface IBidService : ICrudService<Bid, BidModel>
    {
    }
}
