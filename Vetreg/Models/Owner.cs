using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vetreg.Models {
    public class Owner {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Наименование")]
        public string Name { get; set; }
        [Display(Name = "ФИО")]
        public string FIO { get; set; }
        [Display(Name = "Телефон")]
        public string Phone { get; set; }
        [Display(Name = "Тип")]
        public TypeOwner Type { get; set; }
        [Display(Name = "Регион")]
        public int RegionId { get; set; }
        public Region Region { get; set; }
        [Display(Name = "Город")]
        public int CityId { get; set; }
        public City City { get; set; }
        [Display(Name = "Адрес")]
        public string Address { get; set; }
        [Display(Name = "Поголовье")]
        public ICollection<Animal> Animals { get; set; } = new List<Animal>();

        public Owner() {
        } 
    }
}
