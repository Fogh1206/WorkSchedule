using System.Collections.Generic;
using System.Threading.Tasks;
using WorkScheduleAPI.Models;

namespace WorkScheduleAPI.Data
{
    public interface IShift
    {
        Task<IEnumerable<Shift>> GetAsync();
        Task<IEnumerable<GetShiftDTO>> GetFromUserIdAsync(int userId);
        Task PostAsync(Shift shift);
    }
}