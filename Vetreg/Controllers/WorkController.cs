using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Vetreg.Data;
using Vetreg.Models;
using Vetreg.ViewModels;

namespace Vetreg.Controllers {
    public class WorkController : Controller {
        private readonly ApplicationDbContext _context;

        public WorkController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Works
        public async Task<IActionResult> Index(string sortOrder)
        {
            List<Work> applicationDbContext = null;
            if (sortOrder == null)
            {
                applicationDbContext = await _context.Works
                    .Include(c => c.Cause)
                    .Include(d => d.Disease)

                    .OrderBy(w => w.Cause.Id).ToListAsync();
                sortOrder = "desc";
            }
            else
            {
                applicationDbContext = await _context.Works
                        .Include(c => c.Cause)
                        .Include(d => d.Disease)

                        .OrderByDescending(w => w.Cause.Id).ToListAsync();
                sortOrder = "";
            }

            ViewBag.Order = sortOrder;
            return View(applicationDbContext);
        }


        // GET: Works/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var work = await _context.Works
                .Include(w => w.WorksWithAnimal)
                //.Include(w => w.Owners)
                .Include(w => w.Cause)
                .Include(w => w.Disease)
                //.Include(w => w.City)
                //.Include(w => w.Owner)
                //.Include(w => w.Region)
                .FirstOrDefaultAsync(m => m.GUID == id);
            if (work == null)
            {
                return NotFound();
            }

            //work.Animals.Add = _context.Animals.ToList().ForEach(work.AnimalsId.Where(w => w. == ));

            return View(work);
        }

        // GET: Works/Create
        public IActionResult Create(DateTime date, int causeId, int diseaseId,
            string ownerType/* = "Individual"*/)
        {
            //var workOwner = new WorkOwnerViewModel();

            ////ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id");
            ////ViewBag.Cause = new SelectList(_context.Causes, "Id", "Name");
            ////ViewBag.Owner = new SelectList(_context.Owners.Include(o => o.Animals), "Id", "Name");
            ////ViewData["RegionId"] = new SelectList(_context.Regions, "Id", "Id");

            ////var workOwner = new WorkOwnerViewModel(_context.Owners.Include(o => o.Animals).ToList())
            ////{
            ////    //Owners = /*_context.Owners.Include(o => o.Animals).ToList(),*/ new SelectList(_context.Owners.Include(a => a.Animals), "Id", "Name"),
            ////    Causes = /*_context.Causes.ToList()*/new SelectList(_context.Causes, "Id", "Name"),
            ////    Diseases = /*_context.Causes.ToList()*/new SelectList(_context.Diseases, "Id", "Name")
            ////};
            //var workOwner = new WorkOwnerViewModel(_context.Animals.Include(a => a.Owner).ToList())
            //{
            //    //Owners = /*_context.Owners.Include(o => o.Animals).ToList(),*/ new SelectList(_context.Owners.Include(a => a.Animals), "Id", "Name"),
            //    Causes = /*_context.Causes.ToList()*/new SelectList(_context.Causes, "Id", "Name"),
            //    Diseases = /*_context.Causes.ToList()*/new SelectList(_context.Diseases, "Id", "Name")
            //};


            WorkOwnerViewModel workOwner = new WorkOwnerViewModel();
            if (workOwner.Date == DateTime.MinValue) workOwner.Date = DateTime.Now;
            else workOwner.Date = date;

            if (workOwner.CauseId == 0) workOwner.Causes = new SelectList(_context.Causes, "Id", "Name");
            else workOwner.CauseId = causeId;


            if (workOwner.DiseaseId == 0) workOwner.Diseases = new SelectList(_context.Diseases, "Id", "Name");
            else workOwner.DiseaseId = diseaseId;


            if (ownerType != null)
            {
                //workOwner = new WorkOwnerViewModel(
                //    AnimalsList = _context.Animals.For Where(a => checkAnimals.Contains(a.GUID) && )
                //    .Animals. Include(a => a.Owner).ToList())
                //    .Include(c => c.Cause)
                //    .Include(d => d.Disease)
                //    //.Include(o => o.Owners.Where(o => o.Type.ToString() == ownerType))
                //    .Include(o => o.Owners)
                //    .Include(a => a.Animals)
                //    .OrderBy(w => w.Cause.Id).ToListAsync());
                //sortOrder = "Company";
                //workOwner.AnimalsList = _context.Animals.Where(a => checkAnimals.ForEach(checkAnimal =>
                //        a.GUID.Equals(checkAnimal.AnimalId));

                //applicationDbContext.Where(o => o.OwnersId == checkOwners.Where(w => w.IsChected == true));
                //workOwner.Date = date;
                //workOwner.CauseId = causeId;
                //workOwner.DiseaseId = diseaseId;


                List<Animal> animals = _context.Animals
                    .Include(o => o.Owner)
                    //.Where(a => a.Owner.Type.ToString() == ownerType)
                    //.OrderBy(a => a.Owner.Id)
                    .ToList();

                workOwner.Animals = animals.Select(d => new SelectListItem{Value = d.GUID.ToString(), Text = d.ChipNumber.ToString()}).ToList();
                //  = new List<CheckAnimal>(animals
                //     .Where(a => a.Owner.Type.ToString() == ownerType)
                //     .Select(a => new CheckAnimal()
                //     {
                //         AnimalId = a.GUID,
                //         ChipNumber = a.ChipNumber,
                //         Age = a.Age,
                //         OwnerId = a.Owner.Id,
                //         OwnerName = a.Owner.Name,
                //         IsChected = false
                //     }).ToList().OrderBy(a => a.OwnerName));

                var t = workOwner.Animals;
                //workOwner.AnimalsList = checkAnimals.Where(checkAnimal => checkAnimal.IsChected == true);
            }
            
            //else
            //{

            //    workOwner.Causes = new SelectList(_context.Causes, "Id", "Name");
            //    workOwner.Diseases = new SelectList(_context.Diseases, "Id", "Name");

            //    //workOwner.OwnersList = checkOwners.Where(checkOwner => checkOwner.IsChected == true);
            //    //workOwner.AnimalsList = checkAnimals.Where(checkAnimal => checkAnimal.IsChected == true);
            //    work.OwnerType = "Individual";
            //}

            //    applicationDbContext = await _context.Works
            //.Include(c => c.Cause)
            //.Include(d => d.Disease)
            ////.Include(o => o.Owners.Where(o => o.Type.ToString() == ownerType))
            //.Include(a => a.Owners)
            //.OrderByDescending(w => w.Cause.Id).ToListAsync();
            //    sortOrder = "Individual";

            //    applicationDbContext.Where(o => o.OwnersId == checkOwners.Where(w => w.IsChected == true));
            //    applicationDbContext.Where(a => a.AnimalsId == checkAnimals.Where(n => n.IsChected == true));

            return View(workOwner);

        }

        // POST: Works/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("Date,CauseId,DiseaseId,Animals")]*/ WorkOwnerViewModel workOwner/*WorkOwnerViewModel workO*/)
        {
            if (ModelState.IsValid)
            {
                Work work = new Work();
                work.GUID = Guid.NewGuid();
                work.WorksWithAnimal = new List<WorkWithAnimal>();

                foreach (var animal in workOwner.SelectedAnimals)
                {
                    Guid.TryParse(animal, out Guid animalId);
                    var workAnimal = new WorkWithAnimal()
                    {
                        WorkId = work.GUID,
                        AnimalId = animalId
                    };
                    work.WorksWithAnimal.Add(workAnimal);
                    //work.Owners.Add(_context.Owners.FirstOrDefault(o => o.Id
                    //    == _context.Animals.FirstOrDefault(a => a.GUID.ToString() == animal).OwnerId));
                }
                //Owner owner = _context.Owners.FirstOrDefault(o => o.Id == work.OwnerId);
                //if (owner != null)
                //    foreach (var animal in owner.Animals) {
                //        work.WorksWithAnimal.Add(new WorkWithAnimal { 
                //            WorkId = work.GUID,
                //            AnimalId = animal.GUID
                //        });
                //    }

                work.Cause = _context.Causes.FirstOrDefault(c => c.Id == workOwner.CauseId);
                work.Disease = _context.Diseases.FirstOrDefault(c => c.Id == workOwner.DiseaseId);

                //_context.Entry(work.Cause).State = EntityState.Unchanged;
               //_context.Entry(work.Disease).State = EntityState.Unchanged;
                _context.Add(work);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id", work.CityId);
            //ViewData["OwnerId"] = new SelectList(_context.Owners, "Id", "Id", work.OwnerId);

            //ViewData["RegionId"] = new SelectList(_context.Regions, "Id", "Id", work.RegionId);
            return View(workOwner);
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
            //ViewData["OwnerId"] = new SelectList(_context.Owners, "Id", "Id", work.OwnerId);
            //ViewData["RegionId"] = new SelectList(_context.Regions, "Id", "Id", work.RegionId);
            return View(work);
        }

        // POST: Works/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, /* [Bind("GUID,Date,RegionId,CityId,OwnerId,CauseId")] */Work work)
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
            //ViewData["OwnerId"] = new SelectList(_context.Owners, "Id", "Id", work.OwnerId);
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
