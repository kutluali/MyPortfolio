using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Models;
using MyPortolio.DAL.Context;

namespace MyPortolio.ViewComponents
{
    public class _FeatureComponentPartial : ViewComponent
    {
        private readonly MyPortfolioContext _context;

        public _FeatureComponentPartial(MyPortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var socialMedias = _context.SocialMedias.ToList();
            var features = _context.Features.ToList();

            var model = new SocialMediaFeatureViewModel
            {
                SocialMedias = socialMedias,
                Features = features
            };

            return View(model);

        }
    }

}

