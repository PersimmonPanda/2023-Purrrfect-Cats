using static Purrrfect_Cats.Models.Hashtag;

namespace Purrrfect_Cats.Models
{
    public class FavoriteCatsModel
    {
        public string BreedName { get; set; }
        public string Id { get; set; }
        public string ImageUrls { get; set; }

        public ICollection<Hashtag>? Hashtags { get; set; }
        //public object FavoriteCats { get; internal set; }

        public FavoriteCatsModel(string breedName)
        {
            BreedName = breedName;
            Hashtags = new List<Hashtag>();
        }

        public FavoriteCatsModel()
        {
        }

        public override string ToString()
    {
            return BreedName;
        }

        public override bool Equals(object obj)
        {
            return obj is FavoriteCatsModel @favoriteCats &&
                   Id == @favoriteCats.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
