using System;
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

        public async Task<bool> DeactivateAsync(IUser user)
        {
            if (user == null) return false;
            try
            {
                var toDeactivate = await _context.User.FirstOrDefaultAsync(u => u.UserName == user.UserName);

                if (toDeactivate == null || toDeactivate.IsActive != true) return false;
            
                toDeactivate.IsActive = false;
                _context.User.Update(toDeactivate);
                _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            
            return true;
        }

        public async Task<bool> ReactivateAsync(IUser user)
        {
            if (user == null) return false;
            try
            {
                var toReactivate = await _context.User.FirstOrDefaultAsync(u => u.UserName == user.UserName);

                if (toReactivate == null) return false;
                toReactivate.IsActive = true;
                _context.User.Update(toReactivate);
                _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }
    }
}