using System.Collections.Generic;
using System.Threading.Tasks;

namespace Auth.Library.Interfaces
{
    /// <summary>
    /// Defines methods for any class that implements the Repository pattern
    /// within the identity service.
    /// </summary>
    public interface IRepository<T> where T : IModel
    {
        /// <summary>
        /// Get all from the data collection as an enumerable set.
        /// </summary>
        /// <returns>An <c>IEnumerable</c> containing all in the data collection</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Adds the given model to the underlying data set asynchronously.
        /// </summary>
        /// <param name="model">The model to add</param>
        /// <returns>The updated copy of the added model</returns>
        Task<T> AddAsync(T model);

        /// <summary>
        /// Updates the given model in the underlying data asynchronously.
        /// </summary>
        /// <param name="model">The model to update</param>
        Task UpdateAsync(T model);

        /// <summary>
        /// Deletes the given model from the underlying data asynchronously.
        /// </summary>
        /// <param name="model">The model to delete</param>
        Task DeleteAsync(T model);

        /// <summary>
        /// Deletes the model with the given unique model ID from the
        /// underlying data set asynchronously.
        /// </summary>
        /// <param name="modelId">The ID of the model to delete</param>
        Task DeleteByIdAsync(int modelId);
    }
}