using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebClient.Models
{
    [Table("Medicine")]
    public class Medicine
    {
        [Key]
        public int medicineId { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string medicineName { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public decimal price { get; set; }
        public DateTime expiration { get; set; }
        public int amount { get; set; }
    }
}