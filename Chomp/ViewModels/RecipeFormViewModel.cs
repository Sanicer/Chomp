using System.Collections.Generic;
using Chomp.Models;

namespace Chomp.ViewModels
{
    public class RecipeFormViewModel
    {
        public IEnumerable<Cuisine> Cuisines { get; set; }
        public IEnumerable<Difficulty> Difficulties { get; set; }
        public IList<Ingredient> Ingredients { get; set; }
        public Ingredient Ingredient { get; set; }
        public Recipe Recipe { get; set; }
        public string Title
        {
            get
            {
                if (Recipe != null && Recipe.Id != 0)
                    return "Edit Recipe";
                return "New Recipe";
            }
        }
    }
}