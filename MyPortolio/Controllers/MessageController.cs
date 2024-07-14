using Microsoft.AspNetCore.Mvc;
using MyPortolio.DAL.Context;

namespace MyPortolio.Controllers
{
	public class MessageController : Controller
	{
		private readonly MyPortfolioContext _db;

        public MessageController(MyPortfolioContext db)
        {
			_db = db;
        }
        public IActionResult Inbox()
		{
			return View(_db.Messages.ToList());
		}

		public IActionResult ChangeIsReadToTrue(int id)
		{
			var value=_db.Messages.Find(id);
			value.IsRead = true;
			_db.SaveChanges(); return RedirectToAction("Inbox");
		}

        public IActionResult Detail(int id)
        {
            return View(_db.Messages.Find(id));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var record = _db.Messages.Find(id); return View("Delete", record);
        }
        [HttpPost]
        public IActionResult Delete(int id, int ExperienceId)
        {
            if (id != ExperienceId)
            {
                return NotFound();
            }

            var record = _db.Messages.Find(id);
            _db.Messages.Remove(entity: record);
            _db.SaveChanges(); return RedirectToAction("ExperienceList");
        }
    }
}
