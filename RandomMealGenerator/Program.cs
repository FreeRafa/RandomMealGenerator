using System.Text.Json;
using RandomMealGenerator.Dtos;
using RandomMealGenerator.Mappers;

var urlRefeicaoAleatoria = "https://www.themealdb.com/api/json/v1/1/random.php";

using var httpClient = new HttpClient();

var json = await httpClient.GetStringAsync(urlRefeicaoAleatoria);

var resposta = JsonSerializer.Deserialize<MealResponseDto>(json);
var refeicao = resposta?.Meals?.FirstOrDefault();

if (refeicao is null)
{
    Console.WriteLine("Nenhuma refeição encontrada.");
    return;
}

Console.WriteLine($"Nome: {refeicao.Nome}");
Console.WriteLine($"Categoria: {refeicao.Categoria}");
Console.WriteLine($"Origem: {refeicao.Area ?? refeicao.Pais}");

var ingredientes = IngredienteMapper.Mapear(refeicao);

Console.WriteLine("Ingredientes:");
foreach (var ingrediente in ingredientes)
{
    Console.WriteLine($"- {ingrediente.Quantidade} {ingrediente.Nome}");
}

Console.WriteLine();
Console.WriteLine("Instruções:");
Console.WriteLine(refeicao.Instrucoes);