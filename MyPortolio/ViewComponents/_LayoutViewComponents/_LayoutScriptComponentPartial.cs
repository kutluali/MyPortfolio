using Microsoft.AspNetCore.Mvc;

namespace MyPortolio.ViewComponents._LayoutViewComponents
{
	public class _LayoutScriptComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}

	}
}
