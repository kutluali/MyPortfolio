using Microsoft.AspNetCore.Mvc;
using MyPortolio.DAL.Context;
using MyPortolio.DAL.Entities;

namespace MyPortolio.Controllers
{
    public class ToDoListController : Controller
    {
        private readonly MyPortfolioContext _db;

        public ToDoListController(MyPortfolioContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.ToDoList.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ToDoList to)
        {
            to.Status = false;
            _db.ToDoList.Add(to);
            _db.SaveChanges(); return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var record=_db.ToDoList.Find(id); return View(record);
        }
        [HttpPost]
        public IActionResult Update(ToDoList to)
        {
            var record=_db.ToDoList.Update(to);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var record = _db.ToDoList.Find(id); return View("Delete", record);
        }
        [HttpPost]
        public IActionResult Delete(int id, int ExperienceId)
        {
            if (id != ExperienceId)
            {
                return NotFound();
            }

            var record = _db.ToDoList.Find(id);
            _db.ToDoList.Remove(entity: record);
            _db.SaveChanges(); return RedirectToAction("ExperienceList");
        }

    }
}
