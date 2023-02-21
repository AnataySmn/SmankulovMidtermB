using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmankulovMidtermB.Data;
using SmankulovMidtermB.Models;

namespace SmankulovMidtermB.Controllers
{
    public class TacosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TacosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tacos
        public async Task<IActionResult> Index()
        {
              return View(await _context.Taco.ToListAsync());
        }

        // GET: Tacos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Taco == null)
            {
                return NotFound();
            }

            var taco = await _context.Taco
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taco == null)
            {
                return NotFound();
            }

            return View(taco);
        }

        // GET: Tacos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tacos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Size,Filling,FirstName,LastName,Phone,DateRequested,Total")] Taco taco)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taco);
        }

        // GET: Tacos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Taco == null)
            {
                return NotFound();
            }

            var taco = await _context.Taco.FindAsync(id);
            if (taco == null)
            {
                return NotFound();
            }
            return View(taco);
        }

        // POST: Tacos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Size,Filling,FirstName,LastName,Phone,DateRequested,Total")] Taco taco)
        {
            if (id != taco.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taco);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TacoExists(taco.Id))
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
            return View(taco);
        }

        // GET: Tacos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Taco == null)
            {
                return NotFound();
            }

            var taco = await _context.Taco
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taco == null)
            {
                return NotFound();
            }

            return View(taco);
        }

        // POST: Tacos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Taco == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Taco'  is null.");
            }
            var taco = await _context.Taco.FindAsync(id);
            if (taco != null)
            {
                _context.Taco.Remove(taco);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TacoExists(int id)
        {
          return _context.Taco.Any(e => e.Id == id);
        }
    }
}
