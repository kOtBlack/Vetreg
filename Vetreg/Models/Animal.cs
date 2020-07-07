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
        public Region Region { get; set; }
        public City City { get; set; }
        public Owner Owner { get; set; }
        public Kind Kind { get; set; }
        public Breed Breed { get; set; }
        public Suit Suit { get; set; }
        public Sticker Sticker { get; set; }
        public List<Tag> Tags { get; set; }
        public string ChipNumber { get; set; }
        public DateTime Birthday { get; set; }
        public byte Sex { get; set; }
        public string Remark { get; set; }
        public bool IsRetired { get; set; }
    }
}
