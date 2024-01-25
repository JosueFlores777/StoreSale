using Microsoft.AspNetCore.Mvc;

namespace ApplicationWeb.Controllers
{
    public class SalesReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
