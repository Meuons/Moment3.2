#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Moment3._2.Models;
using Moment_3._2.Data;

namespace Moment3._2.Controllers
{
    public class GenresController : Controller
    {
        private readonly GenresContext _context;

        public GenresController(GenresContext context)
        {
            _context = context;
        }

        // GET: Genres
        public async Task<IActionResult> Index(string searchString)
        {
            var genres = from m in _context.Genres
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                genres = genres.Where(s => s.Name!.Contains(searchString));
            }

            return View(await genres.ToListAsync());
        }


        // GET: Genres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genres = await _context.Genres
                .FirstOrDefaultAsync(m => m.GenresId == id);
            if (genres == null)
            {
                return NotFound();
            }

            return View(genres);
        }

        // GET: Genres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Genres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GenresId,Name")] Genres genres)
        {
            if (ModelState.IsValid)
            {
                _context.Add(genres);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(genres);
        }

        // GET: Genres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genres = await _context.Genres.FindAsync(id);
            if (genres == null)
            {
                return NotFound();
            }
            return View(genres);
        }

        // POST: Genres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("GenresId,Name")] Genres genres)
        {
            if (id != genres.GenresId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(genres);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenresExists(genres.GenresId))
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
            return View(genres);
        }

        // GET: Genres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genres = await _context.Genres
                .FirstOrDefaultAsync(m => m.GenresId == id);
            if (genres == null)
            {
                return NotFound();
            }

            return View(genres);
        }

        // POST: Genres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var genres = await _context.Genres.FindAsync(id);
            _context.Genres.Remove(genres);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GenresExists(int? id)
        {
            return _context.Genres.Any(e => e.GenresId == id);
        }
    }
}
