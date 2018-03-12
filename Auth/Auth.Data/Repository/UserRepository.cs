using System.Collections.Generic;
using System.Threading.Tasks;
using Auth.Data.Models;
using Auth.Library.Interfaces;

namespace Auth.Data.Repository
{
    public class UserRepository : IUserRepository
    {

        private AuthDbContext _context;

        public UserRepository(AuthDbContext context)
        {
            _context = context;
        }
        
        public async Task<IUser> AddAsync(IUser model)
        {
            var ToAdd = new User()
            {
                UserName = model.UserName
            };
            
            await _context.User.AddAsync(ToAdd);
            await _context.SaveChangesAsync();
            return model;
        }
        
        public Task<IUser> GetByIdAsync(int modelId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<IUser>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }


        public Task UpdateAsync(IUser model)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(IUser model)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteByIdAsync(int modelId)
        {
            throw new System.NotImplementedException();
        }
    }
}