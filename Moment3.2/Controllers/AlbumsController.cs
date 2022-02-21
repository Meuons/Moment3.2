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
    public class AlbumsController : Controller
    {
        private readonly AlbumsContext _context;

        public AlbumsController(AlbumsContext context)
        {
            _context = context;
        }

        // GET: Albums
        
            public async Task<IActionResult> Index(string searchString)
            {
                var albums = from m in _context.Albums
                             .Include(a => a.Genres)
                             select m;
               
                if (!String.IsNullOrEmpty(searchString))
                {
                   albums = albums.Where(s => s.Title!.Contains(searchString));
                }

                return View(await albums.ToListAsync());
            }
       

        // GET: Albums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var albums = await _context.Albums
                .Include(a => a.Genres)
                .FirstOrDefaultAsync(m => m.AlbumsId == id);
            if (albums == null)
            {
                return NotFound();
            }

            return View(albums);
        }


        // GET: Albums/Create
        public IActionResult Create()
        {
            ViewData["GenresId"] = new SelectList(_context.Genres, "GenresId", "Name");
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlbumsId,Title,Artist,GenresId,Rented,Year")] Albums albums)
        {
            if (ModelState.IsValid)
            {
                _context.Add(albums);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenresId"] = new SelectList(_context.Genres, "GenresId", "Name", albums.GenresId);
            return View(albums);
        }

        // GET: Albums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var albums = await _context.Albums.FindAsync(id);
            if (albums == null)
            {
                return NotFound();
            }
            ViewData["GenresId"] = new SelectList(_context.Genres, "GenresId", "Name", albums.GenresId);
            return View(albums);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlbumsId,Title,Artist,GenresId,Rented,Year")] Albums albums)
        {
            if (id != albums.AlbumsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(albums);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumsExists(albums.AlbumsId))
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
            ViewData["GenresId"] = new SelectList(_context.Genres, "GenresId", "Name", albums.GenresId);
            return View(albums);
        }

        // GET: Albums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var albums = await _context.Albums
                .Include(a => a.Genres)
                .FirstOrDefaultAsync(m => m.AlbumsId == id);
            if (albums == null)
            {
                return NotFound();
            }

            return View(albums);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var albums = await _context.Albums.FindAsync(id);
            _context.Albums.Remove(albums);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlbumsExists(int id)
        {
            return _context.Albums.Any(e => e.AlbumsId == id);
        }
    }
}
