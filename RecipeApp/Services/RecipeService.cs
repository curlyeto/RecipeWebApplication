using RecipeApp.ClassLibrary.Model;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;

namespace RecipeApp.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly HttpClient _httpClient;
        public RecipeService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<List<Recipe>> getRecipes()
        {
            return await _httpClient.GetFromJsonAsync<List<Recipe>>("api/Recipe");
        }

        public async Task<HttpResponseMessage> addRecipe(string image, string name, string integrates, string instruction, int userId)
        {
            var recipe = new
            {
                image = image,
                name = name,
                integrates = integrates,
                instruction = instruction,
                userId = userId
            };

            var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(recipe), Encoding.UTF8, "application/json");
            var response=await _httpClient.PostAsync("https://localhost:7006/api/Recipe", content);
            return response;
        }
      
        public async Task<List<Recipe>> myRecipes(int userId)
        {
            return await _httpClient.GetFromJsonAsync<List<Recipe>>("api/Recipe/userRecipe?userId=" + userId);
        }

        public async Task<Recipe> getRecipeWithId(int recipeId)
        {
            return await _httpClient.GetFromJsonAsync<Recipe>("api/Recipe/" + recipeId);
        }

        public async Task<bool> EditRecipe(string image, string name, string integrates, string instruction, int userId, int recipeId)
        {
            var recipe = new
            {
                id=recipeId,
                image = image,
                name = name,
                integrates = integrates,
                instruction = instruction,
                userId = userId
            };

            var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(recipe), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"https://localhost:7006/api/Recipe/{recipeId}", content);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> deleteRecipe(int recipeId)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7006/api/Recipe/{recipeId}");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        
        }
    }
}
