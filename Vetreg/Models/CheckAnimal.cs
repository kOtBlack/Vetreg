using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vetreg.Models {
    public class CheckAnimal {
        public Guid AnimalId { get; set; }
        public string ChipNumber { get; set; }
        public int OwnerId { get; set; }
        public bool IsChected { get; set; }
    }
}
