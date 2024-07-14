using Microsoft.AspNetCore.Mvc;
using MyPortolio.DAL.Context;

namespace MyPortolio.ViewComponents
{
    public class _FeatureComponentPartial : ViewComponent
    {
        private readonly MyPortfolioContext _db;

        public _FeatureComponentPartial(MyPortfolioContext db)
        {
            _db= db;
        }
        public IViewComponentResult Invoke()
        {
            return View(_db.Features.ToList());
        }

    }
}
