using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Models;
using MyPortolio.DAL.Context;
using MyPortolio.DAL.Entities;

namespace MyPortolio.ViewComponents
{
    public class _ContactComponentPartial : ViewComponent
    {
        private readonly MyPortfolioContext _db;
        public _ContactComponentPartial(MyPortfolioContext db)
        {
            _db = db;
        }

        public IViewComponentResult Invoke()
        {
           return View(_db.Contacts.ToList());
        }

        

    }
}
