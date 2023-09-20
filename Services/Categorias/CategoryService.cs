using Newtonsoft.Json;
using PRACTICA_JQUERY_AJAX.Models.Categorias;

namespace PRACTICA_JQUERY_AJAX.Services.Categorias
{
    public class CategoryService : ICategoryService
    {
        private readonly string APIBaseURL;
        private readonly HttpClient _httpClient;


        public CategoryService(HttpClient httpClient)
        {
            APIBaseURL = Environment.GetEnvironmentVariable("APIBaseURL");
            _httpClient = httpClient;
        }

        public async Task<List<Category>> ObtenerCategorias()
        {
            string url = $"{APIBaseURL}/categories";
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return null;

            string content = await response.Content.ReadAsStringAsync();
            List<Category> category = JsonConvert.DeserializeObject<List<Category>>(content);

            return category;
        }
    }
}
