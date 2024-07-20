using Microsoft.AspNetCore.Mvc;
using MyPortolio.DAL.Context;

namespace MyPortolio.ViewComponents._LayoutViewComponents
{
	public class _LayoutNavbarComponentPartial: ViewComponent
	{
		private readonly MyPortfolioContext _db;

        public _LayoutNavbarComponentPartial(MyPortfolioContext db)
        {
			_db = db;
        }

        public IViewComponentResult Invoke()
		{
			ViewBag.name = _db.users.Select(x => x.Name).SingleOrDefault();
			ViewBag.email = _db.users.Select(x => x.Email).SingleOrDefault();
			ViewBag.todoListCount=_db.ToDoList.Where(x=>x.Status==false).Count();
			var record=_db.ToDoList.Where(x=>x.Status==false).ToList();
			return View(record);
		}
	}
}
