using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vetreg.Data;

namespace Vetreg.ViewModels {
    public class RegionsNameListModel {
        public SelectList RegionName { get; set; }

        public void RegionsDropDownList(ApplicationDbContext _context,
            object selectedRegion = null) {

            var departmentsQuery = _context.Region.OrderBy(r => r.Name).Select(r => r);

            RegionName = new SelectList(departmentsQuery.AsNoTracking(),
                        "Id", "Name", selectedRegion);
        }
    }
}
