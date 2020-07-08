using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vetreg.Models {
    public class Employee : IdentityUser {

        public Company CompanyId { get; set; }
        public string Specialization { get; set; }
    }
}
