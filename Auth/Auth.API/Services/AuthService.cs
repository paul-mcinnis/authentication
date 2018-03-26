using System;
using System.Threading.Tasks;
using Auth.Data.Repository;
using Auth.Data.Repository.Interfaces;
using Auth.Library.Interfaces;
using Auth.Library.Models;

namespace Auth.API.Services
{
    public class AuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Register(IPassword cred)
        {
            //return null if user is already in repo
            if (await _userRepository.GetByName(cred.UserName)) return null;
            try
            {

            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}