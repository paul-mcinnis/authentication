using System;
using System.Threading.Tasks;
using Auth.Data.Repository.Interfaces;
using Auth.Library.Interfaces;
using Auth.Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Tests.UnitTests.Helpers
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
                var resp = await _userRepository.AuthAsync(user);
                return Ok(resp);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}