using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.ClassLibrary.Model
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Image { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public string Integrates { get; set; }
        [Required]
        public string Instruction { get; set; }
        [Required]
        public int UserId { get; set; }


        public Recipe()
        {

        }
        public Recipe(int id, string image, string name, string integrates, string instruction)
        {
            Id = id;
            Image = image;
            Name = name;
            Integrates = integrates;
            Instruction = instruction;
        }

        public List<Recipe> addRecipes()
        {
            var rows = new List<Recipe>();
            List<Recipe> recipes = new List<Recipe>();

            recipes.Add(new Recipe(0, "https://www.saveur.com/uploads/2019/10/17/YLU6THKTRPPOTQ65IGT7MTSPSI.jpg?auto=webp", "Turkish Kebab", "1 cup whole-milk Greek yogurt\r\n\r\n6 cloves garlic, minced\r\n\r\n2 tablespoons olive oil\r\n\r\n2 tablespoons freshly squeezed lemon juice, or more to taste\r\n\r\n2 tablespoons ketchup", "Whisk yogurt, garlic, olive oil, lemon juice, ketchup, red pepper flakes, salt, cumin, black pepper, paprika, and cinnamon together in a large bowl."));
            recipes.Add(new Recipe(1, "https://ozlemsturkishtable.com/files/2014/07/IMG_2700.jpg", "Turkish Pide", "300 gr/ 10½ oz. / + 2 tbsp. all-purpose plain flour\r\n5ml/1 tsp. salt\r\n14 gr/4 tsp. dried yeast (2 packs of 7gr dried yeast)\r\n1 pinch of sugar\r\n8 fl. oz. /1 cup warm water\r\n45ml/3 tbsp. olive oil\r\nFor the topping:\r\n1 medium onion, finely chopped",
                "Preheat the oven to 180 C/ 350 F\r\nStir in the dried yeast and sugar in a small bowl and pour in ½ cup warm water. Dissolve the yeast in water, mixing with your fingers. Set aside for the yeast mixture to get frothy for 5 minutes.\r\nCombine the flour and salt in a large bowl.\r\nMake a well in the middle and pour in 2 tbsp. olive oil and the yeast mixture.\r\nPour in the remaining ½ warm water to the flour mixture. Using your hands, draw in the flour from the sides and work the mixture into a dough.\r\nKnead for 3 -5 minutes, until you reach a soft, smooth dough. The dough gets sticky as you knead, so pour the remaining 1 tbsp. olive oil and stir in additional 2 tbsp. flour to help shape into a soft dough."));
            recipes.Add(new Recipe(2, "https://www.panningtheglobe.com/wp-content/uploads/2013/11/turkish-manti-web-final.jpg", "Turkish Manti", "1 pound or 450g lamb shanks or lamb neck slices\r\n1/2 teaspoons or 4g Diamond Crystal kosher salt, divided; if using table salt, use half as much by volume or the same weight.\r\n1 quart or 960ml low sodium chicken stock\r\n5 medium garlic cloves, lightly crushed\r\n1/4 cup or 60g tomato paste", "Put the lamb on a wire rack set on a rimmed baking sheet and sprinkle with 1 teaspoon salt evenly on all sides. Place it at room temperature for at least 30 minutes or up to two hours"));
            recipes.Add(new Recipe(3, "https://turkishfoodie.com/wp-content/uploads/2019/02/Kokorec.jpg", "Kokarec", "3 kokoreç\r\n1 tomato\r\n1 onion\r\n1 clove of garlic\r\n4 green peppers\r\nchilli pepper\r\nthyme\r\nground black pepper\r\nsalt\r\n6 bread", "Firstly , chop the kokoreç into the small pieces\r\nThen , chop the tomato , onion , garlic and green peppers\r\nPut the kokoreç in a pan and cook it for 10 minutes\r\nAdd the onion and garlic on it and brown them about 2 minutes\r\nAdd green peppers and continue to brown\r\nPut tomato on them and stir\r\nAdd spices and brown about 5 minutes"));
            recipes.Add(new Recipe(3, "https://turkishfoodie.com/wp-content/uploads/2019/02/Kokorec.jpg", "Kokarec", "3 kokoreç\r\n1 tomato\r\n1 onion\r\n1 clove of garlic\r\n4 green peppers\r\nchilli pepper\r\nthyme\r\nground black pepper\r\nsalt\r\n6 bread", "Firstly , chop the kokoreç into the small pieces\r\nThen , chop the tomato , onion , garlic and green peppers\r\nPut the kokoreç in a pan and cook it for 10 minutes\r\nAdd the onion and garlic on it and brown them about 2 minutes\r\nAdd green peppers and continue to brown\r\nPut tomato on them and stir\r\nAdd spices and brown about 5 minutes"));
            recipes.Add(new Recipe(3, "https://turkishfoodie.com/wp-content/uploads/2019/02/Kokorec.jpg", "Kokarec", "3 kokoreç\r\n1 tomato\r\n1 onion\r\n1 clove of garlic\r\n4 green peppers\r\nchilli pepper\r\nthyme\r\nground black pepper\r\nsalt\r\n6 bread", "Firstly , chop the kokoreç into the small pieces\r\nThen , chop the tomato , onion , garlic and green peppers\r\nPut the kokoreç in a pan and cook it for 10 minutes\r\nAdd the onion and garlic on it and brown them about 2 minutes\r\nAdd green peppers and continue to brown\r\nPut tomato on them and stir\r\nAdd spices and brown about 5 minutes"));

            return recipes;
        }
        /*
         When I create migration it worked. When I send add recipe post request body type with json I have to add userId and user object. But  I don't want to add user object when I send request.
         */

        //[Required]
        //public int UserId { get; set; }
        //[ForeignKey(nameof(UserId))]
        //public virtual User User { get; set; }

    }

}
