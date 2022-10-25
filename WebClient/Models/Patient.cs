using System;

namespace WebClient.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}
