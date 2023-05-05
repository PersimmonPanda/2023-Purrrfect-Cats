using Microsoft.AspNetCore.Mvc.Rendering;

namespace Purrrfect_Cats.Models
{
    public class ListCatsBreedsModel
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public List<CatInfoModel> Breeds { get; set; }
        public List<SelectListItem> LstBreeds { get; set; }
        public List<BreedTypeModel> SelectedBreed { get; set; }
    }
}
