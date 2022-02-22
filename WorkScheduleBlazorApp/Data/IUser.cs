using System.Threading.Tasks;
using WorkScheduleAPI.Models;
using User = WorkScheduleBlazorApp.Models.User;

namespace WorkScheduleBlazorApp.Data
{
    public interface IUser
    {

        public Task<User> ValidateUser(User user);

    }
}