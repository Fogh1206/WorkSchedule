using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkScheduleAPI.DataAccess;
using WorkScheduleAPI.Models;

namespace WorkScheduleAPI.Data
{
    public class CompanyImpl : ICompany
    {

        private readonly WorkScheduleContext _ctx;

        public CompanyImpl(WorkScheduleContext ctx)
        {
            _ctx = ctx;
        }
        
        public async Task PostAsync(Company company)
        {
            await _ctx.Companies.AddAsync(company);
            await _ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<Company>> GetAsync()
        {
            return await _ctx.Companies.ToListAsync();
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            return await _ctx.Companies.FirstAsync(c => c.Id == id);
        }
    }
}