using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("Account")]
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        [StringLength(18,MinimumLength = 6,ErrorMessage = "Password must be 6 - 18 character")]
        [Column(TypeName = "nvarchar(50)")]
        public string Password { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [RegularExpression(@"^[a-zA-Z'-\s]{1,40}$", ErrorMessage = "The field {0} is not a valid name")]
        public string FullName { get; set; }
        public Gender Gender { get; set; } //Female is 0 Male is 1
        public DateTime Birhtday { get; set; }
        [StringLength(250)]
        [Column(TypeName = "nvarchar(250)")]
        public string Address { get; set; }
        [Phone]
        [StringLength(10, ErrorMessage = "Phone Number must be 10 digit")]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<Patient> Patients { get; set; }
        public ICollection<AccountRoles> AccountRoles { get; set; }
    }

    public enum Gender 
    {
      Male = 1,
      Female = 2
    }
}
