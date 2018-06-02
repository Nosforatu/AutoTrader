using Microsoft.AspNetCore.Mvc;

namespace AutoTrader.Controllers
{
    public class AutoDealerController : Controller
    {
        public IActionResult  Index()
        {
            return View();
        }
    }
}