using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngredientDB
{
    public class Ingredient
    {
        [Key]
        public int ingredientID { get; set; }
      
        public string name { get; set; }
        
        public string merk { get; set; }
    }
}
