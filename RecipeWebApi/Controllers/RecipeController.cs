using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using RecipeWebApi.Data;
using RecipeWebApi.Models;

namespace RecipeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly SqlServerDbContext _dbContext;

        public RecipeController(SqlServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Recipe>>> getRecipes()
        {
            List<Recipe> recipes = await _dbContext.Recipe.ToListAsync();
            var successResponseWithData = new BaseResponse<List<Recipe>>
            {
                Success = true,
                Message = "",
                Data = recipes
            };
            return Ok(successResponseWithData);
        }
        [HttpGet("{id}")]
        public ActionResult<Recipe> getRecipe(int id)
        {
            var recipe = _dbContext.Recipe.Find(id);
            if (recipe == null)
            {
                var responseError = new BaseResponse<Recipe>
                {
                    Success = false,
                    Message = "Recipe not found",
                };
                return Ok(responseError);
            }
            var successResponseWithData = new BaseResponse<Recipe>
            {
                Success = true,
                Message = "",
                Data = recipe
            };
            return Ok(successResponseWithData);
        }
        [HttpPost]
        public async Task<ActionResult> Create(Recipe recipe)
        {
           
            User? user = await _dbContext.User.FindAsync(recipe.UserId);
            if (user == null)
            {
                var responseError = new BaseResponse<Recipe>
                {
                    Success = false,
                    Message = "User not found",
                };
                return Ok(responseError);
            }
            _dbContext.Recipe.Add(recipe);
            await _dbContext.SaveChangesAsync();
            var successResponseWithData = new BaseResponse<Recipe>
            {
                Success = true,
                Message = "Recipe Added",
                Data = recipe
            };
            return Ok(successResponseWithData);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Recipe recipe)
        {
            if (id != recipe.Id)
            {
                var responseError = new BaseResponse<Recipe>
                {
                    Success = false,
                    Message = "Recipe does not found",
                };
                return Ok(responseError);

            }
            _dbContext.Recipe.Entry(recipe).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            var successResponseWithData = new BaseResponse<Recipe>
            {
                Success = true,
                Message = "Recipe Updated",
                Data = recipe
            };
            return Ok(successResponseWithData);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var recipe = await _dbContext.Recipe.FindAsync(id);
            if (recipe == null)
            {
                var responseError = new BaseResponse<Recipe>
                {
                    Success = false,
                    Message = "Recipe does not found",
                };
                return Ok(responseError);
            }
            _dbContext.Recipe.Remove(recipe);
            await _dbContext.SaveChangesAsync();
            var successResponseWithData = new BaseResponse<Recipe>
            {
                Success = true,
                Message = "Recipe Deleted"
            };
            return Ok(successResponseWithData);
        }
    }
}
