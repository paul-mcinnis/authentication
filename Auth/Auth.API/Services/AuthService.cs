using System.Threading.Tasks;
using Auth.Library.Interfaces;
using Auth.Library.Models;

namespace Auth.API.Services
{
    public class AuthService
    {
        private static AuthService _authService;

        private AuthService() {}

        public static AuthService Instance
        {
            get { return _authService ?? (_authService = new AuthService()); } 
        }
        
        public async Task<User> Register(IPassword cred)
        {
            return null;
        }
    }
}