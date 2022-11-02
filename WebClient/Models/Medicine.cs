using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace WebClient.Models
{
    public class Medicine
    {
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
