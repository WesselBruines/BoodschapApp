using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngredientDB
{
   public class InventoryIngredient
    {
        [Key]
        public int InventoryIngredientID { get; set; }
        public int IngredientID { get; set; }
        public string Naam { get; set; }
        public double Hoeveelheid { get; set; }
        public string Eenheid { get; set; }
    }
}
