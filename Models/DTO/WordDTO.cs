using System.Text.Json.Serialization;

namespace webapi.Models;

    public class WordDTO
    {
        public int Id { get; set; }

        public string Text { get; set; }

       // public char[] TextArray { get; set; }

       // public string? UsedWord { get; set; }

        // public Definition Definitions { get; set; }  
        [JsonPropertyName("Definitions")]
        public List<DefinitionDTO> Definitions = new List<DefinitionDTO>();
    }

