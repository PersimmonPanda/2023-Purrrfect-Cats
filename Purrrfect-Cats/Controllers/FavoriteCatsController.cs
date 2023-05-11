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


        //[Route("FavoriteCats/FavoriteCats")]
        public IActionResult Add()
        {
            FavoriteCatsModel selectedCat = new FavoriteCatsModel();

            string catId = Request.Form["catId"];
            string breedName = Request.Form["breedName"];
            selectedCat.Id = catId;
            selectedCat.BreedName = breedName;

            context.FavoriteCats.Add(selectedCat);
            context.SaveChanges();
            return Redirect("/FavoriteCats/FavoriteCats");
        }
        [HttpPost]
        public IActionResult Delete(string[] Id)
        {
            foreach (string CatsId in Id)
            {
                FavoriteCatsModel DeleteCatsId = context.FavoriteCats.Find(CatsId);
                context.FavoriteCats.Remove(DeleteCatsId);
            }

            context.SaveChanges();

            return View("/Hashtags");
        }

    }
}