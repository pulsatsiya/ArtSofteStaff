using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArtSofteStaff.Models;
using ArtSofteStaff.Models.Data;

namespace ArtSofteStaff.Controllers
{
    public class WorkersController : Controller
    {
        private readonly WorkContext _context;

        public WorkersController(WorkContext context)
        {
            _context = context;
        }

        // GET: Workers
        public async Task<IActionResult> Index()
        {
            var workContext = _context.Workers.Include(w => w.Language).Include(w => w.Unit);
            return View(await workContext.ToListAsync());
        }

        // GET: Workers/Add
        public IActionResult Add()
        {
            ViewData["LanguageID"] = new SelectList(_context.Languages, "ID", "Name");
            ViewData["UnitID"] = new SelectList(_context.Units, "ID", "Name");
            return View();
        }

        // POST: Workers/Add
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("ID,FirstName,LastName,Age,Sex,UnitID,LanguageID")] Worker worker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(worker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LanguageID"] = new SelectList(_context.Languages, "ID", "Name", worker.LanguageID);
            ViewData["UnitID"] = new SelectList(_context.Units, "ID", "Name", worker.UnitID);
            return View(worker);
        }

        // GET: Workers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var worker = await _context.Workers.FindAsync(id);
            if (worker == null)
            {
                return NotFound();
            }
            ViewData["LanguageID"] = new SelectList(_context.Languages, "ID", "Name", worker.LanguageID);
            ViewData["UnitID"] = new SelectList(_context.Units, "ID", "Name", worker.UnitID);
            return View(worker);
        }

        // POST: Workers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,Age,Sex,UnitID,LanguageID")] Worker worker)
        {
            if (id != worker.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(worker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkerExists(worker.ID))
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
            ViewData["LanguageID"] = new SelectList(_context.Languages, "ID", "Name", worker.LanguageID);
            ViewData["UnitID"] = new SelectList(_context.Units, "ID", "Name", worker.UnitID);
            return View(worker);
        }

        // GET: Workers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var worker = await _context.Workers
                .Include(w => w.Language)
                .Include(w => w.Unit)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (worker == null)
            {
                return NotFound();
            }

            return View(worker);
        }

        // POST: Workers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var worker = await _context.Workers.FindAsync(id);
            _context.Workers.Remove(worker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkerExists(int id)
        {
            return _context.Workers.Any(e => e.ID == id);
        }
    }
}
