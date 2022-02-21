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
    public class RentalsController : Controller
    {
        private readonly RentalsContext _context;

        public RentalsController(RentalsContext context)
        {
            _context = context;
        }
        public IEnumerable<object> SelectList()
        {

            var albumsList = _context.Set<Albums>();
            List<object> list = new List<object>();
            IEnumerable<object> en;
            foreach (var album in albumsList)
            {
                
                    if (album.Rented != true)
                    {
                        list.Add(album);


                    }
                }


            en = list;
            return en;
        }
        // GET: Rentals
        public async Task<IActionResult> Index()
        {
            var rentalsContext = _context.Rentals.Include(r => r.Albums).Include(r => r.Users);
            return View(await rentalsContext.ToListAsync());
        }

        // GET: Rentals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentals = await _context.Rentals
                .Include(r => r.Albums)
                .Include(r => r.Users)
                .FirstOrDefaultAsync(m => m.RentalsId == id);
            if (rentals == null)
            {
                return NotFound();
            }

            return View(rentals);
        }

        // GET: Rentals/Create
        public IActionResult Create()
        {
            ViewData["AlbumsId"] = new SelectList(SelectList(), "AlbumsId", "Title");
            ViewData["UsersId"] = new SelectList(_context.Set<Users>(), "UsersId", "Name");
            return View();
        }

        // POST: Rentals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RentalsId,Date,UsersId,AlbumsId")] Rentals rentals)
        {
            var album = _context.Albums.Where(d => d.AlbumsId == rentals.AlbumsId).First();
            album.Rented = true;
            _context.SaveChanges();
            if (ModelState.IsValid)
            {
                _context.Add(rentals);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlbumsId"] = new SelectList(_context.Albums, "AlbumsId", "Title", rentals.AlbumsId);
            ViewData["UsersId"] = new SelectList(_context.Set<Users>(), "UsersId", "Name", rentals.UsersId);
            return View(rentals);
        }

        // GET: Rentals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentals = await _context.Rentals.FindAsync(id);
            if (rentals == null)
            {
                return NotFound();
            }
            ViewData["AlbumsId"] = new SelectList(_context.Albums, "AlbumsId", "Title", rentals.AlbumsId);
            ViewData["UsersId"] = new SelectList(_context.Set<Users>(), "UsersId", "Name", rentals.UsersId);
            return View(rentals);
        }

        // POST: Rentals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RentalsId,Date,UsersId,AlbumsId")] Rentals rentals)
        {
            if (id != rentals.RentalsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentals);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalsExists(rentals.RentalsId))
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
            ViewData["AlbumsId"] = new SelectList(_context.Albums, "AlbumsId", "Title", rentals.AlbumsId);
            ViewData["UsersId"] = new SelectList(_context.Set<Users>(), "UsersId", "Name", rentals.UsersId);
            return View(rentals);
        }

        // GET: Rentals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var rentals = await _context.Rentals
                .Include(r => r.Albums)
                .Include(r => r.Users)
                .FirstOrDefaultAsync(m => m.RentalsId == id);
            if(rentals.Albums.Rented == true)
            {
                rentals.Albums.Rented = false;
                _context.SaveChanges();
            }
            if (rentals == null)
            {
                return NotFound();
            }

            return View(rentals);
        }

        // POST: Rentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rentals = await _context.Rentals.FindAsync(id);
            _context.Rentals.Remove(rentals);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalsExists(int id)
        {
            return _context.Rentals.Any(e => e.RentalsId == id);
        }
    }
}
