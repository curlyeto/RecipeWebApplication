using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeApp.ClassLibrary.Model;
using RecipeWebApi.Data;
using RecipeWebApi.Controllers;
using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTests.RecipeApp.Tests
{
    [TestClass]
    public class UnitTestApi
    {
        
       
        [Fact]
        [TestMethod]
        public async Task testUserModel()
        {
            User user = new User(0, "https://t3.ftcdn.net/jpg/02/43/12/34/360_F_243123463_zTooub557xEWABDLk0jJklDyLSGl2jrr.jpg", "Test", "User", "test@gmail.com", "1234");
            Assert.AreEqual(user.Email, "test@gmail.com");
        }
        [Fact]
        [TestMethod]
        public async Task recipeCountIsCorrect()
        {
            int count = 6;
            var faceRecipes = A.CollectionOfDummy<Recipe>(count).AsEnumerable();

            Assert.AreEqual(faceRecipes.Count(), 6);
        }
        [Fact]
        [TestMethod]
        public async Task userCreate()
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<SqlServerDbContext>(options =>
                    options.UseSqlServer("Data Source=(local); Initial Catalog=Recipe; trusted_connection=yes; TrustServerCertificate=True"))
                .BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<SqlServerDbContext>();


                var controller = new UserController(dbContext); // Instantiate your controller
                User user = new User(0, "https://t3.ftcdn.net/jpg/02/43/12/34/360_F_243123463_zTooub557xEWABDLk0jJklDyLSGl2jrr.jpg", "Test", "User", "test@gmail.com", "1234");
                // Act
                var result = controller.Create(user);

                // Assert
                Assert.IsNotNull(result);
               

            }
        }
        [Fact]
        [TestMethod]
        public async Task Login_ValidCredentials()
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<SqlServerDbContext>(options =>
                    options.UseSqlServer("Data Source=(local); Initial Catalog=Recipe; trusted_connection=yes; TrustServerCertificate=True"))
                .BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<SqlServerDbContext>();
              

                var controller = new UserController(dbContext); // Instantiate your controller

                // Act
                var result =  controller.Login("test@gmail.com", "1234");

                // Assert
                Assert.IsNotNull(result);
              
            }
        }
        [Fact]
        [TestMethod]
        public async Task nullControlRecipeList()
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<SqlServerDbContext>(options =>
                    options.UseSqlServer("Data Source=(local); Initial Catalog=Recipe; trusted_connection=yes; TrustServerCertificate=True"))
                .BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<SqlServerDbContext>();


                var controller = new RecipeController(dbContext); // Instantiate your controller

                // Act
                var result = controller.getRecipes();
              
          
                // Assert
                Assert.IsNotNull(result);

            }
        }
    }
}
