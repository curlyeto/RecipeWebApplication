using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests.RecipeApp.Tests
{
    [TestClass]
    public class UnitTestApi
    {
        /// <summary>
        ///  Test is not working. It's giving the issue in the SqlServerDbContext class. Error message is 
        ///       No constructor matches the passed arguments for constructor.
        /// </summary>
        /// <returns></returns>
        [Fact]
        [TestMethod]
        public async Task GetRecipe_Returns_The_Correct_Number_of_Categories()
        {
            int count = 6;
            var faceRecipes = A.CollectionOfDummy<RecipeWebApi.Models.Recipe>(count).AsEnumerable();
            var context = A.Fake<RecipeWebApi.Data.SqlServerDbContext>();
            foreach (RecipeWebApi.Models.Recipe category in faceRecipes)
            {
                A.CallTo(() => context.Recipe.Add(category));
            }
            var controller = new RecipeWebApi.Controllers.RecipeController(context);

            var actionResult = await controller.getRecipes();

            var result = actionResult.Result as OkObjectResult;
            var returnCategories = result.Value as IEnumerable<RecipeWebApi.Models.Recipe>;
            Assert.Equals(count, returnCategories.Count());
        }
    }
}
