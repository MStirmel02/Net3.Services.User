using Microsoft.AspNetCore.Mvc;
using Net3.Services.User.UserServices.Models;
using System.ComponentModel.DataAnnotations;
using UserServices.Services;

namespace Net3.Services.User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;

        public UserController(IUserService userService) 
        {
            _userService = userService;
        }

        // GET api/<ValuesController>/5
        [HttpGet("/login/{id}")]
        public UserModel LoginUser([Required] int id)
        {
            try
            {

            } 
            catch 
            {
                throw;
            }
            throw new NotImplementedException();

        }

        // POST api/<ValuesController>
        [HttpPost]
        [Route("/signin")]
        public async Task<bool> SignupUserAsync([FromBody][Required] UserModel user)
        {
            try
            {
                return await _userService.UserSignupAsync(user); 
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
