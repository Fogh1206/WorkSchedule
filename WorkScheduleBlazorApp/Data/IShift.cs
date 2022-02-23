using System.Collections.Generic;
using System.Threading.Tasks;
using WorkScheduleBlazorApp.Models;

namespace WorkScheduleBlazorApp.Data
{
    public interface IShift
    {
        public Task<List<GetShiftDTO>> GetShiftsFromUserId(int userId);
    }
}