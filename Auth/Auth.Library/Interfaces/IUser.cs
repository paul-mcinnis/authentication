using System;
namespace Auth.Library.Interfaces
{
    public interface IUser : IModel
    {
        /// <summary>
        /// UserName for User. Is usually Email, but it can be anything
        /// </summary>
        string UserName { get; set; }
        
        /// <summary>
        /// nobody is truy deleted, their account is either active or inactive
        /// </summary>
        bool? IsActive { get; set; }
        
        /// <summary>
        /// saves hashed password
        /// </summary>
        string PasswordDigest { get; set; }
        
        /// <summary>
        /// Salt appended to the password before it is hashed
        /// </summary>
        string PasswordSalt { get; set; }
    }
}
