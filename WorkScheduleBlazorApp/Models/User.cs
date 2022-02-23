using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WorkScheduleBlazorApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        public double Salary { get; set; }
        public virtual IEnumerable<Shift> Shifts { get; set; }
        public virtual Company? Company { get; set; }

    }
}