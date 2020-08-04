using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Vetreg.Data;
using Vetreg.Models;
using Vetreg.ViewModels;

namespace Vetreg.Controllers
{
    public class WorkController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Works
        public async Task<IActionResult> Index(string sortOrder)
        {
            var applicationDbContext = await _context.Works.Include(c => c.Cause).Include(d => d.Disease).ToListAsync()/*Include(w => w.City).Include(w => w.Owner).Include(w => w.Region)*/;
            if (sortOrder == null)
            {
                applicationDbContext.OrderBy(w => w.Cause.Id);
                sortOrder = "desc";
            }
            else
            {
                applicationDbContext.OrderByDescending(w => w.Cause.Id);
                sortOrder = "";
            }

            ViewBag.Order = sortOrder;
            return View( applicationDbContext);
        }


        // GET: Works/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var work = await _context.Works
                //.Include(w => w.City)
                //.Include(w => w.Owner)
                //.Include(w => w.Region)
                .FirstOrDefaultAsync(m => m.GUID == id);
            if (work == null)
            {
                return NotFound();
            }

            return View(work);
        }

        // GET: Works/Create
        public IActionResult Create()
        {
            //ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id");
            //ViewBag.Cause = new SelectList(_context.Causes, "Id", "Name");
            //ViewBag.Owner = new SelectList(_context.Owners.Include(o => o.Animals), "Id", "Name");
            //ViewData["RegionId"] = new SelectList(_context.Regions, "Id", "Id");

            var workOwner = new WorkOwnerViewModel(_context.Owners.Include(o => o.Animals).ToList())
            {
                //Owners = /*_context.Owners.Include(o => o.Animals).ToList(),*/ new SelectList(_context.Owners.Include(a => a.Animals), "Id", "Name"),
                Causes = /*_context.Causes.ToList()*/new SelectList(_context.Causes, "Id", "Name"),
                Diseases = /*_context.Causes.ToList()*/new SelectList(_context.Diseases, "Id", "Name")
            };
            return View(workOwner);

        }

        // POST: Works/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("GUID,Date,RegionId,CityId,OwnerId,CauseId")]*/ Work work/*WorkOwnerViewModel workO*/)
        {
            if (ModelState.IsValid)
            {
                //Work work = new Work();
                work.GUID = Guid.NewGuid();

                foreach (var animal in work.AnimalsId) {
                    work.WorksWithAnimal.Add(new WorkWithAnimal() { 
                        WorkId = work.GUID,
                        AnimalId = Guid.Parse(animal) // Attention! TryParse
                    });
                }
                //Owner owner = _context.Owners.FirstOrDefault(o => o.Id == work.OwnerId);
                //if (owner != null)
                //    foreach (var animal in owner.Animals) {
                //        work.WorksWithAnimal.Add(new WorkWithAnimal { 
                //            WorkId = work.GUID,
                //            AnimalId = animal.GUID
                //        });
                //    }

                _context.Add(work);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id", work.CityId);
            //ViewData["OwnerId"] = new SelectList(_context.Owners, "Id", "Id", work.OwnerId);

            //ViewData["RegionId"] = new SelectList(_context.Regions, "Id", "Id", work.RegionId);
            return View(work);
        }

        // GET: Works/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var work = await _context.Works.FindAsync(id);
            if (work == null)
            {
                return NotFound();
            }
            //ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id", work.CityId);
            ViewData["OwnerId"] = new SelectList(_context.Owners, "Id", "Id", work.OwnerId);
            //ViewData["RegionId"] = new SelectList(_context.Regions, "Id", "Id", work.RegionId);
            return View(work);
        }

        // POST: Works/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("GUID,Date,RegionId,CityId,OwnerId,CauseId")] Work work)
        {
            if (id != work.GUID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(work);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkExists(work.GUID))
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
            //ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id", work.CityId);
            ViewData["OwnerId"] = new SelectList(_context.Owners, "Id", "Id", work.OwnerId);
            //ViewData["RegionId"] = new SelectList(_context.Regions, "Id", "Id", work.RegionId);
            return View(work);
        }

        // GET: Works/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var work = await _context.Works
                //.Include(w => w.City)
                //.Include(w => w.Owner)
                //.Include(w => w.Region)
                .FirstOrDefaultAsync(m => m.GUID == id);
            if (work == null)
            {
                return NotFound();
            }

            return View(work);
        }

        // POST: Works/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var work = await _context.Works.FindAsync(id);
            _context.Works.Remove(work);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkExists(Guid id)
        {
            return _context.Works.Any(e => e.GUID == id);
        }
    }
}
