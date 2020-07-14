using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vetreg.Models {
    public enum Sticker {
        [Display(Name = "Чип")]
        Chip,
        [Display(Name = "Метка")]
        Tag,
        [Display(Name = "Татуировка")]
        Tattoo,
        [Display(Name = "Тавро")]
        Brand,
        [Display(Name = "Болюс")]
        Bolus
    }
}
