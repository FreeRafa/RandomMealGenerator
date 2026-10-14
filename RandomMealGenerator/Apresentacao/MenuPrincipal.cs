using RandomMealGenerator.Modelos;
using RandomMealGenerator.Servico;

namespace RandomMealGenerator.Apresentacao;

public class MenuPrincipal
{
    private readonly RefeicaoServico _refeicaoServico;

    // O serviço chega pelo construtor, tal como aconteceu com o cliente no serviço
    public MenuPrincipal(RefeicaoServico refeicaoServico)
    {
        _refeicaoServico = refeicaoServico;
    }

    // Laço de repetição: o menu volta a aparecer até o utilizador escolher sair
    public async Task ExecutarAsync()
    {
        var sair = false;

        while (!sair)
        {
            MostrarOpcoes();
            var opcao = Console.ReadLine()?.Trim();

            switch (opcao)
            {
                case "1":
                    await SugerirAleatoriaAsync();
                    break;
                case "0":
                    sair = true;
                    break;
                default:
                    // Validação de entrada (secção 17 do guia)
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }

        Console.WriteLine("Até à próxima!");
    }

    private static void MostrarOpcoes()
    {
        Console.WriteLine();
        Console.WriteLine("=== Random Meal Generator ===");
        Console.WriteLine("1 - Sugerir refeição aleatória");
        Console.WriteLine("0 - Sair");
        Console.Write("Opção: ");
    }

    private async Task SugerirAleatoriaAsync()
    {
        var refeicao = await _refeicaoServico.ObterAleatoriaAsync();

        if (refeicao is null)
        {
            Console.WriteLine("Nenhuma refeição encontrada.");
            return;
        }

        MostrarRefeicao(refeicao);
    }

    private static void MostrarRefeicao(Refeicao refeicao)
    {
        Console.WriteLine();
        Console.WriteLine($"Nome: {refeicao.Nome}");
        Console.WriteLine($"Categoria: {refeicao.Categoria}");
        Console.WriteLine($"Origem: {refeicao.Origem}");

        if (!string.IsNullOrWhiteSpace(refeicao.Pais))
            Console.WriteLine($"País: {refeicao.Pais}");

        Console.WriteLine();
        Console.WriteLine("Ingredientes:");
        foreach (var ingrediente in refeicao.Ingredientes)
        {
            // Trim() remove o espaço que sobra quando a quantidade vem vazia
            Console.WriteLine($"- {ingrediente.Quantidade} {ingrediente.Nome}".Trim());
        }

        Console.WriteLine();
        Console.WriteLine("Instruções:");
        Console.WriteLine(refeicao.Instrucoes);

        if (!string.IsNullOrWhiteSpace(refeicao.VideoUrl))
        {
            Console.WriteLine();
            Console.WriteLine($"Vídeo: {refeicao.VideoUrl}");
        }
    }
}