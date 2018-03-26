namespace Auth.Library.Interfaces
{
    public interface IPassword
    {
        /// <summary>
        /// UserName for User. Is usually Email, but it can be anything
        /// </summary>
        string UserName { get; set; }
        
        /// <summary>
        /// User Password. Never store this in persistant memeory
        /// </summary>
        string Password { get; set; }
    }
}