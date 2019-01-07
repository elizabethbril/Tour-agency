using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.DTOs;
using BLL;
using TourAgency.Models;
using AutoMapper;
using TourAgency.Ninject;
using BLL.Interfaces;

namespace TourAgency.Controllers
{    
    public class LoginController : ApiController
    {
        public LoginController()
        {
            this.UserLogic = UIDependencyResolver<IUserLogic>.ResolveDependency();
        }
        IUserLogic UserLogic;
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]Wrap wrap)
        {
            UserLogic.Login(wrap.Login, wrap.Password);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
        public class Wrap
        {
            public string Login { get; set; }
            public string Password { get; set; }
        }
    }
}