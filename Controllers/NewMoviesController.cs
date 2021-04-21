using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IS_413_Assignment_3.Models;

namespace IS_413_Assignment_3.Controllers
{
    public class NewMoviesController : Controller
    {
        private readonly NewMovieDbContext _context;

        public NewMoviesController(NewMovieDbContext context)
        {
            _context = context;
        }

        // GET: NewMovies
        public async Task<IActionResult> Index()
        {
            return View(await _context.NewMovie.ToListAsync());
        }

        // GET: NewMovies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newMovie = await _context.NewMovie
                .FirstOrDefaultAsync(m => m.NewMovieId == id);
            if (newMovie == null)
            {
                return NotFound();
            }

            return View(newMovie);
        }

        // GET: NewMovies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NewMovies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NewMovieId,Category,Title,Year,Director,Rating,Edited,LentTo,Notes")] NewMovie newMovie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newMovie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newMovie);
        }

        // GET: NewMovies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newMovie = await _context.NewMovie.FindAsync(id);
            if (newMovie == null)
            {
                return NotFound();
            }
            return View(newMovie);
        }

        // POST: NewMovies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NewMovieId,Category,Title,Year,Director,Rating,Edited,LentTo,Notes")] NewMovie newMovie)
        {
            if (id != newMovie.NewMovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newMovie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewMovieExists(newMovie.NewMovieId))
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
            return View(newMovie);
        }

        // GET: NewMovies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newMovie = await _context.NewMovie
                .FirstOrDefaultAsync(m => m.NewMovieId == id);
            if (newMovie == null)
            {
                return NotFound();
            }

            return View(newMovie);
        }

        // POST: NewMovies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newMovie = await _context.NewMovie.FindAsync(id);
            _context.NewMovie.Remove(newMovie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewMovieExists(int id)
        {
            return _context.NewMovie.Any(e => e.NewMovieId == id);
        }
    }
}
