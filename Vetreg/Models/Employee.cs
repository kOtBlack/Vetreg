using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vetreg.Models {
    public class Employee : IdentityUser {
        public Company Company { get; set; }
        public string Specialization { get; set; }
    }
}
