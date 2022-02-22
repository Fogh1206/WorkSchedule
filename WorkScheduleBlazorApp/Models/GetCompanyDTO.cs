using System.Collections.Generic;
using WorkScheduleAPI.Models;

namespace WorkScheduleBlazorApp.Models
{
    public class GetCompanyDTO
    {
        public string Name { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}