using System;
using System.Threading.Tasks;
using Auth.API.Services;
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
        private readonly AuthService _authService;

        public ClientController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _authService = new AuthService(userRepository);
        }
        
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] Credentials cred)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                if (!await _authService.Register(cred)) return BadRequest();
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
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                return Ok(await _userRepository.AuthAsync(user));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] User user)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                return Ok(await _userRepository.DeactivateAsync(user));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}