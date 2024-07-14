using Microsoft.AspNetCore.Mvc;
using MyPortolio.DAL.Context;
namespace MyPortolio.ViewComponents
{
    public class _SkillComponentPartial : ViewComponent
    {
        private readonly MyPortfolioContext _db;
        public _SkillComponentPartial(MyPortfolioContext db)
        {
            _db = db;
        }

        public IViewComponentResult Invoke()
        {
            return View(_db.Skills.ToList());
        }
    }
}
