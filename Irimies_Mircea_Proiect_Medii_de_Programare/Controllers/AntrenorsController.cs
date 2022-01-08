using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Irimies_Mircea_Proiect_Medii_de_Programare.Data;
using Irimies_Mircea_Proiect_Medii_de_Programare.Models;

namespace Irimies_Mircea_Proiect_Medii_de_Programare.Controllers
{
    public class AntrenorsController : Controller
    {
        private readonly TeamContext _context;

        public AntrenorsController(TeamContext context)
        {
            _context = context;
        }

        // GET: Antrenors
        public async Task<IActionResult> Index()
        {
            var teamContext = _context.Antrenors.Include(a => a.echipa);
            return View(await teamContext.ToListAsync());
        }

        // GET: Antrenors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var antrenor = await _context.Antrenors
                .Include(a => a.echipa)
                .FirstOrDefaultAsync(m => m.AntrenorID == id);
            if (antrenor == null)
            {
                return NotFound();
            }

            return View(antrenor);
        }

        // GET: Antrenors/Create
        public IActionResult Create()
        {
            ViewData["EchipaID"] = new SelectList(_context.Echipas, "EchipaID", "EchipaID");
            return View();
        }

        // POST: Antrenors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AntrenorID,EchipaID,nume,prenume,data_nasterii,statut")] Antrenor antrenor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(antrenor);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex*/)
            {

                ModelState.AddModelError("", "Unable to save changes. " +
                "Try again, and if the problem persists ");
            }
            ViewData["EchipaID"] = new SelectList(_context.Echipas, "EchipaID", "EchipaID", antrenor.EchipaID);
            return View(antrenor);
        }

        // GET: Antrenors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var antrenor = await _context.Antrenors.FindAsync(id);
            if (antrenor == null)
            {
                return NotFound();
            }
            ViewData["EchipaID"] = new SelectList(_context.Echipas, "EchipaID", "EchipaID", antrenor.EchipaID);
            return View(antrenor);
        }

        // POST: Antrenors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AntrenorID,EchipaID,nume,prenume,data_nasterii,statut")] Antrenor antrenor)
        {
            if (id != antrenor.AntrenorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(antrenor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AntrenorExists(antrenor.AntrenorID))
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
            ViewData["EchipaID"] = new SelectList(_context.Echipas, "EchipaID", "EchipaID", antrenor.EchipaID);
            return View(antrenor);
        }

        // GET: Antrenors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var antrenor = await _context.Antrenors
                .Include(a => a.echipa)
                .FirstOrDefaultAsync(m => m.AntrenorID == id);
            if (antrenor == null)
            {
                return NotFound();
            }

            return View(antrenor);
        }

        // POST: Antrenors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var antrenor = await _context.Antrenors.FindAsync(id);
            _context.Antrenors.Remove(antrenor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AntrenorExists(int id)
        {
            return _context.Antrenors.Any(e => e.AntrenorID == id);
        }
    }
}
