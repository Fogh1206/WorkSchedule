using System.Collections.Generic;
using WorkScheduleBlazorApp.Models;

namespace WorkScheduleBlazorApp.Data
{
    public interface IShift
    {
        public IEnumerable<Shift> GetShiftsFromUserId(int userId);
    }
}