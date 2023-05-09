using Microsoft.AspNetCore.Mvc;

namespace Purrrfect_Cats.Controllers
{
    public class FavoriteCatsController : Controller
    {    
        public IActionResult FavoriteCats()
        {
            
            return View();
        }

    }
}
