using Microsoft.AspNetCore.Mvc;

namespace Purrrfect_Cats.Controllers
{
    public class FavoriteCatsController : Controller
    {
        
        public IActionResult Index(string selectedBreed)
        {
            

            var catList = selectedBreed;
            return View("FavoriteCats");
        }
    }
}
