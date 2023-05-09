using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Purrrfect_Cats.Data;
using Purrrfect_Cats.Models;
using Purrrfect_Cats.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Purrrfect_Cats.Controllers
{
    public class HashtagsController : Controller
    {
        private ApplicationDbContext context;

        public HashtagsController(ApplicationDbContext dbcontext)
        {
            context = dbcontext;
        }

        public IActionResult Index()
        {
            List<Hashtag> hashtags = context.Hashtags.ToList();
            return View(hashtags);
        }

        public IActionResult Add()
        {
            Hashtag hashtag = new Hashtag();
            return View(hashtag);
        }

        [HttpPost]
        public IActionResult Add(Hashtag hashtag)
        {
            if (ModelState.IsValid)
            {
                context.Hashtags.Add(hashtag);
                context.SaveChanges();
                return Redirect("/Hashtags");
            }
            return View("Add", hashtag);
        }

        public IActionResult AddCat(int id)
        {
            FavoriteCatsModel theFavoriteCats = context.FavoriteCats.Find(id);
            List<Hashtag> possibleHashtags = context.Hashtags.ToList();

            AddHashtagViewModel viewModel = new AddHashtagViewModel(theFavoriteCats, possibleHashtags);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddCat(AddHashtagViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                string favoriteCatsId = viewModel.BreedNameId;
                string hashtagId = viewModel.HashtagId;

                FavoriteCatsModel theFavoriteCats = context.FavoriteCats.Include(p => p.Hashtags).Where(e => e.Id == favoriteCatsId).First();
                Hashtag theHashtag = context.Hashtags.Where(t => t.Id == hashtagId).First();

                theFavoriteCats.Hashtags.Add(theHashtag);
                context.SaveChanges();

                return Redirect("/FavoriteCats/FavoriteCats/" + hashtagId);
            }

            return View(viewModel);
        }

        public IActionResult Detail(string id)
        {
            Hashtag theHashtag = context.Hashtags.Include(e => e.FavoriteCats).Where(t => t.Id == id).First();

            return View(theHashtag);
        }
    }
}