using Microsoft.AspNetCore.Mvc;
using MyPortolio.DAL.Context;
using MyPortfolio.DAL.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using MyPortolio.DAL.Entities;

namespace MyPortfolio.Controllers
{
	[AllowAnonymous][Authorize]
	public class UserController : Controller
	{
		private readonly MyPortfolioContext _db;
		public UserController(MyPortfolioContext db)
		{
			_db = db;
		}
		
		public IActionResult Login()
		{
			if (User.Identity!.IsAuthenticated)
			{
				return RedirectToAction("Index", "Admin");
			}
			return View();
		}



		[HttpPost]
		public async Task<IActionResult> Login(string username, string password)
		{
			var admin = _db.users.SingleOrDefault(a => a.Email == username && a.Password == password);
			if (admin != null)
			{
				var claims = new List<Claim>
			    {

				new Claim(ClaimTypes.Name, username)

			    };

				var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
				var authProperties = new AuthenticationProperties
				{
					IsPersistent = true
				};

				await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

				return RedirectToAction("Inbox", "Message");
			}
			ViewBag.Error = "Geçersiz kullanıcı adı veya şifre";
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Index","Default");
		}

        public IActionResult InformationsIndex()
        {
            return View(_db.users.ToList());
        }

        public IActionResult InformationsCreate()
        {
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> InformationsCreate(User user, IFormFile file, IFormFile CvUrl)
		{
            if (file != null)
            {
                var imageFilename = Path.GetFileName(file.FileName);
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "hola", "images", "portfolio", imageFilename);

                using (var stream = System.IO.File.Create(imagePath))
                {
                    await file.CopyToAsync(stream);
                }
                user.Image = imageFilename;
            }

            if (CvUrl != null)
            {
                var pdfFilename = Path.GetFileName(CvUrl.FileName);
                var pdfPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Admin", "img", pdfFilename);

                using (var stream = System.IO.File.Create(pdfPath))
                {
                    await CvUrl.CopyToAsync(stream);
                }
                user.Cv = pdfFilename;
            }

            var record = _db.users.Add(user);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

		public IActionResult InformationsUpdate(int id)
        {
			var record = _db.users.Find(id);
			if (record == null)
			{
				return NotFound(); // Kullanıcı bulunamazsa hata döndür.
			}
			return View(record);
		}

        [HttpPost]
        public async Task<IActionResult> InformationsUpdate(User user, IFormFile file, IFormFile CvUrl)
        {
			if (file != null && file.Length > 0)
			{
				var imageFilename = Path.GetFileName(file.FileName);
				var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "hola", "images", "portfolio", imageFilename);

				// Dizin oluşturma
				var imageDirectory = Path.GetDirectoryName(imagePath);
				if (!Directory.Exists(imageDirectory))
				{
					Directory.CreateDirectory(imageDirectory);
				}

				using (var stream = new FileStream(imagePath, FileMode.Create))
				{
					await file.CopyToAsync(stream);
				}
				user.Image = imageFilename;
			}

			if (CvUrl != null && CvUrl.Length > 0)
			{
				var pdfFilename = Path.GetFileName(CvUrl.FileName);
				var pdfPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Admin", "img", "Cvfile", pdfFilename);

				// Dizin oluşturma
				var pdfDirectory = Path.GetDirectoryName(pdfPath);
				if (!Directory.Exists(pdfDirectory))
				{
					Directory.CreateDirectory(pdfDirectory);
				}

				using (var stream = new FileStream(pdfPath, FileMode.Create))
				{
					await CvUrl.CopyToAsync(stream);
				}
				user.Cv = pdfFilename;
			}

			var existingUser = _db.users.Find(user.UserId);
			if (existingUser == null)
			{
				return NotFound(); // Kullanıcı bulunamazsa hata döndür.
			}

			existingUser.Name = user.Name;
			existingUser.UserName = user.UserName;
			existingUser.Email = user.Email;
			existingUser.Image = user.Image ?? existingUser.Image; // Var olan resmi koruyun
			existingUser.Cv = user.Cv ?? existingUser.Cv; // Var olan CV'yi koruyun

			_db.users.Update(existingUser);
			await _db.SaveChangesAsync();
			return RedirectToAction("InformationsIndex");

		}

		[HttpGet]
		public IActionResult DownloadCv()
		{
			var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "cv.pdf");
			var fileBytes = System.IO.File.ReadAllBytes(filePath);
			return File(fileBytes, "application/pdf", "cv.pdf");
		}

		[HttpGet]
		public IActionResult ContactMe()
		{
			return Redirect("mailto:example@example.com");
		}
	}
}
