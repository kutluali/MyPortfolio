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
				return RedirectToAction("Inbox", "Message");
			}
			return View();
		}


		//public IActionResult Update(int id)
		//{
		//	var record = _db.users.SingleOrDefault(x=>x.UserId==id);
		//	return View(record);
		//}

		//[HttpPost]
		//public async Task<IActionResult> Update(User user)
		//{
		//	if (ModelState.IsValid)
		//	{
		//		//var record = _db.users.SingleOrDefault(x => x.UserId==userid);

		//		if (record == null)
		//		{
		//			return NotFound();
		//		}

		//		// Email ve mevcut şifreyi güncelle
		//		user.Email = user.Email;

		//		// Şifre değişikliği kontrolü
		//		if (!string.IsNullOrEmpty(record.Password))
		//		{
		//			if (!VerifyPassword(user.Password, user.Password))
		//			{
		//				ModelState.AddModelError("", "Current password is incorrect.");
		//				return View(user);
		//			}

		//			if (!string.IsNullOrEmpty(user.NewPassword))
		//			{
		//				user.Password = HashPassword(user.NewPassword);
		//			}
		//		}

		//		_db.Update(user);
		//		await _db.SaveChangesAsync();

		//		TempData["SuccessMessage"] = "Profile updated successfully.";
		//		return RedirectToAction("Update");
		//	}

		//	return View(user);

		//}

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

		public IActionResult CvList()
		{
			return View();
		}
	}
}
