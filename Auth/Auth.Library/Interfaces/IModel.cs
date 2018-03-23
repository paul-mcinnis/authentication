using System;
namespace Auth.Library.Interfaces
{
    public interface IModel
    {
        /// <summary>
        /// Unique ID for the model implementing this interface.
        /// </summary>
        int ModelId { get; set; }
        
        /// <summary>
        /// TimeStamp created by the database when the user is added for the first time.
        /// </summary>
        DateTime DateCreated { get; set; }
        
        /// <summary>
        /// Timestamp created by the db, everytime the db is modified
        /// </summary>
        DateTime DateModified { get; set; }
    }
}
