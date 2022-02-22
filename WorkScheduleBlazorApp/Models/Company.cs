using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace WorkScheduleBlazorApp.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<WorkScheduleBlazorApp.Models.User> Users { get; set; }

    }
}