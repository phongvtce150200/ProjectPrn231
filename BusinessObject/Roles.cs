using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Roles
    {
        public const string Admin = "Admin";
        public const string Doctor = "Doctor";
        public const string Nurse = "Nurse";
        public const string Patient = "Patient";

    }
}
