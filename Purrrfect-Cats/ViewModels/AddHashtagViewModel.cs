using System;
using Purrrfect_Cats.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Purrrfect_Cats.ViewModels
{
    public class AddHashtagViewModel
    {

        public string BreedNameId { get; set; }
        public FavoriteCatsModel? BreedName { get; set; }

        public List<SelectListItem>? Hashtag { get; set; }

        public string HashtagId { get; set; }

        public AddHashtagViewModel(FavoriteCatsModel theBreedName, List<Hashtag> possibleHashtags)
        {
            Hashtag = new List<SelectListItem>();

            foreach (var hashtag in possibleHashtags)
            {
                Hashtag.Add(new SelectListItem
                {
                    Value = hashtag.Id.ToString(),
                    Text = hashtag.TagName
                });
            }

            BreedName = theBreedName;
        }

        public AddHashtagViewModel()
        {
        }
    }
}