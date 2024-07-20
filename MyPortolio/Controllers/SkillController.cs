using Microsoft.AspNetCore.Mvc;
using MyPortolio.DAL.Context;
using MyPortolio.DAL.Entities;

namespace MyPortfolio.Controllers
{
    public class SkillController : Controller
    {
        private readonly MyPortfolioContext _db;

        public SkillController(MyPortfolioContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Skills.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Skill skl)
        {
            _db.Skills.Add(skl);
            _db.SaveChanges(); return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var record = _db.Skills.Find(id);
            return View(record);
        }

        [HttpPost]
        public IActionResult Update(Skill skl)
        {
            _db.Skills.Update(skl);
            _db.SaveChanges(); return RedirectToAction("Index");

        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var record = _db.Skills.Find(id); return View("Delete", record);
        }
        [HttpPost]
        public IActionResult Delete(int id, int SkillsId)
        {
            if (id != SkillsId)
            {
                return NotFound();
            }

            var record = _db.Skills.Find(id);
            _db.Skills.Remove(entity: record);
            _db.SaveChanges(); return RedirectToAction("Index");
        }
    }
}
