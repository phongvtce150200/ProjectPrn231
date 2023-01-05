using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Slot
    {
        [Key]
        public int Id { get; set; }
        public string slot { get; set; }
    }
}
