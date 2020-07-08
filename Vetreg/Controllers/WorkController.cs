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

        // GET: Work
        public async Task<IActionResult> Index()
        {
            return View(await _context.Work.ToListAsync());
        }

        // GET: Work/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var work = await _context.Work
                .FirstOrDefaultAsync(m => m.GUID == id);
            if (work == null)
            {
                return NotFound();
            }

            return View(work);
        }

        // GET: Work/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Work/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GUID,Date")] Work work)
        {
            if (ModelState.IsValid)
            {
                work.GUID = Guid.NewGuid();
                _context.Add(work);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(work);
        }

        // GET: Work/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var work = await _context.Work.FindAsync(id);
            if (work == null)
            {
                return NotFound();
            }
            return View(work);
        }

        // POST: Work/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("GUID,Date")] Work work)
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
            return View(work);
        }

        // GET: Work/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var work = await _context.Work
                .FirstOrDefaultAsync(m => m.GUID == id);
            if (work == null)
            {
                return NotFound();
            }

            return View(work);
        }

        // POST: Work/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var work = await _context.Work.FindAsync(id);
            _context.Work.Remove(work);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkExists(Guid id)
        {
            return _context.Work.Any(e => e.GUID == id);
        }
    }
}
