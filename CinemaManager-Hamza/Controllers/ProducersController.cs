using CinemaManager_Hamza.Models.Cinema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaManager_Hamza.Controllers
{
    public class ProducersController : Controller
    {

        CinemaDbContext _context;
        public ProducersController(CinemaDbContext context)
        {
            _context = context;
        }

            // GET: ProducersController
            public ActionResult Index()
        {
            var producers = _context.Producers.ToList();

            return View(producers);
        }

        // GET: ProducersController/Details/5
        public ActionResult Details(int id)
        {

            return View(_context.Producers.Find(id));
        }

        // GET: ProducersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProducersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Producer p)
        {
            try
            {
                _context.Producers.Add(p);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProducersController/Edit/5
        public ActionResult Edit(int id)
        {
            var prod = _context.Producers.Find(id);
            return View(prod);
        }

        // POST: ProducersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Producer p)
        {
            try
            {
                _context.Producers.Update(p);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProducersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_context.Producers.Find(id));
        }

        // POST: ProducersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Producer p)
        {
            try
            {
                _context.Producers.Remove(p);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
