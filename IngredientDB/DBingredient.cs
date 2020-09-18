using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngredientDB
{
    public class DBingredient : DbContext
    {

        
        public DbSet<Ingredient> Ingredients { get; set; }
    }
}
