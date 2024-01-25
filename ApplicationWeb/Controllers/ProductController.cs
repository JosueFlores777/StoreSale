using Microsoft.AspNetCore.Mvc;

namespace ApplicationWeb.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
