using System;
using System.ComponentModel.DataAnnotations;

namespace WorkScheduleBlazorApp.Models
{
    public class Shift
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime End { get; set; }
        public virtual User? User { get; set; }
    }
}