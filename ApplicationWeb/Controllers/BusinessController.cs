using Microsoft.AspNetCore.Mvc;

namespace ApplicationWeb.Controllers
{
    public class BusinessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
