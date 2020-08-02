using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vetreg.Models;

namespace Vetreg.ViewModels
{
    public class WorkOwnerViewModel
    {
        public DateTime Date { get; set; }
        public IEnumerable<SelectListItem> Causes { get; set; }
        public IEnumerable<SelectListItem> Owners { get; set; }
        public int OwnerId { get; set; }
        public int CauseId { get; set; }
    }
}
