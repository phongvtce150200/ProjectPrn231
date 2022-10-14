using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("ScheduleDetails")]
    public class ScheduleDetails
    {
        [Key]
        public int ScheduleId { get; set; }
        [Required]
        public DateTime StartTime { get; set; } = DateTime.UtcNow;
        [Required]
        public DateTime EndTime { get; set; }
        public bool IsActive { get; set; } = true;
        [ForeignKey("ScheduleId")]
        public virtual Schedule Schedule { get; set; }
    }
}
