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
                Cuisines = cuisines
            };

            return View("RecipeForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var recipe = _context.Recipes.SingleOrDefault(r => r.Id == id);

            if (recipe == null)
                return HttpNotFound();

            var viewModel = new RecipeFormViewModel()
            {
                Recipe = recipe,
                Difficulties = _context.Difficulties.ToList(),
                Cuisines = _context.Cuisines.ToList()
            };

            return View("RecipeForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Recipe recipe)
        {
            if (recipe.Id == 0)
            {
                recipe.AspNetUserId = User.Identity.GetUserId();
                _context.Recipes.Add(recipe);
            }
            else
            {
                var recipeInDb = _context.Recipes.Single(r => r.Id == recipe.Id);
                recipeInDb.Name = recipe.Name;
                recipeInDb.CookingTimeInMins = recipe.CookingTimeInMins;
                recipeInDb.CuisineId = recipe.CuisineId;
                recipeInDb.DifficultyId = recipe.DifficultyId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Recipes");
        }
    }
}