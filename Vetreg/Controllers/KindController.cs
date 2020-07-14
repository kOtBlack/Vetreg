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

        // GET: Kinds
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kinds.ToListAsync());
        }

        // GET: Kinds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kind = await _context.Kinds
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kind == null)
            {
                return NotFound();
            }

            return View(kind);
        }

        // GET: Kinds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kinds/Create
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

        // GET: Kinds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kind = await _context.Kinds.FindAsync(id);
            if (kind == null)
            {
                return NotFound();
            }
            return View(kind);
        }

        // POST: Kinds/Edit/5
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

        // GET: Kinds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kind = await _context.Kinds
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kind == null)
            {
                return NotFound();
            }

            return View(kind);
        }

        // POST: Kinds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kind = await _context.Kinds.FindAsync(id);
            _context.Kinds.Remove(kind);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KindExists(int id)
        {
            return _context.Kinds.Any(e => e.Id == id);
        }
    }
}
