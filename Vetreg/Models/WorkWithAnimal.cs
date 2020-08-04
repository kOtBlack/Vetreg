using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vetreg.Models {
    public class WorkWithAnimal {
        public Guid AnimalId { get; set; }
        public Animal Animal { get; set; }
        public Guid WorkId { get; set; }
        public Work Work { get; set; }
    }
}
