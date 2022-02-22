using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkScheduleAPI.DataAccess;
using WorkScheduleAPI.Models;

namespace WorkScheduleAPI.Data
{
    public class ShiftImpl : IShift
    {

        private WorkScheduleContext _ctx;

        public ShiftImpl(WorkScheduleContext ctx)
        {
            _ctx = ctx;
        }
        
        public async Task<IList<Shift>> GetAsync()
        {
            return await _ctx.Shifts.ToListAsync();
        }

        public async Task PostAsync(Shift shift)
        {
            await _ctx.Shifts.AddAsync(shift);
            await _ctx.SaveChangesAsync();
        }
    }
}