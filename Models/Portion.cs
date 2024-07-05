using System.Text.Json.Serialization;

namespace Projeto_Livro_De_Receitas.Models
{
    public class Portion
    {
        public int Id { get; set; }
        public string? Unit { get; set; }
        public int? Quantity { get; set; }

        // Chaves estrangeiras

        [JsonIgnore] public List<Recipe>? Recipes { get; set; }

        
        public Ingredient? Ingredients { get; set; } 
    }
}
