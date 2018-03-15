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
    }
}
