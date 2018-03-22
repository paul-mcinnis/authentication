using System.Threading.Tasks;
using Auth.Library.Interfaces;

namespace Auth.Data.Repository.Interfaces
{
    /// <inheritdoc />
    /// <summary>
    /// Defines repositories that manage CRUD operations for IRole types.
    /// </summary>
    public interface IUserRepository : IRepository<IUser>
    {
        Task<bool> AuthAsync(IUser user);

        Task<bool> DeactivateAsync(IUser user);

        Task<bool> ReactivateAsync(IUser user);
    }
}