using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApiStudy.Data.Entity;
using WebApiStudy.Data.Repository.EntityRepository.UserRepo;
using WebApiStudy.EntityModel.UserModels;

namespace WebApiStudy.Service.UserServices
{
    public class UserService : IUserService
    {

        public IUserRepository userRepo { get; set; }
        public IMapper mapper { get; set; }

        public UserService(IUserRepository _userRepo, IMapper _mapper)
        {
            userRepo = _userRepo;
            mapper = _mapper;
        }
        public UserModel AddItem(UserModel item)
        {
            User entity = mapper.Map<UserModel, User>(item);
            entity = userRepo.Add(entity);
            item = mapper.Map<User, UserModel>(entity);
            return item;
        }

        public User DeleteItem(int key)
        {

            throw new NotImplementedException();
        }

        public UserModel GetItem(int key)
        {
            UserModel userToReturn = mapper.Map<User, UserModel>(userRepo.Get(key));
            return userToReturn;
        }

        public IEnumerable<UserModel> GetItemsList()
        {
            List<UserModel> usersList = mapper.Map<List<User>, List<UserModel>>(userRepo.GetAll().ToList());
            return usersList;
        }

        public bool UpdateItem(int key, UserModel model)
        {
            if (!userRepo.UserExists(key)) return false;
            try
            {
                User user = mapper.Map<UserModel, User>(model);
                user.ID = key;
                userRepo.Update(user);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
