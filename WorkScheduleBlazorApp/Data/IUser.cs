using System.Threading.Tasks;
using WorkScheduleAPI.Models;
using User = WorkScheduleBlazorApp.Models.User;

namespace WorkScheduleBlazorApp.Data
{
    public interface IUser
    {

        public Task<User> ValidateUser(User user);
        public Task DeleteUser(int userId);

        public Task<User> GetFromIdAsync(int id);

    }
}