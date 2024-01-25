using Microsoft.AspNetCore.Mvc;

namespace ApplicationWeb.Controllers
{
    public class NewSalesController : Controller
    {
        public IActionResult NewSale()
        {
            return View();
        }
        public IActionResult HistorySale()
        {
            return View();
        }
    }
}
