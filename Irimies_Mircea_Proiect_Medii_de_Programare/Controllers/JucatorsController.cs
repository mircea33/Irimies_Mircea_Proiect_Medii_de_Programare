using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Irimies_Mircea_Proiect_Medii_de_Programare.Data;
using Irimies_Mircea_Proiect_Medii_de_Programare.Models;

namespace Irimies_Mircea_Proiect_Medii_de_Programare
{
    public class JucatorsController : Controller
    {
        private readonly TeamContext _context;

        public JucatorsController(TeamContext context)
        {
            _context = context;
        }

        // GET: Jucators
        public async Task<IActionResult> Index(
  string sortOrder,
  string currentFilter,
  string searchString,
  int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["TitleSortParm"] = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewData["GreutateSortParm"] = sortOrder == "Greutate" ? "greutate_desc" : "Greutate";
            
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;
            var jucators = from j in _context.Jucators
                        select j;
            if (!String.IsNullOrEmpty(searchString))
            {
                jucators = jucators.Where(s => s.nume.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "title_desc":
                    jucators = jucators.OrderByDescending(j => j.nume);
                    break;
                case "Inaltime":
                    jucators = jucators.OrderBy(j => j.inaltime);
                    break;
                case "Greutate":
                    jucators = jucators.OrderBy(j => j.greutate);
                    break;
            }
            int pageSize = 2;
            return View(await PaginatedList<Jucator>.CreateAsync(jucators.AsNoTracking(), pageNumber ??
           1, pageSize));
        }
        // GET: Jucators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jucator = await _context.Jucators
                .Include(j => j.echipa)
                .FirstOrDefaultAsync(m => m.JucatorID == id);
            if (jucator == null)
            {
                return NotFound();
            }

            return View(jucator);
        }

        // GET: Jucators/Create
        public IActionResult Create()
        {
            ViewData["EchipaID"] = new SelectList(_context.Echipas, "EchipaID", "EchipaID");
            return View();
        }

        // POST: Jucators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JucatorID,EchipaID,nume,prenume,inaltime,greutate,data_nasterii,pozitie")] Jucator jucator)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(jucator);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex*/)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                "Try again, and if the problem persists ");
            }
            ViewData["EchipaID"] = new SelectList(_context.Echipas, "EchipaID", "EchipaID", jucator.EchipaID);
            return View(jucator);
        }

        // GET: Jucators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jucator = await _context.Jucators.FindAsync(id);
            if (jucator == null)
            {
                return NotFound();
            }
            ViewData["EchipaID"] = new SelectList(_context.Echipas, "EchipaID", "EchipaID", jucator.EchipaID);
            return View(jucator);
        }

        // POST: Jucators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JucatorID,EchipaID,nume,prenume,inaltime,greutate,data_nasterii,pozitie")] Jucator jucator)
        {
            if (id != jucator.JucatorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jucator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +"Try again, and if the problem persists");
                    if (!JucatorExists(jucator.JucatorID))
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
            ViewData["EchipaID"] = new SelectList(_context.Echipas, "EchipaID", "EchipaID", jucator.EchipaID);
            return View(jucator);
        }

        // GET: Jucators/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jucator = await _context.Jucators
                .Include(j => j.echipa)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.JucatorID == id);
            if (jucator == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                "Delete failed. Try again";
            }
            return View(jucator);
        }

        // POST: Jucators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jucator = await _context.Jucators.FindAsync(id);
            if (jucator == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.Jucators.Remove(jucator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {

                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }

        private bool JucatorExists(int id)
        {
            return _context.Jucators.Any(e => e.JucatorID == id);
        }
    }
}
