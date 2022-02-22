using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WorkScheduleBlazorApp.Models
{
    public class User
    {
        [Key]
        [JsonPropertyOrder(0)]
        public int Id { get; set; }
        [Required]
        [JsonPropertyOrder(1)]
        public string Username { get; set; }
        [Required]
        [JsonPropertyOrder(2)]
        public string? Password { get; set; }
        [Required]
        [JsonPropertyOrder(3)]
        public string? FirstName { get; set; }
        [Required]
        [JsonPropertyOrder(4)]
        public string? LastName { get; set; }
        [JsonPropertyOrder(5)]
        public double Salary { get; set; }
        [JsonPropertyOrder(6)]
        public virtual IEnumerable<Shift> Shifts { get; set; }
        [JsonPropertyOrder(7)]
        public virtual Company? Company { get; set; }

    }
}