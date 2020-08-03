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
    public class SuitController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SuitController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Suits
        public async Task<IActionResult> Index()
        {
            return View(await _context.Suits.ToListAsync());
        }

        // GET: Suits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suit = await _context.Suits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (suit == null)
            {
                return NotFound();
            }

            return View(suit);
        }

        // GET: Suits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Suits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Suit suit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(suit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(suit);
        }

        // GET: Suits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suit = await _context.Suits.FindAsync(id);
            if (suit == null)
            {
                return NotFound();
            }
            return View(suit);
        }

        // POST: Suits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Suit suit)
        {
            if (id != suit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(suit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuitExists(suit.Id))
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
            return View(suit);
        }

        // GET: Suits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suit = await _context.Suits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (suit == null)
            {
                return NotFound();
            }

            return View(suit);
        }

        // POST: Suits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var suit = await _context.Suits.FindAsync(id);
            _context.Suits.Remove(suit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuitExists(int id)
        {
            return _context.Suits.Any(e => e.Id == id);
        }
    }
}
