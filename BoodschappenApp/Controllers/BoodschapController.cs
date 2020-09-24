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
    }
}