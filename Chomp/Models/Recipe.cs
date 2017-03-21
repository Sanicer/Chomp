using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chomp.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Difficulty Difficulty { get; set; }

        [Required]
        [Display(Name = "Difficulty")]
        public int DifficultyId { get; set; }

        public Cuisine Cuisine { get; set; }

        [Required]
        [Display(Name = "Cuisine")]
        public int CuisineId { get; set; }

        [Required]
        [Display(Name = "Cooking time in minutes")]
        public int CookingTimeInMins { get; set; }

        public string AspNetUserId { get; set; }
    }
}