using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Razor.TagHelpers;
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
           
            return View(selectedCats);
        }


        [HttpPost]
       
        public IActionResult Add()
        {
            string user = Request.Form["user"];
            string catId = Request.Form["catId"];
            string breedName = Request.Form["breedName"];

            // Check if the cat already exists in the list
           FavoriteCatsModel existingCat = context.FavoriteCats.FirstOrDefault(x => x.BreedName == breedName);
            if (existingCat != null)
            {
                //ViewBag.Message = "Cat already exists in favorites list!";
                return View("FavoriteCats", context.FavoriteCats.ToList());
            }
            else
            {
                // Add the cat to the list
                FavoriteCatsModel selectedCat = new FavoriteCatsModel();
                selectedCat.Id = catId;
                selectedCat.BreedName = breedName;
                context.FavoriteCats.Add(selectedCat);
                context.SaveChanges();

                //ViewBag.Message = "Cat added to favorites list!";
                return View("FavoriteCats", context.FavoriteCats.ToList());
            }
        }



        [HttpPost]
        public IActionResult Delete(string catId)
        {

            FavoriteCatsModel deletecat = context.FavoriteCats.Find(catId);
            if(deletecat == null)
            {
                return Redirect("FavoriteCats");
            }
            else
            {
                context.FavoriteCats.Remove(deletecat);
                context.SaveChanges();
                return Redirect("FavoriteCats");

            }

          
        }
    }
}    