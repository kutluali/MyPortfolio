using Microsoft.AspNetCore.Mvc;
using MyPortolio.DAL.Context;
using MyPortolio.DAL.Entities;

namespace MyPortfolio.ViewComponents
{
    public class _MessageComponentPartial : ViewComponent
    {
        private readonly MyPortfolioContext _db;
        public _MessageComponentPartial(MyPortfolioContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            return View(_db.Messages.ToList());
        }

        //[HttpPost]
        //public async Task<IViewComponentResult> InvokeAsync(Message ms)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _db.Messages.Add(ms);
        //            await _db.SaveChangesAsync();
        //            TempData["SuccessMessage"] = "Mesajınız gönderildi, teşekkür ederiz!.";
        //        }
        //        catch (Exception ex)
        //        {
        //            TempData["ErrorMessage"] = "Bir şeyler yanlış gitti. Lütfen tekrar deneyin. " + ex.Message;
        //        }
        //    }
        //    else
        //    {
        //        TempData["ErrorMessage"] = "Lütfen formdaki hataları düzeltin ve tekrar deneyin.";
        //    }

        //    return View("Default");
        //}
    }
}
