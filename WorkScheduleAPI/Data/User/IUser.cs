using System.Collections.Generic;
using System.Threading.Tasks;
using WorkScheduleAPI.Models;

namespace WorkScheduleAPI.Data
{
    public interface IUser
    {
        Task<User> ValidateUser(User user);
        Task PostAsync(User user);
        Task<IList<User>> GetAsync();
    }
}