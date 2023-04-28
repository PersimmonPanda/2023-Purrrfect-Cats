using Microsoft.AspNetCore.Mvc;

namespace Purrrfect_Cats.Controllers
{
    public class BreedsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
