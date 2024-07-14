using Microsoft.AspNetCore.Mvc;
using MyPortolio.DAL.Context;

namespace MyPortolio.Controllers
{
	public class StatisticController : Controller
	{
		private readonly MyPortfolioContext _db;

        public StatisticController(MyPortfolioContext db)
        {
            _db=db;
        }
        public IActionResult Index()
		{
			ViewBag.v1 = _db.Skills.Count();
			ViewBag.v2 = _db.Messages.Count();
			ViewBag.v3 = _db.Messages.Where(x=>x.IsRead==false).Count();
			ViewBag.v4 = _db.Messages.Where(x=>x.IsRead==true).Count();
			return View();
		}
	}
}
