using RecipeApp.ClassLibrary.Model;

namespace RecipeApp.Services
{
    public interface IRecipeService
    {
        Task<List<Recipe>> getRecipes();
        Task<HttpResponseMessage> addRecipe(String image, String name,String integrates,String instruction,int userId);
        Task<bool> EditRecipe(String image, String name,String integrates,String instruction,int userId,int recipeId);
        Task<List<Recipe>> myRecipes(int userId);
        Task<Recipe> getRecipeWithId(int recipeId);

        Task<bool> deleteRecipe(int recipeId);
    }
}
