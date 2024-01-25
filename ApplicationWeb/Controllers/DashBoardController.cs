using Microsoft.AspNetCore.Mvc;

namespace ApplicationWeb.Controllers
{
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
