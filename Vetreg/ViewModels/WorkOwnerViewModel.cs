using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vetreg.Data;
using Vetreg.Models;

namespace Vetreg.ViewModels
{
    public class WorkOwnerViewModel {
        // https://docs.microsoft.com/ru-ru/aspnet/core/mvc/views/working-with-forms?view=aspnetcore-3.1

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public IEnumerable<SelectListItem> Causes { get; set; }
        public IEnumerable<SelectListItem> Diseases { get; set; }
        public IEnumerable<SelectListItem> Owners { get; set; }
        public IEnumerable<SelectListItem> Animals { get; set; }


        public IEnumerable<string> AnimalsId { get; set; } = new List<string>();
        public IEnumerable<string> OwnersId { get; set; } = new List<string>();
        public int CauseId { get; set; }
        public int DiseaseId { get; set; }

        public WorkOwnerViewModel() { }

        public WorkOwnerViewModel(IEnumerable<Owner> owners)
        {

            var Individual = new SelectListGroup { Name = "Individual" };
            var Company = new SelectListGroup { Name = "Company" };

            Owners = owners
                .Where(o => o.Type == TypeOwner.Individual)
                .Select(indO => new SelectListItem
                {
                    Value = indO.Id.ToString(),
                    Text = indO.Name,
                    Group = Individual
                }).Union(owners
                .Where(o => o.Type == TypeOwner.Company)
                .Select(comO => new SelectListItem
                {
                    Value = comO.Id.ToString(),
                    Text = comO.Name,
                    Group = Company
                })).ToList();

            List<Animal> animals = new List<Animal>();

            foreach (var owner in owners.ToList())
            {
                animals.AddRange(owner.Animals);
            }

            //animals.AddRange(owners.ToList().ForEach(o => o.Animals.Select(a => a).ToList()));

            Animals = animals.Select(a => new SelectListItem
            {
                Value = a.GUID.ToString(),
                Text = $"{a.ChipNumber} - " +
                    $"{(DateTime.MinValue + (TimeSpan)(DateTime.Now - a.Birthday)).Year - 1}" +
                    $",{(DateTime.MinValue + (TimeSpan)(DateTime.Now - a.Birthday)).Month - 1}"
            }).ToList();
        }

        public WorkOwnerViewModel(IEnumerable<Animal> animals)
        {
            var Individual = new SelectListGroup { Name = "Individual" };
            var Company = new SelectListGroup { Name = "Company" };

            Animals = animals
                .Where(a => a.Owner.Type == TypeOwner.Individual)
                .Select(aIn => new SelectListItem {
                    Value = aIn.GUID.ToString(),
                    Text = $"{aIn.Owner.Name} - {aIn.ChipNumber} - " +
                            $"{(DateTime.MinValue + (TimeSpan)(DateTime.Now - aIn.Birthday)).Year - 1}" +
                            $",{(DateTime.MinValue + (TimeSpan)(DateTime.Now - aIn.Birthday)).Month - 1}",
                    Group = Individual
                })
                .Union(animals
                .Where(a => a.Owner.Type == TypeOwner.Company)
                .Select(aCom => new SelectListItem
                {
                    Value = aCom.GUID.ToString(),
                    Text = $"{aCom.Owner.Name} - {aCom.ChipNumber} - " +
                            $"{(DateTime.MinValue + (TimeSpan)(DateTime.Now - aCom.Birthday)).Year - 1}" +
                            $",{(DateTime.MinValue + (TimeSpan)(DateTime.Now - aCom.Birthday)).Month - 1}",
                    Group = Company
                })).ToList();
        }
    }
}
