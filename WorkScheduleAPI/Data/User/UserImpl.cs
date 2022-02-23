using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkScheduleAPI.DataAccess;
using WorkScheduleAPI.Models;

namespace WorkScheduleAPI.Data
{
    public class UserImpl : IUser
    {
        
        private readonly WorkScheduleContext _ctx;
      
        public UserImpl(WorkScheduleContext ctx)
        {
            _ctx = ctx;
           
        }
        
        public async Task<User> ValidateUser(User user)
        {
            Console.WriteLine("Username : " + user.Username);
            Console.WriteLine("Password : " + user.Password);
            return await _ctx.Users.FirstAsync(a => a.Username.Equals(user.Username) && 
                                         a.Password.Equals(user.Password));
        }

        public async Task PostAsync(User user)
        {
            await _ctx.Users.AddAsync(user);
            await _ctx.SaveChangesAsync();
        }

        public async Task<IList<User>> GetAsync()
        {
            return await _ctx.Users.ToListAsync();
        }
        
        public async Task<User> GetByIdAsync(int id)
        {
            return await _ctx.Users.FirstAsync(c => c.Id == id);
        }
    }
}