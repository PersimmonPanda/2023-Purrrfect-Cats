using System;
using Purrrfect_Cats.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Purrrfect_Cats.ViewModels
{
    public class AddHashtagViewModel
    {

        public int BreedNameId { get; set; }
        public FavoriteCats? BreedName { get; set; }

        public List<SelectListItem>? Hashtag { get; set; }

        public int HashtagId { get; set; }

        public AddHashtagViewModel(FavoriteCats theBreedName, List<Hashtag> possibleHashtags)
        {
            Hashtag = new List<SelectListItem>();

            foreach (var hashtag in possibleHashtags)
            {
                Hashtag.Add(new SelectListItem
                {
                    Value = hashtag.Id.ToString(),
                    Text = hashtag.Name
                });
            }

            BreedName = theBreedName;
        }

        public AddHashtagViewModel()
        {
        }
    }
}