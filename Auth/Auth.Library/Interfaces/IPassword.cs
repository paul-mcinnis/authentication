namespace Auth.Library.Interfaces
{
    public interface IPassword : IModel
    {
        /// <summary>
        /// UserName for User. Is usually Email, but it can be anything
        /// </summary>
        string UserName { get; set; }
        
        /// <summary>
        /// saves hashed password
        /// </summary>
        string Password { get; set; }
    }
}