using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("Roles")]
    public class Roles
    {
        [Key]
        public int RoleId { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string RoleName { get; set; }
        public ICollection<AccountRoles> AccountRoles { get; set; }
    }
}
