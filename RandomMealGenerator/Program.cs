using Microsoft.Extensions.DependencyInjection;
using RandomMealGenerator.Apresentacao;
using RandomMealGenerator.Cliente;
using RandomMealGenerator.Servico;

Console.WriteLine(">>> Program.cs novo a correr");

var servicos = new ServiceCollection();

servicos.AddHttpClient<RefeicaoCliente>(cliente =>
{
    cliente.BaseAddress = new Uri("https://www.themealdb.com/api/json/v1/1/");
});

servicos.AddTransient<RefeicaoServico>();
servicos.AddTransient<MenuPrincipal>();

using var provedor = servicos.BuildServiceProvider();

var menu = provedor.GetRequiredService<MenuPrincipal>();
await menu.ExecutarAsync();