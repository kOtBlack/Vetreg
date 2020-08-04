using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vetreg.Models {
    public enum TypeOwner {
        [Display(Name = "Юридическое лицо")]
        Company,
        [Display(Name = "Физическое лицо")]
        Individual
    }

}
