using Microsoft.Extensions.DependencyInjection;
using RandomMealGenerator.Cliente;
using RandomMealGenerator.Clientes;
using RandomMealGenerator.Servico;

var servicos = new ServiceCollection();

// Regista o cliente HTTP tipado. A BaseAddress é a parte comum do URL
// (o "/" no fim é importante, senão "random.php" é resolvido no sítio errado)
servicos.AddHttpClient<RefeicaoCliente>(cliente =>
{
    cliente.BaseAddress = new Uri("https://www.themealdb.com/api/json/v1/1/");
});

// O serviço é registado como Transient: cria-se uma instância nova a cada pedido ao contentor
servicos.AddTransient<RefeicaoServico>();

using var provedor = servicos.BuildServiceProvider();

// Pede ao contentor o serviço já montado (com o cliente lá dentro)
var servico = provedor.GetRequiredService<RefeicaoServico>();

var refeicao = await servico.ObterAleatoriaAsync();

if (refeicao is null)
{
    Console.WriteLine("Nenhuma refeição encontrada.");
    return;
}

Console.WriteLine($"Nome: {refeicao.Nome}");
Console.WriteLine($"Categoria: {refeicao.Categoria}");
Console.WriteLine($"Origem: {refeicao.Origem}");

if (!string.IsNullOrWhiteSpace(refeicao.Pais))
    Console.WriteLine($"País: {refeicao.Pais}");

Console.WriteLine();
Console.WriteLine("Ingredientes:");
foreach (var ingrediente in refeicao.Ingredientes)
{
    Console.WriteLine($"- {ingrediente.Quantidade} {ingrediente.Nome}".Replace("-  ", "- "));
}

Console.WriteLine();
Console.WriteLine("Instruções:");
Console.WriteLine(refeicao.Instrucoes);

if (!string.IsNullOrWhiteSpace(refeicao.VideoUrl))
{
    Console.WriteLine();
    Console.WriteLine($"Vídeo: {refeicao.VideoUrl}");
}