using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("ReservedSchedule")]
    public class ReservedSchedule
    {
        [Key]
        public int ReservedScheduleId { get; set; }
        public int AppointmentId { get; set; }
        public int? ScheduleId { get; set; }
        [ForeignKey("AppointmentId")]
        public virtual Appointment Appointment { get; set; }
        [ForeignKey("ScheduleId")]
        public virtual Schedule Schedule { get; set; }
    }
}
