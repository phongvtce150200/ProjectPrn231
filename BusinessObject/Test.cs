using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("Test")]
    public class Test
    {
        [Key]
        public int TestId { get; set; }
        public int AppointmentId { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        [Required]
        public string Result { get; set; }
        [ForeignKey("AppointmentId")]
        public virtual Appointment Appointment { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}
