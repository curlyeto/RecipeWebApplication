using Microsoft.EntityFrameworkCore;
using RecipeWebApi.Models;

namespace RecipeWebApi.Data
{
    public class SqlServerDbContext : DbContext
    {
        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options)
      : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            modelBuilder.Entity<Recipe>()
                .HasOne(r => r.User)             // Recipe has one User
                .WithMany(u => u.Recipes)        // User has many Recipes
                .HasForeignKey(r => r.UserId)    // Use UserId as the foreign key
                .OnDelete(DeleteBehavior.Cascade);
            */
        }

        public DbSet<User> User { get; set; }
        public DbSet<Recipe> Recipe { get; set; }
    }
}
