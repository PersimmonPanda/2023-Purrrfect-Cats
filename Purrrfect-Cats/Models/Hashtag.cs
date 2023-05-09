

using System.ComponentModel.DataAnnotations;

namespace Purrrfect_Cats.Models
{
    public class Hashtag
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Hashtag is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Hashtag must be between 3 and 50 characters")]
        public string TagName { get; set; }

        public ICollection<FavoriteCatsModel>? FavoriteCats { get; set; }
        //public object Hashtags { get; set; }

        public Hashtag(string tagName)
        {
            TagName = tagName;
            FavoriteCats = new List<FavoriteCatsModel>();
        }

        public Hashtag()
        {
        }
    }
}