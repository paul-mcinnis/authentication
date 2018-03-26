using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CryptSharp.Utility;
using Auth.Data.Repository.Interfaces;
using Auth.Library.Interfaces;
using Auth.Library.Models;

namespace Auth.API.Services
{
    public class AuthService
    {
        private const int Maxsaltlength = 16;
        private const int Cost = 16384; // 2^14
        private const int BlockSize = 8;
        private const int Parallel = 1;
        private const int MaxThreads = 1;
        private const int DerivedKeyLength = 128;
        
        private readonly IUserRepository _userRepository;
        private static readonly RNGCryptoServiceProvider _rngCsp = new RNGCryptoServiceProvider();

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        private static byte[] GenerateSalt()
        {
            byte[] salt;
            _rngCsp.GetBytes(salt = new byte[Maxsaltlength]);

            return salt;
        }
        
        private static string Hash(string password, byte[] salt)
        {
            var digest = SCrypt.ComputeDerivedKey(Encoding.UTF8.GetBytes(password), salt, Cost, BlockSize, Parallel,
                MaxThreads, DerivedKeyLength);
            
            return Convert.ToBase64String(digest);
        }
        
        public async Task<bool> Register(IPassword cred)
        {
            try
            {
                var salt = GenerateSalt();
                
                var user = new User()
                {
                    UserName = cred.UserName,
                    PasswordDigest = Hash(cred.Password, salt),
                    PasswordSalt = salt
                };
                if (await _userRepository.AddAsync(user) != null)
                    return true;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
            }
            return false;
        }
    }
}