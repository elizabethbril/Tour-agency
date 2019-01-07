using TourAgency.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TourAgency.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            using (var context = new ApplicationDbContext())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                return Ok(roleManager.Roles);
            }
        }

        // GET api/<controller>/5
        [Route("api/roles/{roleName}")]
        public async System.Threading.Tasks.Task<IHttpActionResult> GetAsync(string roleName)
        {
            using (var context = new ApplicationDbContext())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                return Ok(await roleManager.FindByNameAsync(roleName));
            }
        }

        // POST api/<controller>
        public async System.Threading.Tasks.Task<IHttpActionResult> PostAsync([FromBody]string roleName)
        {
            using (var context = new ApplicationDbContext())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                await roleManager.CreateAsync(new IdentityRole() { Name = roleName });
                return Ok();
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public async System.Threading.Tasks.Task<IHttpActionResult> DeleteAsync(string roleName)
        {
            using (var context = new ApplicationDbContext())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = await roleManager.FindByNameAsync(roleName);

                await roleManager.DeleteAsync(role);
                return Ok();
            }
        }
    }
}