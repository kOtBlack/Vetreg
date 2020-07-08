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
    public class KindController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KindController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Kind
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kind.ToListAsync());
        }

        // GET: Kind/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kind = await _context.Kind
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kind == null)
            {
                return NotFound();
            }

            return View(kind);
        }

        // GET: Kind/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kind/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Kind kind)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kind);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kind);
        }

        // GET: Kind/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kind = await _context.Kind.FindAsync(id);
            if (kind == null)
            {
                return NotFound();
            }
            return View(kind);
        }

        // POST: Kind/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Kind kind)
        {
            if (id != kind.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kind);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KindExists(kind.Id))
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
            return View(kind);
        }

        // GET: Kind/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kind = await _context.Kind
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kind == null)
            {
                return NotFound();
            }

            return View(kind);
        }

        // POST: Kind/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kind = await _context.Kind.FindAsync(id);
            _context.Kind.Remove(kind);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KindExists(int id)
        {
            return _context.Kind.Any(e => e.Id == id);
        }
    }
}
