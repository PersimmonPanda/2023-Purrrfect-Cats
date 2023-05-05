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
            return View("Adds", hashtag);
        }

        public IActionResult AddHashtag(int id)
        {
            Hashtag thehashtag = context.Hashtags.Find(id);
            List<Hashtag> possibleHashtags = context.Hashtags.ToList();

            AddHashtagViewModel viewModel = new AddHashtagViewModel(theHashtag, possibleHashtags);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddHashtag(AddHashtagViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                int eventId = viewModel.EventId;
                int hashtagId = viewModel.HashtagId;

                Hashtag theHashtag = context.Hashtags.Include(p => p.Hashtags).Where(e => e.Id == hashtagId).First();
                Hashtag theHashtag = context.Hashtags.Where(t => t.Id == hashtagId).First();

                theHashtag.Hashtags.Add(theHashtag);
                context.SaveChanges();

                return Redirect("/Events/Detail/" + hashtagId);
            }

            return View(viewModel);
        }

        public IActionResult Detail(int id)
        {
            Tag theTag = context.Tags.Include(e => e.Events).Where(t => t.Id == id).First();

            return View(theTag);
        }
    }
        }
    }
}