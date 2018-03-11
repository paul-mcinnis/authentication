using System;
namespace Auth.Library.Interfaces
{
    public interface IModel
    {
        /// <summary>
        /// Unique ID for the model implementing this interface.
        /// </summary>
        int ModelId { get; set; }
    }
}
