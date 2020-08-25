using System;
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
        [Display(Name = "Дата добавления")]
        public DateTime AddDate { get; set; } = DateTime.Now;
        [Display(Name = "Регион")]
        public int RegionId { get; set; }
        public Region Region { get; set; }
        [Display(Name = "Город")]
        public int CityId { get; set; }
        public City City { get; set; }
        [Display(Name = "Владелец")]
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
        [Display(Name = "Вид")]
        public int KindId { get; set; }
        public Kind Kind { get; set; }
        [Display(Name = "Порода")]
        public int BreedId { get; set; }
        public Breed Breed { get; set; }
        [Display(Name = "Масть")]
        public int SuitId { get; set; }
        public Suit Suit { get; set; }
        [Display(Name = "Метка")]
        public Sticker Sticker { get; set; }
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
        [Display(Name = "Мероприятия")]
        public List<WorkWithAnimal> WorksWithAnimal { get; set; } = new List<WorkWithAnimal>();
        [Display(Name = "Номер")]
        public string ChipNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM.yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата рождения")]
        public DateTime Birthday { get; set; } 
        //{
        //    get {
        //        DateTime dAge = DateTime.MinValue + (TimeSpan)(DateTime.Now - birthday);
        //        float.TryParse($"{dAge.Year - 1},{dAge.Month - 1}", out float fAge);
        //        this.Age = fAge;
        //        return birthday;
        //    }
        //    set {
        //        birthday = value;
        //        DateTime dAge = DateTime.MinValue + (TimeSpan)(DateTime.Now - birthday);
        //        float.TryParse($"{dAge.Year - 1},{dAge.Month - 1}", out float fAge);
        //        this.Age = fAge;
        //    }
        //}

        private float age;

        [Display(Name = "Возраст")]
        [NotMapped]
        public float Age {
            get {
                DateTime dAge = DateTime.MinValue + (TimeSpan)(DateTime.Now - Birthday);
                float.TryParse($"{dAge.Year - 1},{dAge.Month - 1}", out float fAge);
                return this.Age = fAge;
            }

            set { age = value; }
        }
        [Display(Name = "Пол")]
        public byte Gender { get; set; } = 1;
        [Display(Name = "Комментарий")]
        public string Remark { get; set; }
        [Display(Name = "Поголовье")]
        public bool IsRetired { get; set; } = false;

        public Animal( ) { }
    }
}
