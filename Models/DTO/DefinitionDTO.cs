using System.Text.Json.Serialization;

namespace webapi.Models;

    public class DefinitionDTO
    {
        [JsonPropertyName("Id")]
        public string Id { get; set; }
        [JsonPropertyName("Text")]
       public string Text { get; set; }
    [JsonPropertyName("WordId")]
        public int WordId{ get; set; }

    
    }

