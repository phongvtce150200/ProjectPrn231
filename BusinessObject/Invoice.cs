using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("Invoice")]
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        public int TestId { get; set; }
        [Column(TypeName = "money")]
        public decimal Money { get; set; }
        [ForeignKey("TestId")]
        public virtual Test Test { get; set; }
    }
}
