using System.Collections.Generic;
using System.Threading.Tasks;
using WorkScheduleAPI.Models;

namespace WorkScheduleAPI.Data
{
    public interface IShift
    {
        Task<IList<Shift>> GetAsync();
        Task PostAsync(Shift shift);
    }
}