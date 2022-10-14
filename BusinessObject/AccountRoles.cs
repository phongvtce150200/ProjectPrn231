using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("AccountRoles")]
    public class AccountRoles
    {
        [Key]
        public int AccountId { get; set; }
        [Key]
        public int RoleId { get; set; }
        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }
        [ForeignKey("RoleId")]
        public virtual Roles Roles { get; set; }
    }
}
