using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject
{
    [Table("Prescription")]
    public class Prescription
    {
        [Key]
        public int PrescriptionId { get; set; }
        public int TestId { get; set; }
        [ForeignKey("TestId")]
        public virtual Test Test { get; set; }
        public ICollection<PrescriptionDetails> PrescriptionDetails { get; set; }
    }
}