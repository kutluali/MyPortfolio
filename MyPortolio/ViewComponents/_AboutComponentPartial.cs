﻿using Microsoft.AspNetCore.Mvc;
using MyPortolio.DAL.Context;

namespace MyPortolio.ViewComponents
{
    public class _AboutComponentPartial : ViewComponent
    {
        private readonly MyPortfolioContext _db;

        public _AboutComponentPartial(MyPortfolioContext db)
        {
            _db=db;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.aboutTitle = _db.Abouts.Select(x => x.Title).FirstOrDefault();
            ViewBag.aboutSubDescription=_db.Abouts.Select(x=>x.SubDescription).FirstOrDefault();
            ViewBag.detail=_db.Abouts.Select(x=>x.Details).FirstOrDefault();
            return View();
        }
    }
}
