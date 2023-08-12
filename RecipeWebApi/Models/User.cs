using System.ComponentModel.DataAnnotations;

namespace RecipeWebApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        [Required]
        public string FirstName { get; set; }
        [StringLength (50)]
        public string LastName { get; set; }
        [StringLength(200)]
        public string Photo { get; set; }
        [StringLength(200)]
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(200)]
        public string Password { get; set; }

    }
}
