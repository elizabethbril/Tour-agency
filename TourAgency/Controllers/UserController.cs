using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TourAgency.Models;
using TourAgency.Ninject;

namespace TourAgency.Controllers
{
    public class UserController : ApiController
    {
        public UserController()
        {
            this.UserLogic = UIDependencyResolver<IUserLogic>.ResolveDependency();
        }
        public UserController(IUserLogic UserLogic)
        {
            this.UserLogic = UserLogic;
        }

        IUserLogic UserLogic;

        IMapper UserControllerMapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<UserDTO, UserModel>();
            cfg.CreateMap<UserModel, UserDTO>();
        }).CreateMapper();

        // GET api/<controller>
        public IEnumerable<UserModel> Get()
        {
            return UserControllerMapper.Map<IEnumerable<UserDTO>, IEnumerable<UserModel>>(UserLogic.GetAllUsers());
        }

        // GET api/<controller>/5
        public UserModel Get(int Id)
        {
            return UserControllerMapper.Map<UserDTO, UserModel>(UserLogic.GetUser(Id));
        }

        // POST api/<controller>
        public void Post([FromBody]UserModel User)
        {
            UserLogic.AddUser(UserControllerMapper.Map<UserModel, UserDTO>(User));
        }

        // PUT api/<controller>/5
        public void Put(int Id, [FromBody]UserModel User)
        {
            UserLogic.EditUser(Id, UserControllerMapper.Map<UserModel, UserDTO>(User));
        }

        // DELETE api/<controller>/5
        public void Delete(int Id)
        {
            UserLogic.DeleteUser(Id);
        }
    }
}
