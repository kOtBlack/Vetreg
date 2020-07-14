using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vetreg.Models {
    public class Company {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Chief { get; set; }
        public int RegionId { get; set; }
        //public Region Region { get; set; }
        public int CityId { get; set; }
        //public City City { get; set; }
        public string Address { get; set; }
    }
}
