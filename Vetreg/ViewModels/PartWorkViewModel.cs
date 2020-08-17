using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vetreg.Models;

namespace Vetreg.ViewModels {
    public class PartWorkViewModel {
        public DateTime Date { get; set; }
        public int CauseId { get; set; }
        public int DiseaseId { get; set; }
        public string OwnerType { get; set; }

        public IEnumerable<CheckAnimal> AnimalsList { get; set; } = new List<CheckAnimal>();
    }
}
