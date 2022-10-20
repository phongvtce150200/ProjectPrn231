using System.ComponentModel.DataAnnotations;
using System;

namespace WebClient.Models
{
    public class scheduleDetails
    {
        public int ScheduleId { get; set; }
        public int DoctorId { get; set; }
        public DateTime StartTime { get; set; } = DateTime.UtcNow;
        [Required]
        public DateTime EndTime { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
