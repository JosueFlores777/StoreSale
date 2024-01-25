using Microsoft.AspNetCore.Mvc;

namespace ApplicationWeb.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
