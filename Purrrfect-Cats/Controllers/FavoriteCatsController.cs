using Microsoft.AspNetCore.Mvc;

namespace Purrrfect_Cats.Controllers
{
    public class FavoriteCatsController : Controller
    {
        public IActionResult Index()
        {
            return View("FavoriteCats");
        }
    }
}
