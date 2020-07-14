using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vetreg.Data;
using Vetreg.Models;
using Vetreg.ViewModels;

namespace Vetreg.Controllers {
    public class CityController : Controller {

        private readonly ApplicationDbContext _context;
        private RegionsNameListModel _regions;

        public CityController(ApplicationDbContext context)
        {
            _context = context;
            _regions = new RegionsNameListModel();
        }

        // GET: Citiy
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cities.Include(c => c.Region).ToListAsync());
        }

        // GET: Citiy/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var city = await _context.Cities
                .Include(c => c.Region)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // GET: Citiy/Create
        public IActionResult Create()
        {
            ViewBag.RegionName = _regions.RegionsDropDownList(_context);
            return View();
        }

        // POST: Citiy/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("Id,Name,Region")] */City city)
        {
            //var emptyCity = new City();

            //if (await TryUpdateModelAsync<City>(
            //     city,
            //     "city",   // Prefix for form value.
            //     c => c.Id, c => c.Name, c => c.Region == )) {
            //    _context.City.Add(city);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction("Index");
            //}

            ////var m = new RegionsNameListModel();
            //ViewBag.RegionName = _regions.RegionsDropDownList(_context, emptyCity.Region.Id);
            ////_regions = m.RegionName.Select(r => r).ToList();
            ////_regions = _context.Region.ToList();
            ////if (ModelState.IsValid)
            ////{
            ////    _context.Add(city);
            ////    await _context.SaveChangesAsync();
            ////    return RedirectToAction(nameof(Index));
            ////}
            //return View(city);


            if (ModelState.IsValid)
            {
                city.Region = _context.Regions.FirstOrDefault(c => c.Id == city.RegionId);
                _context.Cities.Add(city); 
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.RegionName = _regions.RegionsDropDownList(_context);
            return View(city);


        }

        // GET: Citiy/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.Cities.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            ViewBag.RegionName = _regions.RegionsDropDownList(_context, city.RegionId);
            return View(city);
        }

        // POST: Citiy/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, City city)
        {
            if (id != city.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(city);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CityExists(city.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(city);
        }

        // GET: Citiy/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.Cities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // POST: Citiy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var city = await _context.Cities.FindAsync(id);
            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CityExists(int id)
        {
            return _context.Cities.Any(e => e.Id == id);
        }
    }
}
