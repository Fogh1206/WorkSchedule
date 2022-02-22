using System.Collections.Generic;
using System.Threading.Tasks;
using WorkScheduleAPI.Models;

namespace WorkScheduleAPI.Data
{
    public interface ICompany
    {
        Task PostAsync(Company company);
        Task<IEnumerable<Company>> GetAsync();
        Task<Company> GetByIdAsync(int id);
    }
}