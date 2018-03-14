using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth.Data.Models;
using Auth.Data.Repository.Interfaces;
using Auth.Library.Interfaces;
using Microsoft.EntityFrameworkCore;

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
        
        public async Task<IUser> GetByIdAsync(int modelId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<IUser>> GetAllAsync()
        {
            return await (from User in _context.User select User).ToListAsync();
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

        public async Task<bool> AuthAsync(IUser user)
        {
            var ToAuth = await _context.User.FirstOrDefaultAsync(u => u.UserName == user.UserName);

            return (ToAuth != null);
        }
    }
}