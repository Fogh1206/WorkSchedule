using System.Collections.Generic;

namespace WorkScheduleAPI.Models
{
    public class GetCompanyDTO
    {
        public string Name { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}