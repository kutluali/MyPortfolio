using Microsoft.AspNetCore.Mvc;
using MyPortolio.DAL.Context;

namespace MyPortfolio.ViewComponents
{
    public class _TestimonialComponentPartial :ViewComponent
    {
        private readonly MyPortfolioContext _db;

        public _TestimonialComponentPartial(MyPortfolioContext db)
        {
                _db=db;
        }

        public IViewComponentResult Invoke()
        {
            return View(_db.Testimonials.ToList());
        }
    }
}
