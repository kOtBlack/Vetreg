using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vetreg.Models;

namespace Vetreg.ViewModels {
    public class OwnerAnimals {
        public Owner Owner { get; set; }
        public IEnumerable<Animal> Animals { get; set; }
    }
}
