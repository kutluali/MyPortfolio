using Microsoft.AspNetCore.Mvc;
using MyPortolio.DAL.Context;
using MyPortolio.DAL.Entities;

namespace MyPortfolio.Controllers
{
    public class PortfoiController : Controller
    {
        private readonly MyPortfolioContext _db;

        public PortfoiController(MyPortfolioContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Portfolios.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Portfolio prt, IFormFile file)
        {
            if (file != null)
            {


                var filename = Path.GetFileName(file.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "hola", "images", "portfolio", filename);


                using (var stream = System.IO.File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                }
                prt.ImageUrl = filename;
            }

            var record = _db.Portfolios.Add(prt);
            _db.SaveChanges(); return RedirectToAction("Index");

        }

        public IActionResult Update(int id)
        {
            var record = _db.Portfolios.Find(id);
            return View(record);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Portfolio prt, IFormFile file)
        {
            if (file != null)
            {

                var filename = Path.GetFileName(file.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "hola", "images", "portfolio", filename);


                using (var stream = System.IO.File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                }
                prt.ImageUrl = filename;
            }

            var record = _db.Portfolios.Update(prt);
            _db.SaveChanges(); return RedirectToAction("Index");

        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var record = _db.Portfolios.Find(id); return View("Delete", record);
        }
        [HttpPost]
        public IActionResult Delete(int id, int SocialMediaId)
        {
            if (id != SocialMediaId)
            {
                return NotFound();
            }

            var record = _db.Portfolios.Find(id);
            _db.Portfolios.Remove(entity: record);
            _db.SaveChanges(); return RedirectToAction("Index");
        }
    }
}
