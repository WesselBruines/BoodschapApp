using IngredientDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoodschappenApp.Controllers
{
    public class BoodschapController : Controller
    {

        private DBingredient db = new DBingredient();
        // GET: Boodschap
        public ActionResult Index()
        {
            return View(db.BoodschapIngredients.ToList());
        }

        // GET: Ingredients/Create
        public ActionResult Toevoegen()
        {
            return View(db.Ingredients.ToList());
        }

        public ActionResult AddInventory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Ingredient ingredient = db.Ingredients.Find(id);
            BoodschapIngredient boodschapIngredient = new BoodschapIngredient();
            boodschapIngredient.IngredientID = ingredient.ingredientID;
            boodschapIngredient.Naam = ingredient.name;

            return View(boodschapIngredient);

        }

        // POST: Ingredients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddInventory([Bind(Include = "BoodschapIngredientID,IngredientID,Naam,Hoeveelheid,Eenheid")] BoodschapIngredient boodschapIngredient)
        {
            if (ModelState.IsValid)
            {
                db.BoodschapIngredients.Add(boodschapIngredient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(boodschapIngredient);
        }
    }
}