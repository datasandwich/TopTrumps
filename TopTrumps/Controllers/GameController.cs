using Microsoft.AspNetCore.Mvc;

namespace TopTrumps.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
