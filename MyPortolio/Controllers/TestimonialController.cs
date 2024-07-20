using Microsoft.AspNetCore.Mvc;
using MyPortolio.DAL.Context;
using MyPortolio.DAL.Entities;

namespace MyPortfolio.Controllers
{
	public class TestimonialController : Controller
	{
		private readonly MyPortfolioContext _db;

		public TestimonialController(MyPortfolioContext db)
		{
			_db = db;
		}

		public IActionResult Index()
		{
			return View(_db.Testimonials.ToList());
		}

		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(Testimonial tst, IFormFile file)
		{
			if (file != null)
			{


				var filename = Path.GetFileName(file.FileName);
				var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "hola", "images", "Testimonial", filename);


				using (var stream = System.IO.File.Create(filePath))
				{
					await file.CopyToAsync(stream);
				}
				tst.ImageUrl = filename;
			}

			var record = _db.Testimonials.Add(tst);
			_db.SaveChanges(); return RedirectToAction("Index");

		}

		public IActionResult Update(int id)
		{
			var record = _db.Testimonials.Find(id);
			return View(record);
		}

		[HttpPost]
		public async Task<IActionResult> Update(Testimonial tst, IFormFile file)
		{
			if (file != null)
			{

				var filename = Path.GetFileName(file.FileName);
				var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "hola", "images", "portfolio", filename);


				using (var stream = System.IO.File.Create(filePath))
				{
					await file.CopyToAsync(stream);
				}
				tst.ImageUrl = filename;
			}

			var record = _db.Testimonials.Add(tst);
			_db.SaveChanges(); return RedirectToAction("Index");

		}

		public IActionResult Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var record = _db.Testimonials.Find(id); return View("Delete", record);
		}
		[HttpPost]
		public IActionResult Delete(int id, int SocialMediaId)
		{
			if (id != SocialMediaId)
			{
				return NotFound();
			}

			var record = _db.Testimonials.Find(id);
			_db.Testimonials.Remove(entity: record);
			_db.SaveChanges(); return RedirectToAction("Index");
		}
	}
}
