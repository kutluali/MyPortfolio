using Microsoft.AspNetCore.Mvc;
using MyPortolio.DAL.Context;
using MyPortolio.DAL.Entities;

namespace MyPortfolio.Controllers
{
    public class AboutController : Controller
    {
        private readonly MyPortfolioContext _db;

        public AboutController(MyPortfolioContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Abouts.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(About abt)
        {
            _db.Abouts.Add(abt);
            _db.SaveChanges(); return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var record = _db.Abouts.Find(id);
            return View(record);
        }

        [HttpPost]
        public IActionResult Update(About abt)
        {
            _db.Abouts.Update(abt);
            _db.SaveChanges(); return RedirectToAction("Index");

        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var record = _db.Abouts.Find(id); return View("Delete", record);
        }
        [HttpPost]
        public IActionResult Delete(int id, int AboutId)
        {
            if (id != AboutId)
            {
                return NotFound();
            }

            var record = _db.Abouts.Find(id);
            _db.Abouts.Remove(entity: record);
            _db.SaveChanges(); return RedirectToAction("Index");
        }
    }
}
