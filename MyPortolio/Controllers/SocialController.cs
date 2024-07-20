using Microsoft.AspNetCore.Mvc;
using MyPortolio.DAL.Context;
using MyPortolio.DAL.Entities;

namespace MyPortfolio.Controllers
{
    public class SocialController : Controller
    {
        private readonly MyPortfolioContext _db;

        public SocialController(MyPortfolioContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.SocialMedias.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SocialMedia scl)
        {
            _db.SocialMedias.Add(scl);
            _db.SaveChanges(); return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var record = _db.SocialMedias.Find(id);
            return View(record);
        }

        [HttpPost]
        public IActionResult Update(SocialMedia scl)
        {
            _db.SocialMedias.Update(scl);
            _db.SaveChanges(); return RedirectToAction("Index");

        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var record = _db.SocialMedias.Find(id); return View("Delete", record);
        }
        [HttpPost]
        public IActionResult Delete(int id, int SocialMediaId)
        {
            if (id != SocialMediaId)
            {
                return NotFound();
            }

            var record = _db.SocialMedias.Find(id);
            _db.SocialMedias.Remove(entity: record);
            _db.SaveChanges(); return RedirectToAction("Index");
        }
    }
}
