﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Vetreg.Models {
    public class Animal {
        [Key]
        public Guid GUID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime AddDate { get; set; } = DateTime.Now;
        public int RegionId { get; set; }
        public Region Region { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
        public int KindId { get; set; }
        public Kind Kind { get; set; }
        public int BreedId { get; set; }
        public Breed Breed { get; set; }
        public int SuitId { get; set; }
        public Suit Suit { get; set; }
        public Sticker Sticker { get; set; }
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
        public ICollection<WorkWithAnimal> WorksWithAnimal { get; set; } = new List<WorkWithAnimal>();

        public string ChipNumber { get; set; }

        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }
        [NotMapped]
        public byte Gender { get; set; } = 1;
        public string Remark { get; set; }
        public bool IsRetired { get; set; } = false;

        //public ICollection<Tag> Works { get; set; }


        public Animal() {
        }
    }
}
