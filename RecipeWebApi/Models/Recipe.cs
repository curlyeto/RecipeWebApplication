using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace RecipeWebApi.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Integrates { get; set; }
        [Required]
        public string Instruction { get; set; }
        [Required]
        public int UserId { get; set; }
    



        /*
         When I create migration it worked. When I send add recipe post request body type with json I have to add userId and user object. But  I don't want to add user object when I send request.
         */

        //[Required]
        //public int UserId { get; set; }
        //[ForeignKey(nameof(UserId))]
        //public virtual User User { get; set; }

    }
}
