using System.Text.Json.Serialization;

namespace Projeto_Livro_De_Receitas.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Time { get; set; }
        public string? Difficulty { get; set; }
        public string? Description { get; set; }       
        public List<Portion> Portions { get; set; } = [];


        // Relação com Categoria        
        public Category? Categories { get; set; } 


    }
}
