using Microsoft.AspNetCore.Mvc;

namespace Purrrfect_Cats.Controllers
{
    public class FavoriteCats : Controller
    {
        public IActionResult Index()
        {
            return View("FavoriteCats");
        }
    }
}
