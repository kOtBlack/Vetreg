using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vetreg.Models {
    public class Animal {
        [Key]
        public Guid GUID { get; set; }
        public DateTime AddDate { get; set; }
        public Region RegionId { get; set; }
        public City CityId { get; set; }
        public Owner OwnerId { get; set; }
        public Kind KindId { get; set; }
        public Breed BreedId { get; set; }
        public Suit SuitId { get; set; }
        public Sticker Sticker { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public string ChipNumber { get; set; }
        public DateTime Birthday { get; set; }
        public byte Sex { get; set; }
        public string Remark { get; set; }
        public bool IsRetired { get; set; } = false;
    }
}
