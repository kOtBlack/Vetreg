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
        //public SelectList RegionName { get; set; }

        public SelectList RegionsDropDownList(ApplicationDbContext _context,
            object selectedRegion = null) {

            var regionsQuery = _context.Regions.OrderBy(r => r.Name).Select(r => r);

            //RegionName = new SelectList(departmentsQuery.AsNoTracking(),
            //            "Id", "Name", selectedRegion);

            return new SelectList(regionsQuery.AsNoTracking(),
                "Id", "Name", selectedRegion);
        }
    }
}
