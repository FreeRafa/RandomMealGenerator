using System.Text.Json.Serialization;

namespace RandomMealGenerator.Dtos
{
    public class RespostaRefeicaoDto
    {
        [JsonPropertyName("meals")]
        public List<RefeicaoDto>? Meals { get; set; }
    }
}
