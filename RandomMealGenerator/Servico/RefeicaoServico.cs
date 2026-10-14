using RandomMealGenerator.Cliente;
using RandomMealGenerator.Clientes;
using RandomMealGenerator.Mapeadores;
using RandomMealGenerator.Modelos;

namespace RandomMealGenerator.Servico;

public class RefeicaoServico
{
    private readonly RefeicaoCliente _cliente;

    // O cliente chega pelo construtor (injeção por construtor):
    // o serviço não cria o que precisa, recebe.
    public RefeicaoServico(RefeicaoCliente cliente)
    {
        _cliente = cliente;
    }

    public async Task<Refeicao?> ObterAleatoriaAsync()
    {
        // 1. Pede o DTO ao cliente (a única camada que fala com a API)
        var dto = await _cliente.ObterRefeicaoAleatoriaAsync();

        // 2. Regra de negócio do guia: refeição sem nome não deve ser mostrada
        if (dto is null || string.IsNullOrWhiteSpace(dto.Nome))
            return null;

        // 3. Converte para o modelo próprio e devolve
        return RefeicaoMapeador.Mapear(dto);
    }
}