using Microsoft.EntityFrameworkCore;
using WorkScheduleAPI.Models;

namespace WorkScheduleAPI.DataAccess
{
    public class WorkScheduleContext : DbContext
    {
        
        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Shift> Shifts { get; set; }

        public WorkScheduleContext(DbContextOptions<WorkScheduleContext> options):base(options)
        {
        }
        
    }
    
}