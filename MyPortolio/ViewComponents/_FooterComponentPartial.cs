using Microsoft.AspNetCore.Mvc;
using MyPortolio.DAL.Context;
namespace MyPortolio.ViewComponents
{
    public class _FooterComponentPartial : ViewComponent
	{
		private readonly MyPortfolioContext _db;

		public _FooterComponentPartial(MyPortfolioContext db)
		{
			_db = db;
		}
		public IViewComponentResult Invoke()
        {
            return View(_db.SocialMedias.ToList());
        }
    }
}
