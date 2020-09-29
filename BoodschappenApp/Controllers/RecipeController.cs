using IngredientDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoodschappenApp.Controllers
{
    public class RecipeController : Controller
    {

        private DBingredient db = new DBingredient();
        // GET: Recipe
        public ActionResult Index()
        {
            return View(db.Recipes.ToList());
        }

        // GET: Ingredients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ingredients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecipeID,Naam,Beschrijving,Calorien")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                db.Recipes.Add(recipe);
                db.SaveChanges();
                return RedirectToAction("AddIngredient", recipe);
            }
            ViewBag.Recipe = recipe;
            return View();
        }

        public ActionResult AddIngredient(Recipe recipe)
        {
            ViewBag.RecipeID = recipe.RecipeID;
            return View(db.TotalRecipeIngredients.ToList());
        }

[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddIngredient(int? id)
        {

            RecipeIngredient recipeIngredient = new RecipeIngredient();

            recipeIngredient.ingredient = db.Ingredients.Find(id);
            
            Recipe recipe = db.Recipes.Find(ViewBag.RecipeID);
            recipe.RecipeIngredients.Add(recipeIngredient);
                
                db.SaveChanges();
                return RedirectToAction("index");
            

            
        }
        public ActionResult CreateRecipeIngredient()
        {
            return View(db.Ingredients.ToList());
        }

        
    }
}