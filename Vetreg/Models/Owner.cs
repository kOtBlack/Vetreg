using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vetreg.Models {
    public class Owner {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string FIO { get; set; }
        public string Phone { get; set; }
        public TypeOwner Type { get; set; }
        public Region RegionId { get; set; }
        public City CityId { get; set; }
        public string Address { get; set; }
    }
}
