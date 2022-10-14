using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("PrescriptionDetails")]
    public class PrescriptionDetails
    {
        [Key]
        public int PrescriptionId { get; set; }
        [Key]
        public int MedicineId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        [ForeignKey("PrescriptionId")]
        public virtual Prescription Prescription { get; set; }
        [ForeignKey("MedicineId")]
        public virtual Medicine Medicine { get; set; }
    }
}
