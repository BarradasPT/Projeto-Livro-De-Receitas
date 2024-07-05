using Microsoft.EntityFrameworkCore;
using Projeto_Livro_De_Receitas.Data;
using Projeto_Livro_De_Receitas.Models;

namespace Projeto_Livro_De_Receitas.Repositories
{
    public class IngredientRepository: IRepository<Ingredient>
    {
       
            private readonly RecipeDbContext context;

            public IngredientRepository(RecipeDbContext context)
            {
                this.context = context;
            }

            public IEnumerable<Ingredient> GetAll()
            {
                return context
                    .Ingredients
                    .Include(b => b.Portions)                   
                    .ToList();
            }

            public Ingredient? Get(int id)
            {
                return context
                    .Ingredients                    
                    .Include(b => b.Portions)
                    .FirstOrDefault(b => b.Id == id);
            }

            public Ingredient Add(Ingredient value)
            {
                context.Ingredients.Add(value);
                context.SaveChanges();

                return value;
            }

            public void Update(Ingredient value)
            {
                context.Entry(value).State = EntityState.Modified;
                context.SaveChanges();
            }

            public void Delete(int id)
            {
                var value = Get(id);

                if (value != null)
                {
                    context.Ingredients.Remove(value);
                    context.SaveChanges();
                }
            }
        }
    }

