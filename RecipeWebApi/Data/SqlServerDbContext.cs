using Microsoft.EntityFrameworkCore;
using RecipeApp.ClassLibrary.Model;


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
                .HasForeignKey(r => r.UserId)
                .HasPrincipalKey(r=>r.Id)
                .OnDelete(DeleteBehavior.Cascade);
            */
        }

        public DbSet<User> User { get; set; }
        public DbSet<Recipe> Recipe { get; set; }
    }
}
