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
        public async Task<IActionResult> Index(string sortOrder)
        {
            List<Animal> applicationDbContext = null;
            if (sortOrder == null)
            {
                applicationDbContext = await _context.Animals
                            .Include(c => c.City)
                            .Include(k => k.Kind)
                            .Include(b => b.Breed)
                            .Include(s => s.Suit)
                            .Include(o => o.Owner)
                            .OrderBy(o => o.Owner.Type)
                            .ToListAsync();
                sortOrder = "desc";
            }
            else
            {
                applicationDbContext = await _context.Animals
                            .Include(c => c.City)
                            .Include(k => k.Kind)
                            .Include(b => b.Breed)
                            .Include(s => s.Suit)
                            .Include(o => o.Owner)
                            .OrderByDescending(o => o.Owner.Type)
                            .ToListAsync();
                sortOrder = "";
            }

            ViewBag.Order = sortOrder;

            return View(applicationDbContext);
        }

        // GET: Animals/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animals
                .FirstOrDefaultAsync(a => a.GUID == id);
            if (animal == null)
            {
                return NotFound();
            }
            animal.Region = _context.Regions.FirstOrDefault(a => a.Id == animal.RegionId);
            animal.City = _context.Cities.FirstOrDefault(a => a.Id == animal.CityId);
            animal.Kind = _context.Kinds.FirstOrDefault(a => a.Id == animal.KindId);
            animal.Breed = _context.Breeds.FirstOrDefault(a => a.Id == animal.BreedId);
            animal.Suit = _context.Suits.FirstOrDefault(a => a.Id == animal.SuitId);
            animal.Owner = _context.Owners.FirstOrDefault(a => a.Id == animal.OwnerId);
            animal.Tags = _context.Tags.Where(a => a.AnimalId == animal.GUID).ToList();

            return View(animal);
        }

        // GET: Animals/Create
        public IActionResult Create()
        {
            //ViewBag.Cities = _cities;
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


                animal.CityId = _context.Owners.FirstOrDefault(o => o.Id == animal.OwnerId).CityId;
                animal.RegionId = _context.Cities.FirstOrDefault(c => c.Id == animal.CityId).RegionId;

                if (animal.Sticker == Sticker.Tag) {
                    _context.Tags.Add(new Tag()
                    {
                        Name = animal.ChipNumber,
                    });
                }

                if (animal.Birthday > DateTime.Now) animal.Birthday = DateTime.Now;

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

            ViewBag.Kinds = _kinds;
            ViewBag.Breeds = _breeds;
            ViewBag.Suits = _suits;
            ViewBag.Owners = _owners;

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
                    animal.CityId = _context.Owners.FirstOrDefault(o => o.Id == animal.OwnerId).CityId;
                    animal.RegionId = _context.Cities.FirstOrDefault(c => c.Id == animal.CityId).RegionId;


                    if (animal.Sticker == Sticker.Tag)
                        _context.Add(new Tag()
                        {
                            Name = animal.ChipNumber,
                        });

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
            animal.Kind = _context.Kinds.FirstOrDefault(k => k.Id == animal.KindId);
            animal.Breed = _context.Breeds.FirstOrDefault(b => b.Id == animal.BreedId);
            animal.Suit = _context.Suits.FirstOrDefault(s => s.Id == animal.SuitId);
            animal.Owner = _context.Owners.FirstOrDefault(o => o.Id == animal.OwnerId);

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
        private static float CalculateAge(DateTime dateOfBirth)
        {
            //DateTime birth = new DateTime(1974, 8, 29);
            //DateTime today = DateTime.Now;
            //TimeSpan span = today - birth;
            //DateTime age = DateTime.MinValue + span;

            //// Make adjustment due to MinValue equalling 1/1/1
            //int years = age.Year - 1;
            //int months = age.Month - 1;
            //int days = age.Day - 1;

            //// Print out not only how many years old they are but give months and days as well
            //Console.Write("{0} years, {1} months, {2} days", years, months, days);

            float age = 0;
            //age = DateTime.Now.Year - dateOfBirth.Year;
            //if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
            //    age = age - 1;

            return age;
        }






    }
}
