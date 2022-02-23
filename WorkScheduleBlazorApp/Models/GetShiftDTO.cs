using System;

namespace WorkScheduleBlazorApp.Models
{
    public class GetShiftDTO
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}