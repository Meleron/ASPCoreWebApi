using AutoMapper;
using System;
using WebApiStudy.Data.Entity;
using WebApiStudy.EntityModel.BidModels;
using WebApiStudy.EntityModel.UserModels;

namespace WebApiStudy.MappingProfiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles(/*ApiDbContext dbContext*/)
        {
            CreateMap<User, UserModel>();//.ReverseMap();.ForPath(s=>s.Email, opt=>opt.MapFrom(src=>dbContext.UsersList.Single(u=>u.ID == src.ID).Email));
            CreateMap<UserModel, User>().ForMember(entity => entity.BidsList, option => option.Ignore())
                .ForMember(entity => entity.CreationDate, options => options.MapFrom(tvr => DateTime.Now))
                .ForMember(entity => entity.ID, options => options.Ignore())
                .ForMember(entity => entity.BidsList, options => options.Ignore());
            CreateMap<Bid, BidModel>();
            CreateMap<BidModel, Bid>().ForMember(entity => entity.User, option => option.Ignore())
                .ForMember(entity=>entity.ID, options => options.Ignore());
            CreateMap<User, UserPutModel>();
            CreateMap<UserPutModel, User>();
            CreateMap<Bid, BidPutModel>();
            CreateMap<BidPutModel, Bid>();
            CreateMap<UserPutModel, User>();
            CreateMap<UserPutModel, UserModel>().ForAllOtherMembers(memberOptions=>memberOptions.Condition((src,dest,cond)=> cond != null));
            CreateMap<UserModel, UserPutModel>();
        }

        private class MapBidModelToEntity : IMappingAction<BidModel, Bid>
        {
            private readonly IMapper mapper;
            public MapBidModelToEntity(IMapper _mapper)
            {
                mapper = _mapper;
            }
            public void Process(BidModel source, Bid destination, ResolutionContext context)
            {

            }
        }
    }
}
