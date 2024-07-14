using Microsoft.AspNetCore.Mvc;
namespace MyPortolio.ViewComponents
{
    public class _TestimonialPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
