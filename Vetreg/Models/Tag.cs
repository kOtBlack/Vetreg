using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Vetreg.Models {
    public class Tag {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        //[InverseProperty(nameof(Animal.GUID))]
        //[Required]
        public Guid AnimalId { get; set; }
        public virtual Animal Animal { get; set; }
    }
}
