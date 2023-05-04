using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Purrrfect_Cats.Models;


namespace Purrrfect_Cats.Controllers
{
    public class BreedsController : Controller
    {
        public async Task<IActionResult> Breeds()

        {

            List<SelectListItem> LstBreed = new List<SelectListItem>();
            CatBreedModel catBreed = new CatBreedModel();
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-api-key", "live_F9pFgfTNQsm0mJfBg0FpALoycqilewVeMw8LPpcsmqTZpsydTTRjvhINAQxvTyRE");

            var response = await client.GetAsync("https://api.thecatapi.com/v1/breeds");

            if (response.IsSuccessStatusCode)
            {
                var breedsJson = await response.Content.ReadAsStringAsync();
                var breeds = JsonConvert.DeserializeObject<List<CatBreedModel>>(breedsJson);

                if (breeds != null)
                {
                    foreach (var breed in breeds)
                    {
                        LstBreed.Add(new SelectListItem
                        {
                            Value = breed.Id,
                            Text = breed.Name,

                        });

                    }
                    if (LstBreed != null)
                    {
                        catBreed.LstBreed = LstBreed;
                    }

                }

                return View(catBreed);

            }

            return View("Error");
        }


        [HttpPost]
        public async Task<IActionResult> GetCatByBreed()
        {
            //CatInfoModel catInfo = new CatInfoModel();
            List<BreedTypeModel> LstOneCatBreed = new List<BreedTypeModel>();
            BreedTypeModel oneBreed = new BreedTypeModel();
            var client = new HttpClient();
            string valorSeleccionado = Request.Form["breedId"];
            var response = await client.GetAsync("https://api.thecatapi.com/v1/images/search?limit=5&breed_ids=" + valorSeleccionado + "&api_key=live_F9pFgfTNQsm0mJfBg0FpALoycqilewVeMw8LPpcsmqTZpsydTTRjvhINAQxvTyRE");
            if (response.IsSuccessStatusCode)
            {
                var jsonGetOneBreed = await response.Content.ReadAsStringAsync();
                var getOneBreed = JsonConvert.DeserializeObject<List<BreedTypeModel>>(jsonGetOneBreed);


                if (getOneBreed != null)
                {

                    foreach (var catBreed in getOneBreed)
                    {
                        //catInfo = new CatInfoModel();
                        oneBreed = new BreedTypeModel();
                        oneBreed.Id = catBreed.Id;
                        oneBreed.Url = catBreed.Url;
                        oneBreed.Width = catBreed.Width;
                        oneBreed.Height = catBreed.Height;
                        oneBreed.Breeds = catBreed.Breeds;
                        LstOneCatBreed.Add(oneBreed);

                    }

                    if (getOneBreed != null)
                    {
                        oneBreed.LstOneCatBreed = LstOneCatBreed;

                    }
                    return View("Index", oneBreed);
                }
            }
            return View("Error");
        }
    }

}
