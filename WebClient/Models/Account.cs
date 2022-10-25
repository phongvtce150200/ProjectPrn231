using BusinessObject;
using System;

namespace WebClient.Models
{
    public class Account
    {
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
    }
    public enum Gender { 
        Male = 1,
        Female = 0
    }
}