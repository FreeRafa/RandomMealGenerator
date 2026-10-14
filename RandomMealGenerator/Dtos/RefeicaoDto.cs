using System.Text.Json;
using System.Text.Json.Serialization;

namespace RandomMealGenerator.Dtos;

public class RefeicaoDto
{
    [JsonPropertyName("idMeal")]
    public string? IdExterno { get; set; }

    [JsonPropertyName("strMeal")]
    public string? Nome { get; set; }

    [JsonPropertyName("strCategory")]
    public string? Categoria { get; set; }

    [JsonPropertyName("strArea")]
    public string? Area { get; set; }

    [JsonPropertyName("strCountry")]
    public string? Pais { get; set; }

    [JsonPropertyName("strInstructions")]
    public string? Instrucoes { get; set; }

    [JsonPropertyName("strYoutube")]
    public string? VideoUrl { get; set; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement> CamposExtra { get; set; } = new();
}
