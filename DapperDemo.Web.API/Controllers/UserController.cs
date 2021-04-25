using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DapperDemo.Web.API.Controllers
{
    [EnableCors("*","*","*")]
    public class UserController : ApiController
    {
        // GET: api/users
        [HttpGet]
        [Route("api/users")]
        public IHttpActionResult GetUsers()
        {
            return Ok(DataAccess.GetUsers());
        }


        // POST: api/user/isvalid
        [HttpPost]
        [Route("api/user/isvalid")]
        public IHttpActionResult UserIsValid([FromBody] User user)
        {
            if (DataAccess.UserIsValid(user.Username, user.Password))
                return Ok(true);


            return BadRequest();
        }


        [HttpGet]
        [Route("api/username/isvalid/{username}")]
        public IHttpActionResult UsernameIsValid([FromUri] string username)
        {
            if (DataAccess.UsernameIsValid(username))
                return Ok(true);

            return BadRequest();
        }



        // DELETE: api/user/delete
        [HttpDelete]
        [Route("api/user/delete")]
        public IHttpActionResult DeleteUser([FromBody] User user)
        {
            if (DataAccess.DeleteUser(user.Username, user.Password))
                return Ok($"{user.Username} was deleted successfully!");

            return BadRequest();
        }



        // POST: api/user/create
        [HttpPost]
        [Route("api/user/create")]
        public IHttpActionResult CreateUser([FromBody] User user)
        {
             if (DataAccess.CreateUser(user.Username, user.Password))
                 return Ok("User was created successfully!");

            return Conflict();

                
        }


        // PUT: api/users/updatepassword
        [HttpPut]
        [Route("api/user/updatepassword")]
        public IHttpActionResult ChangePassword([FromBody] User user)
        {
            return Ok(DataAccess.ChangePassword(user.Username, user.Password));
        }
    }
}
