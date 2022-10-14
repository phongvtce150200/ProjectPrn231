using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("InvoiceDetails")]
    public class InvoiceDetails
    {
        [Key]
        public int InvoiceId { get; set; }
        [Key]
        public int MedicineId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(150)")]
        public string Description { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("InvoiceId")]
        public virtual Invoice Invoice { get; set; } 
        [ForeignKey("MedicineId")]
        public virtual Medicine Medicine { get; set; }
    }
}
