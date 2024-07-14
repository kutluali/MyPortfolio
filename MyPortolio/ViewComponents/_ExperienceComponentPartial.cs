using Microsoft.AspNetCore.Mvc;
using MyPortolio.DAL.Context;
namespace MyPortolio.ViewComponents
{
    public class _ExperienceComponentPartial : ViewComponent
    {
        private readonly MyPortfolioContext _db;
        public _ExperienceComponentPartial(MyPortfolioContext db)
        {
                _db=db;
        }
        public IViewComponentResult Invoke()
        {
            return View(_db.Experiences.ToList());
        }
    }
}
