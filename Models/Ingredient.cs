using System.Text.Json.Serialization;

namespace Projeto_Livro_De_Receitas.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [JsonIgnore] public List<Portion>? Portions { get; set; } = [];// O JsonIgnore irá evitar a serialização das porções associadas para prevenir ciclos

    }
}
