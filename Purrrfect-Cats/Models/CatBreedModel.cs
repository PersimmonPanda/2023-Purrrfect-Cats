using Microsoft.AspNetCore.Mvc.Rendering;
namespace Purrrfect_Cats.Models
{
    public class CatBreedModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<SelectListItem> LstBreed { get; set; }


    }
}
