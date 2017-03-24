using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Chomp.Models;

namespace Chomp.Dtos
{
    public class RecipeDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Difficulty Difficulty { get; set; }

        [Required]
        public int DifficultyId { get; set; }

        public Cuisine Cuisine { get; set; }

        [Required]
        public int CuisineId { get; set; }

        [Required]
        public int CookingTimeInMins { get; set; }

        public string AspNetUserId { get; set; }

        public string Instruction { get; set; }
    }
}