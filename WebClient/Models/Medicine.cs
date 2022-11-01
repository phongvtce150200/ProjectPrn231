using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace WebClient.Models
{
    public class Medicine
    {
        public int MedicineId { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string MedicineName { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public DateTime Expiration { get; set; }
        public int Amount { get; set; }
    }
}
