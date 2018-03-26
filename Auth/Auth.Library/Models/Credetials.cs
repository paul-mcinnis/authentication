using System;
using Auth.Library.Interfaces;

namespace Auth.Library.Models
{
    public class Credentials : IPassword
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}