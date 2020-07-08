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

        // GET: Suit
        public async Task<IActionResult> Index()
        {
            return View(await _context.Suit.ToListAsync());
        }

        // GET: Suit/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suit = await _context.Suit
                .FirstOrDefaultAsync(m => m.Id == id);
            if (suit == null)
            {
                return NotFound();
            }

            return View(suit);
        }

        // GET: Suit/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Suit/Create
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

        // GET: Suit/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suit = await _context.Suit.FindAsync(id);
            if (suit == null)
            {
                return NotFound();
            }
            return View(suit);
        }

        // POST: Suit/Edit/5
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

        // GET: Suit/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suit = await _context.Suit
                .FirstOrDefaultAsync(m => m.Id == id);
            if (suit == null)
            {
                return NotFound();
            }

            return View(suit);
        }

        // POST: Suit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var suit = await _context.Suit.FindAsync(id);
            _context.Suit.Remove(suit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuitExists(int id)
        {
            return _context.Suit.Any(e => e.Id == id);
        }
    }
}
