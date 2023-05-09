﻿using System.ComponentModel.DataAnnotations;
using Purrrfect_Cats.Data;


namespace Purrrfect_Cats.Models
{
    public class Hashtag
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Hashtag is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Hashtag must be between 3 and 50 characters")]
        public string TagName { get; set; }

        public ICollection<FavoriteCats>? FavoriteCats { get; set; }
        //public object Hashtags { get; set; }

        public Hashtag(string tagName)
        {
            TagName = tagName;
            FavoriteCats = new List<FavoriteCats>();
        }

        public Hashtag()
        {
        }
    }
}