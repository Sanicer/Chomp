using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chomp.Models;
using System.Data.Entity;
using Chomp.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Chomp.Controllers
{
    [Authorize]
    public class RecipesController : Controller
    {
        private ApplicationDbContext _context;

        public RecipesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Recipes
        public ViewResult Index()
        {
            var recipes = _context.Recipes
                .Include(r => r.Cuisine)
                .Include(r => r.Difficulty)
                .ToList()
                .Where(r => r.AspNetUserId == User.Identity.GetUserId());
            return View(recipes);
        }

        public ActionResult Details(int id)
        {
            var recipes = _context.Recipes
                .Include(r => r.Cuisine)
                .Include(r => r.Difficulty)
                .SingleOrDefault(r => r.Id == id);

            if (recipes == null)
                return HttpNotFound();

            return View(recipes);
        }

        public ActionResult New(string s)
        {
            var difficulties = _context.Difficulties.ToList();
            var cuisines = _context.Cuisines.ToList();

            var viewModel = new RecipeFormViewModel
            {
                Difficulties = difficulties,
                Cuisines = cuisines,
                Ingredient = new Ingredient()
            };

            return View("RecipeForm", viewModel);
        }

        public ActionResult Edit(int id)
        {

            var recipe = _context.Recipes.SingleOrDefault(r => r.Id == id);

            if (recipe == null)
                return HttpNotFound();
            if (User.Identity.GetUserId() != recipe.AspNetUserId)
                return RedirectToAction("Index", "Recipes");

            var viewModel = new RecipeFormViewModel
            {
                Recipe = recipe,
                Difficulties = _context.Difficulties.ToList(),
                Cuisines = _context.Cuisines.ToList(),
                Ingredient = new Ingredient(),
                Ingredients = _context.Ingredients
                    .Where(r => r.RecipeId == id)
                    .ToList()
            };

            return View("RecipeForm", viewModel);
        }

        public ActionResult DeleteIngredient(int id, string userId, int recipeId)
        {
            if (User.Identity.GetUserId() != userId)
                return RedirectToAction("Index", "Recipes");

            var ingredientInDb = _context.Ingredients.SingleOrDefault(r => r.Id == id);

            if (ingredientInDb == null)
                return HttpNotFound();

            _context.Ingredients.Remove(ingredientInDb);
            _context.SaveChanges();

            var recipe = _context.Recipes.SingleOrDefault(r => r.Id == recipeId);
            var viewModel = new RecipeFormViewModel
            {
                Recipe = recipe,
                Difficulties = _context.Difficulties.ToList(),
                Cuisines = _context.Cuisines.ToList(),
                Ingredient = new Ingredient(),
                Ingredients = _context.Ingredients
                    .Where(r => r.RecipeId == recipeId)
                    .ToList()
            };


            return View("RecipeForm", viewModel);
        }

        public ActionResult Delete(int id )
        {
            var recipeInDb = _context.Recipes.Single(r => r.Id == id);
            if (recipeInDb == null)
                return HttpNotFound();

            var ingredientsInDb = _context.Ingredients.Where(r => r.RecipeId == id).ToList();
            _context.Recipes.Remove(recipeInDb);

            if(ingredientsInDb.Count > 0) { 
                foreach (var item in ingredientsInDb) { 
                    _context.Ingredients.Remove(item);
                }
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Recipes");
        }

        [HttpPost]
        public ActionResult Save(Recipe recipe, Ingredient ingredient, IList<Ingredient> ingredients)
        {
            if (recipe.Id == 0)
            {
                recipe.AspNetUserId = User.Identity.GetUserId();
                
                _context.Recipes.Add(recipe);
                _context.Ingredients.Add(ingredient);
            }
            else
            {
                var recipeInDb = _context.Recipes.Single(r => r.Id == recipe.Id);
                recipeInDb.Name = recipe.Name;
                recipeInDb.CookingTimeInMins = recipe.CookingTimeInMins;
                recipeInDb.CuisineId = recipe.CuisineId;
                recipeInDb.DifficultyId = recipe.DifficultyId;
                if (!string.IsNullOrWhiteSpace(ingredient.Name))
                {
                    ingredient.RecipeId = recipe.Id; 
                    _context.Ingredients.Add(ingredient);
                }
                if (ingredients != null)
                {
                    foreach (var item in ingredients)
                    {
                        var ingredientInDb = _context.Ingredients.Single(r => r.Id == item.Id);
                        ingredientInDb.Name = item.Name;
                    }
                }
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Recipes");
        }
    }
}