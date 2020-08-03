using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vetreg.Data;
using Vetreg.Models;

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
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Works.Include(c => c.Cause)/*Include(w => w.City).Include(w => w.Owner).Include(w => w.Region)*/;
            return View(await applicationDbContext.ToListAsync());
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
            Work work = new Work() {
                Date = DateTime.Now,
                Owners = _context.Owners.Select(o => o).ToList()

    };

            //ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id");
            ViewBag.Cause = new SelectList(_context.Causes, "Id", "Name");
            ViewBag.Owner = new SelectList(_context.Owners.Include(o => o.Animals), "Id", "Name");
            //ViewData["RegionId"] = new SelectList(_context.Regions, "Id", "Id");
            return View();
        }

        // POST: Works/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("GUID,Date,RegionId,CityId,OwnerId,CauseId")]*/ Work work)
        {
                //.Include(w => w.City)
                //.Include(w => w.Owner).Include(a => a.Owner.Animals);
            //.Include(w => w.Region)

            if (ModelState.IsValid)
            {
                work.GUID = Guid.NewGuid();
                _context.Add(work);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id", work.CityId);
            ViewData["OwnerId"] = new SelectList(_context.Owners, "Id", "Id", work.OwnerId);

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
