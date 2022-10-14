using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject
{
    [Table("Medicine")]
    public class Medicine
    {
        [Key]
        public int MedicineId { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string MedicineName { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public DateTime Expiration { get; set; }
        public int Amount { get; set; }
        public ICollection<InvoiceDetails> InvoiceDetails { get; set; }
        public ICollection<PrescriptionDetails> Prescriptions { get; set; }
    }
}