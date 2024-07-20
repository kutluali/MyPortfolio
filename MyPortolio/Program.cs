using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using MyPortolio.DAL.Context;

internal class Program
{
	private static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.
		builder.Services.AddControllersWithViews();

		builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
           .AddCookie(options =>
           {
	       options.LoginPath = "/User/Login";
          });

		
		builder.Services.AddDbContext<MyPortfolioContext>(options => options.UseSqlServer("Server=DESKTOP-6J2APNJ;Database=MyPortfolio;Integrated Security=True; TrustServerCertificate=True;"));


		builder.Services.AddMvc(config =>
		{
			var policy = new AuthorizationPolicyBuilder()
							.RequireAuthenticatedUser()
							.Build();
			config.Filters.Add(new AuthorizeFilter(policy));
		});

		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (!app.Environment.IsDevelopment())
		{
			app.UseExceptionHandler("/Home/Error");
			app.UseHsts();
		}

		app.UseHttpsRedirection();
		app.UseStaticFiles();

		app.UseRouting();

		app.UseAuthentication();
		app.UseAuthorization();

		app.MapControllerRoute(
			name: "default",
			pattern: "{controller=Default}/{action=Index}/{id?}");

		app.Run();
	}
}