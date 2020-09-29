using IngredientDB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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

            BoodschapIngredient boodschapIngredient = new BoodschapIngredient();

            boodschapIngredient.ingredient = db.Ingredients.Find(id);

            ViewBag.IngredientID = id;

            return View(boodschapIngredient);

        }

        // POST: Ingredients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddInventory([Bind(Include = "BoodschapingredientID,ingredient,Hoeveelheid,Eenheid")] BoodschapIngredient boodschapIngredient)
        {
            if (ModelState.IsValid)
            {
                Ingredient ig = db.Ingredients.Find(boodschapIngredient.ingredient.ingredientID);
                boodschapIngredient.ingredient = ig;
                db.BoodschapIngredients.Add(boodschapIngredient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(boodschapIngredient);
        }


        // GET: Ingredients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoodschapIngredient boodschapIngredient = db.BoodschapIngredients.Find(id);
            if (boodschapIngredient == null)
            {
                return HttpNotFound();
            }
            return View(boodschapIngredient);
        }

        // POST: Ingredients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BoodschapIngredientID,Ingredient,Hoeveelheid,Eenheid")] BoodschapIngredient boodschapIngredient)
        {
            if (ModelState.IsValid)
            {
                Ingredient ig = db.Ingredients.Find(boodschapIngredient.ingredient.ingredientID);
                boodschapIngredient.ingredient = ig;
                db.Entry(boodschapIngredient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(boodschapIngredient);
        }

        // GET: Ingredients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoodschapIngredient ingredient = db.BoodschapIngredients.Find(id);
            if (ingredient == null)
            {
                return HttpNotFound();
            }
            return View(ingredient);
        }

        // POST: Ingredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BoodschapIngredient ingredient = db.BoodschapIngredients.Find(id);
            db.BoodschapIngredients.Remove(ingredient);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Gekocht(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            BoodschapIngredient boodschapIngredient = db.BoodschapIngredients.Find(id);
            if (boodschapIngredient == null)
            {
                return HttpNotFound();
            }

            InventoryIngredient inventoryIngredient = new InventoryIngredient();
            inventoryIngredient.ingredient = boodschapIngredient.ingredient;
            inventoryIngredient.Hoeveelheid = boodschapIngredient.Hoeveelheid;
            inventoryIngredient.Eenheid = boodschapIngredient.Eenheid;

            db.InventoryIngredients.Add(inventoryIngredient);
            db.BoodschapIngredients.Remove(boodschapIngredient);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}