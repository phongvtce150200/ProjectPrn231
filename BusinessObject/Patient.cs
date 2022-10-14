using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject
{
    [Table("Patient")]
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        public string AccountId { get; set; }
        [ForeignKey("AccountId")]
        public virtual User Account { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}