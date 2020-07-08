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
    public class CauseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CauseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cause
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cause.ToListAsync());
        }

        // GET: Cause/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cause = await _context.Cause
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cause == null)
            {
                return NotFound();
            }

            return View(cause);
        }

        // GET: Cause/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cause/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Cause cause)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cause);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cause);
        }

        // GET: Cause/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cause = await _context.Cause.FindAsync(id);
            if (cause == null)
            {
                return NotFound();
            }
            return View(cause);
        }

        // POST: Cause/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Cause cause)
        {
            if (id != cause.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cause);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CauseExists(cause.Id))
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
            return View(cause);
        }

        // GET: Cause/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cause = await _context.Cause
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cause == null)
            {
                return NotFound();
            }

            return View(cause);
        }

        // POST: Cause/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cause = await _context.Cause.FindAsync(id);
            _context.Cause.Remove(cause);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CauseExists(int id)
        {
            return _context.Cause.Any(e => e.Id == id);
        }
    }
}
