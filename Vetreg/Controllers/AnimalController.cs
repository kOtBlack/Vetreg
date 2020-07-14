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
    public class AnimalController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SelectList _cities;
        private readonly SelectList _kinds;
        private readonly SelectList _breeds;
        private readonly SelectList _suits;
        private readonly SelectList _owners;

        public AnimalController(ApplicationDbContext context)
        {
            _context = context;
            _cities = new SelectList(_context.Cities.AsNoTracking(),
                "Id", "Name");
            _kinds = new SelectList(_context.Kinds.AsNoTracking(),
                "Id", "Name");
            _breeds = new SelectList(_context.Breeds.AsNoTracking(),
                "Id", "Name");
            _suits = new SelectList(_context.Suits.AsNoTracking(),
                "Id", "Name");
            _owners = new SelectList(_context.Owners.AsNoTracking(),
                "Id", "Name");
        }

        // GET: Animals
        public async Task<IActionResult> Index()
        {

            return View(await _context.Animals.Include(r => r.Region)
                .Include(c => c.City)
                .Include(k => k.Kind)
                .Include(b => b.Breed)
                .Include(s => s.Suit)
                .Include(o => o.Owner)
                .ToListAsync());
        }

        // GET: Animals/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animals
                .FirstOrDefaultAsync(m => m.GUID == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // GET: Animals/Create
        public IActionResult Create()
        {
            ViewBag.Cities = _cities;
            ViewBag.Kinds = _kinds;
            ViewBag.Breeds = _breeds;
            ViewBag.Suits = _suits;
            ViewBag.Owners = _owners;


            return View();
        }

        // POST: Animals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("GUID,AddDate,RegionId,CityId,OwnerId,KindId,BreedId,SuitId,Sticker,ChipNumber,Birthday,Sex,Remark,IsRetired")]*/ Animal animal)
        {
            if (ModelState.IsValid)
            {
                animal.GUID = Guid.NewGuid();

                animal.RegionId = _context.Cities.FirstOrDefault(c => c.Id == animal.CityId).RegionId;

                if (animal.Sticker == Sticker.Tag)
                _context.Add(new Tag()
                {
                    Name = animal.ChipNumber,
                    AnimalId = animal.GUID.ToString()

                });

                _context.Add(animal);


                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(animal);
        }

        // GET: Animals/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animals.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }
            return View(animal);
        }

        // POST: Animals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, /*[Bind("GUID,AddDate,RegionId,CityId,OwnerId,KindId,BreedId,SuitId,Sticker,ChipNumber,Birthday,Sex,Remark,IsRetired")]*/ Animal animal)
        {
            if (id != animal.GUID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalExists(animal.GUID))
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
            return View(animal);
        }

        // GET: Animals/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animals
                .FirstOrDefaultAsync(m => m.GUID == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // POST: Animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var animal = await _context.Animals.FindAsync(id);
            _context.Animals.Remove(animal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimalExists(Guid id)
        {
            return _context.Animals.Any(e => e.GUID == id);
        }

        /// <summary>  
        /// For calculating only age  
        /// </summary>  
        /// <param name="dateOfBirth">Date of birth</param>  
        /// <returns> age </returns>  
        private static int CalculateAge(DateTime dateOfBirth)
        {
            int age = 0;
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }

    }
}
