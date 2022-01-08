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
    public class EchipasController : Controller
    {
        private readonly TeamContext _context;

        public EchipasController(TeamContext context)
        {
            _context = context;
        }

        // GET: Echipas
        public async Task<IActionResult> Index()
        {
            var teamContext = _context.Echipas.Include(e => e.conferinta);
            return View(await teamContext.ToListAsync());
        }

        // GET: Echipas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var echipa = await _context.Echipas
                .Include(e => e.conferinta)
                .FirstOrDefaultAsync(m => m.EchipaID == id);
            if (echipa == null)
            {
                return NotFound();
            }

            return View(echipa);
        }

        // GET: Echipas/Create
        public IActionResult Create()
        {
            ViewData["ConferintaID"] = new SelectList(_context.Conferintas, "ConferintaID", "ConferintaID");
            return View();
        }

        // POST: Echipas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EchipaID,ConferintaID,nume_echipa")] Echipa echipa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(echipa);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex*/)
            {

                ModelState.AddModelError("", "Unable to save changes. " +
                "Try again, and if the problem persists ");
            }
            ViewData["ConferintaID"] = new SelectList(_context.Conferintas, "ConferintaID", "ConferintaID", echipa.ConferintaID);
            return View(echipa);
        }

        // GET: Echipas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var echipa = await _context.Echipas.FindAsync(id);
            if (echipa == null)
            {
                return NotFound();
            }
            ViewData["ConferintaID"] = new SelectList(_context.Conferintas, "ConferintaID", "ConferintaID", echipa.ConferintaID);
            return View(echipa);
        }

        // POST: Echipas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EchipaID,ConferintaID,nume_echipa")] Echipa echipa)
        {
            if (id != echipa.EchipaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(echipa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EchipaExists(echipa.EchipaID))
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
            ViewData["ConferintaID"] = new SelectList(_context.Conferintas, "ConferintaID", "ConferintaID", echipa.ConferintaID);
            return View(echipa);
        }

        // GET: Echipas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var echipa = await _context.Echipas
                .Include(e => e.conferinta)
                .FirstOrDefaultAsync(m => m.EchipaID == id);
            if (echipa == null)
            {
                return NotFound();
            }

            return View(echipa);
        }

        // POST: Echipas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var echipa = await _context.Echipas.FindAsync(id);
            _context.Echipas.Remove(echipa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EchipaExists(int id)
        {
            return _context.Echipas.Any(e => e.EchipaID == id);
        }
    }
}
