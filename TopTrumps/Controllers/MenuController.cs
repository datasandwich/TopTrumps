using Microsoft.AspNetCore.Mvc;

namespace TopTrumps.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
