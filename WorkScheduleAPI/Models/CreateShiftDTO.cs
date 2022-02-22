using System;

namespace WorkScheduleAPI.Models
{
    public class CreateShiftDTO
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}