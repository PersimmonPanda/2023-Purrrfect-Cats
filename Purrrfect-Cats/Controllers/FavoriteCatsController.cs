using Microsoft.AspNetCore.Mvc;

namespace Purrrfect_Cats.Controllers
{
    public class FavoriteCatsController : Controller
    {
        [HttpPost]
        public IActionResult Index(string selectedBreed)
        {
            string valorSeleccionado = Request.Form["hola"];

            var catList = selectedBreed;
            return View("FavoriteCats");
        }
    }
}
