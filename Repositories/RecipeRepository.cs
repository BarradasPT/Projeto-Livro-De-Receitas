using Microsoft.EntityFrameworkCore;
using Projeto_Livro_De_Receitas.Data;
using Projeto_Livro_De_Receitas.Models;

namespace Projeto_Livro_De_Receitas.Repositories
{
    public class RecipeRepository: IRepository<Recipe>
    {
        private readonly RecipeDbContext context;

        public RecipeRepository(RecipeDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Recipe> GetAll()
        {
            return context
                .Recipes
                .Include(b => b.Portions)                
                .ToList();
        }

        public Recipe? Get(int id)
        {
            return context
                .Recipes
                .Include(b => b.Portions)               
                .FirstOrDefault(b => b.Id == id);
        }

        public Recipe Add(Recipe value)
        {
            context.Recipes.Add(value);
            context.SaveChanges();

            return value;
        }

        public void Update(Recipe value)
        {
            context.Entry(value).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var value = Get(id);

            if (value != null)
            {
                context.Recipes.Remove(value);
                context.SaveChanges();
            }
        }
    }
}
