using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("Appointment")]
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        public int? PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        [StringLength(50)]
        public string Reason { get; set; }
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }
        [ForeignKey("DoctorId")]
        public virtual Doctor Doctor { get; set; }
        public ICollection<Test> Tests { get; set; }
        public ICollection<ReservedSchedule> ReservedSchedules { get; set; }
    }
}
