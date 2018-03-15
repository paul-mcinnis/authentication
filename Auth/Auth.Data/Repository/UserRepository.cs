using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth.Library.Models;
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

        private async Task<IUser> GetByName(IUser user)
        {
            return await (from User in _context.User where User.UserName == user.UserName select User).FirstOrDefaultAsync();
        }
        
        public async Task<IUser> AddAsync(IUser user)
        {
            if (GetByName(user).Result != null) return null;
            var ToAdd = new User()
            {
                UserName = user.UserName
            };
            
            await _context.User.AddAsync(ToAdd);
            await _context.SaveChangesAsync();
            
            return user;
        }

        public async Task DeleteAsync(IUser user)
        {
            _context.User.Remove(await _context.User.FirstOrDefaultAsync(r => r.UserName == user.UserName));
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<IUser>> GetAllAsync()
        {
            return await (from User in _context.User select User).ToListAsync();
        }

        public async Task<bool> AuthAsync(IUser user)
        {
            var toAuth = await _context.User.FirstOrDefaultAsync(u => u.UserName == user.UserName);

            return (toAuth != null);
        }

        public async Task<bool> UpdateNameAsync(IUser user, string newName)
        {
            if(newName == null || await _context.User.FirstOrDefaultAsync(u => u.UserName == user.UserName) != null) return false;
            var toUpdate = await _context.User.FirstOrDefaultAsync(u => u.UserName == user.UserName);

            if (toUpdate != null)
            {
                toUpdate.UserName = newName;
                _context.User.Update(toUpdate);
                _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}