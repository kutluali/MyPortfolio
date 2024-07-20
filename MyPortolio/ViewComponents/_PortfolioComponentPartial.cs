using Microsoft.AspNetCore.Mvc;
using MyPortolio.DAL.Context;
namespace MyPortolio.ViewComponents
{
    public class _PortfolioComponentPartial : ViewComponent
    {
		private readonly MyPortfolioContext _db;
		public _PortfolioComponentPartial(MyPortfolioContext db)
		{
			_db = db;
		}
		public IViewComponentResult Invoke()
		{
			return View(_db.Experiences.ToList());
		}
	}
}
