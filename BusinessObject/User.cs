using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("User")]
    public class User : IdentityUser
    {
        [Column(TypeName = "nvarchar(50)")]
        [RegularExpression(@"^[a-zA-Z'-\s]{1,40}$", ErrorMessage = "The field {0} is not a valid name")]
        public string FullName { get; set; }
        public Gender Gender { get; set; } //Female is 0 Male is 1
        public DateTime Birhtday { get; set; }
        [StringLength(250)]
        [Column(TypeName = "nvarchar(250)")]
        public string Address { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<Patient> Patients { get; set; }
    }

    public enum Gender
    {
        Male = 1,
        Female = 0
    }


}
