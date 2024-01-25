using Microsoft.AspNetCore.Mvc;

namespace ApplicationWeb.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
