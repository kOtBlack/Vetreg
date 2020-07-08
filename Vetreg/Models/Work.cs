using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vetreg.Models {
    public class Work {
        [Key]
        public Guid GUID { get; set; }
        public DateTime Date { get; set; }
        public Region RegionId { get; set; }
        public City CityId { get; set; }
        public Owner OwnerId { get; set; }
        public Cause CauseId { get; set; }
        public ICollection<Animal> Animals { get; set; }
    }
}
