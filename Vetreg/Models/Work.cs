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
        public int RegionId { get; set; }
        public Region Region { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
        public string CauseId { get; set; }
        public Cause Cause { get; set; }
        public ICollection<Animal> Animals { get; set; }

        public Work()
        {
            Animals = new List<Animal>();
        }


    }
}
