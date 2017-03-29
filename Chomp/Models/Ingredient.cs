using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chomp.Models
{
    public class Ingredient
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Ingredient name")]
        public string Name { get; set; }

        [Required]
        public int RecipeId { get; set; }
    }
}