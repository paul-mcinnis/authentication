using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth.Data.Models;
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
            if (modelId != null)
            {
                return await (from User in _context.User where User.ModelId == modelId select User)
                    .FirstOrDefaultAsync();
            }
            
            return null;
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