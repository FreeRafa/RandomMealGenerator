using System.Text.Json.Serialization;

namespace RandomMealGenerator.Dtos
{
    public class MealResponseDto
    {
        [JsonPropertyName("meals")]
        public List<MealDto>? Meals { get; set; }
    }
}
