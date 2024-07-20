using Microsoft.AspNetCore.Mvc;
using MyPortolio.DAL.Context;
using MyPortolio.DAL.Entities;

namespace MyPortfolio.Controllers
{
    public class ContactController : Controller
    {
        private readonly MyPortfolioContext _db;

        public ContactController(MyPortfolioContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Contacts.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Contact cnt)
        {
            _db.Contacts.Add(cnt);
            _db.SaveChanges(); return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var record = _db.Contacts.Find(id);
            return View(record);
        }

        [HttpPost]
        public IActionResult Update(Contact cnt)
        {
            _db.Contacts.Update(cnt);
            _db.SaveChanges(); return RedirectToAction("Index");

        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var record = _db.Contacts.Find(id); return View("Delete", record);
        }
        [HttpPost]
        public IActionResult Delete(int id, int SocialMediaId)
        {
            if (id != SocialMediaId)
            {
                return NotFound();
            }

            var record = _db.Contacts.Find(id);
            _db.Contacts.Remove(entity: record);
            _db.SaveChanges(); return RedirectToAction("Index");
        }
    }
}
