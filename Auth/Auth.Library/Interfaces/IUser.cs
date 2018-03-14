using System;
namespace Auth.Library.Interfaces
{
    public interface IUser : IModel
    {
        /// <summary>
        /// UserName for User. Is usually Email, but it can be anything
        /// </summary>
        string UserName { get; set; }
    }
}
