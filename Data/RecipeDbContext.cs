using Microsoft.EntityFrameworkCore;
using Projeto_Livro_De_Receitas.Models;

namespace Projeto_Livro_De_Receitas.Data
{
    public class RecipeDbContext: DbContext
    {
        public RecipeDbContext(DbContextOptions<RecipeDbContext> options)
        : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Portion> Portions { get; set; }
        public DbSet<Category> Categories { get; set; }
       

    }
}
