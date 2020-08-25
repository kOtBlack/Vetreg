using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Vetreg.Models {
    public class Work {
        [Key]
        public Guid GUID { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата работ")]
        public DateTime Date { get; set; }
        [Display(Name = "Мероприятие")]
        public int CauseId { get; set; }
        public Cause Cause { get; set; }
        [Display(Name = "Заболевание")]
        public int DiseaseId { get; set; }
        public Disease Disease { get; set; }
        //public int OwnerId { get; set; }
        //public ICollection<Owner> Owners { get; set; } = new List<Owner>();
        //public ICollection<Animal> Animals { get; set; } = new List<Animal>();



        //[NotMapped]
        //public IEnumerable<string> OwnersId { get; set; } = new List<string>();
        //[NotMapped]
        //public IEnumerable<string> AnimalsId { get; set; } = new List<string>();

        [NotMapped]
        public IEnumerable<CheckAnimal> Animals { get; set; } = new List<CheckAnimal>();
        [Display(Name = "Пологовье")]
        public List<WorkWithAnimal> WorksWithAnimal { get; set; } = new List<WorkWithAnimal>();

    }
}
