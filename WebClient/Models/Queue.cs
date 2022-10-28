using System;
using System.ComponentModel.DataAnnotations;

namespace WebClient.Models
{
    public class Queue
    {
        [Required]
        public int DocId { get; set; }
        [Required]
        public int PatientId { get; set; }
        [Required]
        public string PatientFullName { get; set; }
        [Required]
        public DateTime PatientBirthDay { get; set; }
        [Required]
        public string PatientGender { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        public float Pusle { get; set; }
        [Required]
        public float BloodPressure { get; set; }
        [Required]
        public float Temperature { get; set; }
        [Required]
        public float Weight { get; set; }
        [Required]
        public float Height { get; set; }
        [Required]
        public bool Status { get; set; } = true;
    }
}
