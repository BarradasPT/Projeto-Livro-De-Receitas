using Microsoft.EntityFrameworkCore;
using Projeto_Livro_De_Receitas.Data;
using Projeto_Livro_De_Receitas.Models;

namespace Projeto_Livro_De_Receitas.Repositories
{
        public class CategoryRepository : IRepository<Category>
        {
            private readonly RecipeDbContext context;

            public CategoryRepository(RecipeDbContext context)
            {
                this.context = context;
            }

            public IEnumerable<Category> GetAll()
            {
                return context
                    .Categories
                    .Include(b => b.Recipes)
                    .ToList();
            }

            public Category? Get(int id)
            {
                return context
                    .Categories
                    .Include(b => b.Recipes)
                    .FirstOrDefault(b => b.Id == id);
            }

            public Category Add(Category value)
            {
                context.Categories.Add(value);
                context.SaveChanges();

                return value;
            }

            public void Update(Category value)
            {
                context.Entry(value).State = EntityState.Modified;
                context.SaveChanges();
            }

            public void Delete(int id)
            {
                var value = Get(id);

                if (value != null)
                {
                    context.Categories.Remove(value);
                    context.SaveChanges();
                }
            }
        }
    }

