using Microsoft.AspNetCore.Mvc;
using MyPortolio.DAL.Context;

namespace MyPortolio.ViewComponents._LayoutViewComponents
{
	public class _LayoutSidebarComponentPartial : ViewComponent
	{
		private readonly MyPortfolioContext _db;

        public _LayoutSidebarComponentPartial(MyPortfolioContext db)
        {
			_db = db;
        }
        public IViewComponentResult Invoke()
		{
			ViewBag.name=_db.users.Select(x => x.Name).FirstOrDefault();	
			ViewBag.username=_db.users.Select(x=>x.UserName).FirstOrDefault();
			return View();
		}
	}
}
