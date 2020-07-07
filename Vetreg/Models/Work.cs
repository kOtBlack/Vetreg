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
        public Region Region { get; set; }
        public City City { get; set; }
        public Owner Owner { get; set; }
        public Event Event { get; set; }
        public List<Animal> Animals { get; set; }
    }
}
