using System;
using System.Threading.Tasks;
using Auth.Library.Models;
using Auth.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Auth.API.Controllers
{
    [Produces("application/json")]
    [Route("api/client/[action]")]
    public class ClientController : Controller
    {

        private readonly IUserRepository _userRepository;

        public ClientController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Test()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Test2([FromBody] User user)
        {
            if (user != null)
                return Ok(user.UserName);
            else
                return BadRequest();
        }
        
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            try 
            {
                await _userRepository.AddAsync(user);
                return Ok();
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] User user)
        {
            try
            {
                return Ok(await _userRepository.AuthAsync(user));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}