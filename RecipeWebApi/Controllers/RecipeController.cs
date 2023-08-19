using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using RecipeApp.ClassLibrary.Model;
using RecipeWebApi.Data;


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
          
            return Ok(recipes);
        }
        [HttpGet("{id}")]
        public ActionResult<Recipe> getRecipe(int id)
        {
            var recipe = _dbContext.Recipe.Find(id);
            if (recipe == null)
            {
               
                return NotFound();
            }
           
            return Ok(recipe);
        }
        [HttpPost]
        public async Task<ActionResult> Create(Recipe recipe)
        {
            User? user = await _dbContext.User.FindAsync(recipe.UserId);
            if (user == null)
            {
               
                return NotFound();
            }
            _dbContext.Recipe.Add(recipe);
            await _dbContext.SaveChangesAsync();
           
            return Ok(user);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Recipe recipe)
        {
            if (id != recipe.Id)
            {
                
                return NotFound();

            }
            _dbContext.Recipe.Entry(recipe).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            
            return Ok(recipe);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var recipe = await _dbContext.Recipe.FindAsync(id);
            if (recipe == null)
            {
               
                return NotFound();
            }
            _dbContext.Recipe.Remove(recipe);
            await _dbContext.SaveChangesAsync();
           
            return Ok(recipe);
        }
        [HttpGet("userRecipe")]
        public ActionResult userRecipe(String userId)
        {
            var userRecipe = _dbContext.Recipe.Where(recipe => recipe.UserId == int.Parse(userId));
            return Ok(userRecipe);

            
        }
    }
}
