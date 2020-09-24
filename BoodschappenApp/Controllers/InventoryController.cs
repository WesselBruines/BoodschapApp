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
    public class InventoryController : Controller
    {
        private DBingredient db = new DBingredient();
        // GET: Inventory
        public ActionResult Index()
        {
            return View(db.InventoryIngredients.ToList());
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
            InventoryIngredient inventoryIngredient = new InventoryIngredient();
            inventoryIngredient.IngredientID = ingredient.ingredientID;
            inventoryIngredient.Naam = ingredient.name;

            return View(inventoryIngredient);

        }

        // POST: Ingredients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddInventory([Bind(Include = "InventoryingredientID,IngredientID,Naam,Hoeveelheid,Eenheid")] InventoryIngredient inventoryIngredient)
        {
            if (ModelState.IsValid)
            {
                db.InventoryIngredients.Add(inventoryIngredient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inventoryIngredient);
        }

        // GET: Ingredients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryIngredient ingredient = db.InventoryIngredients.Find(id);
            if (ingredient == null)
            {
                return HttpNotFound();
            }
            return View(ingredient);
        }

        // POST: Ingredients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InventoryingredientID,IngredientID,Naam,Hoeveelheid,Eenheid")] InventoryIngredient inventoryIngredient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventoryIngredient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inventoryIngredient);
        }

        // GET: Ingredients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryIngredient ingredient = db.InventoryIngredients.Find(id);
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
            InventoryIngredient ingredient = db.InventoryIngredients.Find(id);
            db.InventoryIngredients.Remove(ingredient);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}