using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Chomp.Dtos;
using Chomp.Models;
using System.Data.Entity;

namespace Chomp.Controllers.Api
{
    public class RecipesController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public RecipesController()
        {
            _context = new ApplicationDbContext();
        }

        [Route("api/recipes/{userId}")]
        [HttpGet]
        public IHttpActionResult GetRecipes(string userId)
        {
            var recipeDtos = _context.Recipes
                .Include(r => r.Cuisine)
                .Include(r => r.Difficulty)
                .ToList()
                .Where(r => r.AspNetUserId == userId)
                .Select(Mapper.Map<Recipe, RecipeDto>);

            return Ok(recipeDtos);
        }

        [Route("api/recipes/{id:int}")]
        [HttpGet]
        public IHttpActionResult GetRecipes(int id)
        {
            var recipe = _context.Recipes.SingleOrDefault(r => r.Id == id);

            if (recipe == null)
                return NotFound();

            return Ok(Mapper.Map<Recipe, RecipeDto>(recipe));
        }


    }
}
