using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Purrrfect_Cats.Models;

namespace Purrrfect_Cats.Controllers
{
    public class FavoriteCatsController : Controller

    {    
        public IActionResult FavoriteCats()
        {
            FavoriteCatsModel selectedCat = new FavoriteCatsModel();
            selectedCat = GetCatid();
            return View(selectedCat);
        }
        
        
        public FavoriteCatsModel GetCatid()
        {
            FavoriteCatsModel selectedCat = new FavoriteCatsModel();
         
            string catId = Request.Form["catId"];
            string catUrl = Request.Form["catUrl"];
            selectedCat.CatIds = catId;
            selectedCat.ImageUrls = catUrl;

            return selectedCat;
        }

    }
}
