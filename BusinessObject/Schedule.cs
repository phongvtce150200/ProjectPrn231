using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject
{
    [Table("Schedule")]
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }
        public int DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public virtual Doctor Doctor { get; set; }
        public ICollection<ScheduleDetails> ScheduleDetails { get; set; }
        public ICollection<ReservedSchedule> ReservedSchedules { get; set; }    
    }
}