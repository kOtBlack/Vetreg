using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vetreg.Data;

namespace Vetreg.ViewModels {
    public class CitiesNameListModel {

        public SelectList CitiesDropDownList(ApplicationDbContext _context, int? regionId = null,
            object selectedCity = null)
        {


            var cityQuery =
                  _context.Cities
                    .OrderBy(c => c.Name)
                    .Include(c => c.Region)
                    .Select(c => c);




            //var cityQuery = _context.Cities.Where(c => c.RegionId == regionId).Select(c => c);

            return new SelectList(cityQuery.AsNoTracking(),
                "Id", "Name", selectedCity);
        }
    }
}
