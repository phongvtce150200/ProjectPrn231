using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject
{
    [Table("Doctor")]
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        public string Id { get; set; }
        [ForeignKey("Id")]
        public virtual User Account { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
    }
}