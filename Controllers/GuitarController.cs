using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TomGuitar1.Data;
using TomGuitar1.Models;

namespace TomGuitar1.Controllers
{
    public class GuitarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GuitarController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Guitar
        public async Task<IActionResult> Index()
        {
            return View(await _context.Guitar.ToListAsync());
        }
        public async Task<IActionResult> Image(int id)
        {
            var guitar = await _context.Guitar
               .FirstOrDefaultAsync(m => m.Id == id);
            return File(guitar.GuitarPicPath, "image/webp");
        }
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }

        public async Task<IActionResult> ShowSearchResults(String SearchPhrase)
        {
            return View();
        }

        // GET: Guitar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guitar = await _context.Guitar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guitar == null)
            {
                return NotFound();
            }

            return View(guitar);
        }

        // GET: Guitar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Guitar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GuitarType,GuitarName,GuitarCost,GuitarPicPath,InsuredValue")] Guitar guitar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guitar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(guitar);
        }

        // GET: Guitar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guitar = await _context.Guitar.FindAsync(id);
            if (guitar == null)
            {
                return NotFound();
            }
            return View(guitar);
        }

        // POST: Guitar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GuitarType,GuitarName,GuitarCost,GuitarPic,InsuredValue")] Guitar guitar)
        {
            if (id != guitar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guitar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuitarExists(guitar.Id))
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
            return View(guitar);
        }

        // GET: Guitar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guitar = await _context.Guitar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guitar == null)
            {
                return NotFound();
            }

            return View(guitar);
        }

        // POST: Guitar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guitar = await _context.Guitar.FindAsync(id);
            _context.Guitar.Remove(guitar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuitarExists(int id)
        {
            return _context.Guitar.Any(e => e.Id == id);
        }
    }
}
