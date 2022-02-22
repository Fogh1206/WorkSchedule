using System.Threading.Tasks;
using WorkScheduleAPI.Models;
using Company = WorkScheduleBlazorApp.Models.Company;

namespace WorkScheduleBlazorApp.Data
{
    public interface ICompany
    {
        public Task<Company> CreateCompany(Company company);
    }
}