using System.Collections;
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
        
        public async Task<IEnumerable<Shift>> GetAsync()
        {
            return await _ctx.Shifts.ToListAsync();
        }

        public async Task<IEnumerable<GetShiftDTO>> GetFromUserIdAsync(int id)
        {
            List<Shift> allShifts = await _ctx.Shifts.ToListAsync();
            IList sortedShifts = new List<GetShiftDTO>();

            foreach (var shift in allShifts)
            {
                if (shift.User != null && shift.User.Id == id)
                {

                    GetShiftDTO getShiftDto = new GetShiftDTO()
                    {
                        Id = shift.Id,
                        Start = shift.Start,
                        End = shift.End
                    };
                    sortedShifts.Add(getShiftDto);
                }
            }

            return (IEnumerable<GetShiftDTO>) sortedShifts;
        }

        public async Task PostAsync(Shift shift)
        {
            await _ctx.Shifts.AddAsync(shift);
            await _ctx.SaveChangesAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _ctx.Users.FirstAsync(c => c.Id == id);
        }
    }
}