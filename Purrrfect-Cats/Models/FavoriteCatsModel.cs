using static Purrrfect_Cats.Models.Hashtag;

namespace Purrrfect_Cats.Models
{
    public class FavoriteCats
    {
        public string BreedName { get; set; }
        public int Id { get; set; }

        public ICollection<Hashtag>? Hashtags { get; set; }
        //public object FavoriteCats { get; internal set; }

        public FavoriteCats(string breedName)
        {
            BreedName = breedName;
            Hashtags = new List<Hashtag>();
        }

        public FavoriteCats()
        {
        }

        public override string ToString()
        {
            return BreedName;
        }

        public override bool Equals(object obj)
        {
            return obj is FavoriteCats @favoriteCats &&
                   Id == @favoriteCats.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}