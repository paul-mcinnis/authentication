using System;
using System.Threading.Tasks;
using Auth.Data.Repository.Interfaces;
using Auth.Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Auth.API.Controllers
{
    [Produces("application/json")]
    [Route("api/admin/[action]")]
    public class AdminController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AdminController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] User user)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                await _userRepository.DeleteAsync(user);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> Reactivate([FromBody] User user)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                await _userRepository.ReactivateAsync(user);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}