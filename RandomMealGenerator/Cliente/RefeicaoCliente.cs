using System.Text.Json;
using RandomMealGenerator.Dtos;

namespace RandomMealGenerator.Cliente;

public class RefeicaoCliente
{
    private readonly HttpClient _httpClient;

    public RefeicaoCliente(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<RefeicaoDto?> ObterRefeicaoAleatoriaAsync()
    {
        var json = await _httpClient.GetStringAsync("random.php");

        var resposta = JsonSerializer.Deserialize<RespostaRefeicaoDto>(json);

        return resposta?.Meals?.FirstOrDefault();
    }
}