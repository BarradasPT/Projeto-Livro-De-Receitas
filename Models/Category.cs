using System.Text.Json.Serialization;

namespace Projeto_Livro_De_Receitas.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        [JsonIgnore] public List<Recipe>? Recipes { get; set; } = [];
    }
}
