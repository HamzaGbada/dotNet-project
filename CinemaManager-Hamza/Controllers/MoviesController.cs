using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CinemaManager_Hamza.Models.Cinema;

namespace CinemaManager_Hamza.Controllers
{
    public class MoviesController : Controller
    {
        private readonly CinemaDbContext _context;

        public MoviesController(CinemaDbContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            var cinemaDbContext = _context.Movies.Include(m => m.Producer);
            return View(await cinemaDbContext.ToListAsync());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .Include(m => m.Producer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            ViewData["ProducerId"] = new SelectList(_context.Producers, "Id", "Id");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Genre,ProducerId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProducerId"] = new SelectList(_context.Producers, "Id", "Id", movie.ProducerId);
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            ViewData["ProducerId"] = new SelectList(_context.Producers, "Id", "Id", movie.ProducerId);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Genre,ProducerId")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
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
            ViewData["ProducerId"] = new SelectList(_context.Producers, "Id", "Id", movie.ProducerId);
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .Include(m => m.Producer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
    // Refactored Controller Actions

public class MovieController : Controller
{
    private readonly CinemaDBContext _context;

    public MovieController(CinemaDBContext context)
    {
        _context = context;
    }

    // Movies with their producers using eager loading
    public ActionResult MoviesAndTheirProds()
    {
        var cinemaDBContext = _context.Movies.Include(m => m.Producer).ToList();
        return View(cinemaDBContext);
    }

    // Movies and their producers using custom model (DTO)
    public ActionResult MoviesAndTheirProds_UsingModel()
    {
        var laListe = _context.Movies
            .Join(_context.Producers, m => m.ProducerId, p => p.Id, (m, p) => new ProdMovie
            {
                mTitle = m.Title,
                mGenre = m.Genre,
                pName = p.Name,
                pNat = p.Nationality
            }).ToList();

        return View(laListe);
    }

    // Search movies by title (case insensitive)
    public ActionResult SearchByTitle(string titre = "")
    {
        var movies = _context.Movies.Include(m => m.Producer)
            .Where(m => string.IsNullOrEmpty(titre) || m.Title.Contains(titre, StringComparison.OrdinalIgnoreCase))
            .ToList();

        return View(movies);
    }

    // Search movies by genre (case insensitive)
    public ActionResult SearchByGenre(string genre = "")
    {
        var movies = _context.Movies.Include(m => m.Producer)
            .Where(m => string.IsNullOrEmpty(genre) || m.Genre.Contains(genre, StringComparison.OrdinalIgnoreCase))
            .ToList();

        return View(movies);
    }

    // Search movies by both genre and title (case insensitive)
    public ActionResult SearchBy2(string genre, string titre)
    {
        // Get distinct genres for dropdown list
        var genres = _context.Movies.Select(m => m.Genre).Distinct().ToList();
        ViewBag.genre = new SelectList(genres);

        var moviesQuery = _context.Movies.Include(m => m.Producer).AsQueryable();

        // Filter based on provided genre and title
        if (!string.IsNullOrEmpty(titre))
        {
            moviesQuery = moviesQuery.Where(m => m.Title.Contains(titre, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrEmpty(genre))
        {
            moviesQuery = moviesQuery.Where(m => m.Genre.Contains(genre, StringComparison.OrdinalIgnoreCase));
        }

        var movies = moviesQuery.ToList();
        return View(movies);
    }
}

}
