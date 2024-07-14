using Microsoft.AspNetCore.Mvc;
using MyPortolio.DAL.Context;
using MyPortolio.DAL.Entities;

namespace MyPortolio.Controllers
{
    public class ExperienceController : Controller
    {
        private readonly MyPortfolioContext _db;

        public ExperienceController(MyPortfolioContext db)
        {
            _db=db;
        }

        public IActionResult ExperienceList()
        {
            return View(_db.Experiences.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
		public IActionResult Create(Experience exp)
        {
            _db.Experiences.Add(exp);
            _db.SaveChanges(); return RedirectToAction("ExperienceList");
        }

        public IActionResult Update(int id)
        {
            var record = _db.Experiences.Find(id);
            return View(record);
        }

        [HttpPost]
		public IActionResult Update(Experience exp)
        {
            _db.Experiences.Update(exp);
            _db.SaveChanges(); return RedirectToAction("ExperienceList");

		}

        public IActionResult ChangeToDoListToTrue(int id)
        {
            var record=_db.ToDoList.Find(id);
            record.Status = true;
            _db.SaveChanges(); return RedirectToAction("Index");
        }

        public IActionResult ChangeToDoListToFalse(int id)
        {
            var record = _db.ToDoList.Find(id);
            record.Status = false;
            _db.SaveChanges(); return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
			if (id == null)
			{
				return NotFound();
			}
            var record = _db.Experiences.Find(id); return View("Delete", record);
        }
        [HttpPost]
        public IActionResult Delete(int id, int ExperienceId)
        {
            if (id != ExperienceId)
            {
                return NotFound();
            }

            var record=_db.Experiences.Find(id);
            _db.Experiences.Remove(entity: record);
            _db.SaveChanges(); return RedirectToAction("ExperienceList");
        }
    }
}
