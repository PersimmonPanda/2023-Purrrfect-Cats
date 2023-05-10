using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Purrrfect_Cats.Data;
using Purrrfect_Cats.Models;

namespace Purrrfect_Cats.Controllers
{
    public class FavoriteCatsController : Controller
    {
        private ApplicationDbContext context;
        public FavoriteCatsController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }
       
        public IActionResult FavoriteCats()
        {

            List<FavoriteCatsModel> selectedCats = context.FavoriteCats.ToList();
            //selectedCats = GetCatid();
            return View(selectedCats);
        }


        //public FavoriteCatsModel GetCatid()
        //{
        //    foreach (FavoriteCatsModel i in context.FavoriteCats.ToList())
        //    {

        //    }
        //    FavoriteCatsModel selectedCat = new FavoriteCatsModel();

        //    string catId = Request.Form["catId"];
        //    string catUrl = Request.Form["catUrl"];
        //    selectedCat.Id = catId;
        //    selectedCat.ImageUrls = catUrl;

        //    return selectedCat;
        //    List<FavoriteCatsModel> favorites =
        //}

        [HttpPost]
        //[Route("FavoriteCats/FavoriteCats")]
        public IActionResult FavoriteCats(FavoriteCatsModel selectedCat)
        {
            //FavoriteCatsModel selectedCat = new FavoriteCatsModel();

            string catId = Request.Form["catId"];
            string breedName = Request.Form["breedName"];
            selectedCat.Id = catId;
            selectedCat.BreedName = breedName;

            context.FavoriteCats.Add(selectedCat);
            context.SaveChanges();
            return View();
        }

    }
}