using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiStudy.Data;
using WebApiStudy.Data.Entity;
using WebApiStudy.Data.Repository.EntityRepository.UserRepo;
using WebApiStudy.EntityModel.UserModels;
using WebApiStudy.Service.UserServices;

namespace WebApiStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        readonly ApiDbContext dbContext;
        readonly IMapper mapper;
        readonly IUserRepository userRepo;
        readonly IUserService userService;

        public UserController(ApiDbContext _dbContext, IMapper _mapper, IUserRepository _userRepo, IUserService _userService)
        {
            mapper = _mapper;
            dbContext = _dbContext;
            userRepo = _userRepo;
            userService = _userService;
        }

        [HttpGet]
        [Route("GetList")]
        public ActionResult<IEnumerable<UserModel>> GetUsersList()
        {
            List<UserModel> usersList = userService.GetItemsList().ToList();
            if (usersList == null) return NotFound();
            return usersList;
        }

        [HttpGet("GetSingle/{id}"/*, Name = "Get"*/)]
        public ActionResult<UserModel> GetUser(int id)
        {
            UserModel user = userService.GetItem(id);
            if (user == null) return NotFound();
            return user;
        }

        [HttpPost("Add")]
        public ActionResult<User> PostUser(UserModel model)
        {
            if (model == null) return BadRequest();
            model = userService.AddItem(model);
            return CreatedAtAction("getUser", new { id = model.ID }, model);
        }

        [HttpPut("Update/{id}")]
        public IActionResult PutUser(int id, UserPutModel model)
        {
            if (userService.UpdateItem(id, mapper.Map<UserPutModel, UserModel>(model)))
                return NoContent();
            else
                return NotFound();
            
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            User user = dbContext.UsersList.FirstOrDefault(u=>u.ID == id);
            if (user == null)
                return NotFound();
            dbContext.UsersList.Remove(user);
            dbContext.SaveChanges();
            return NoContent();
        }
    }
}
