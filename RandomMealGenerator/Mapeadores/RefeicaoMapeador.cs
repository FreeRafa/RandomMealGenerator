using RandomMealGenerator.Dtos;
using RandomMealGenerator.Modelos;

namespace RandomMealGenerator.Mapeadores;

public static class RefeicaoMapeador
{
    // Converte o DTO (formato da API) numa Refeicao (modelo próprio da aplicação).
    public static Refeicao Mapear(RefeicaoDto dto)
    {
        return new Refeicao
        {
            // Nome já foi validado pelo serviço, mas o ?? evita null por segurança
            Nome = dto.Nome?.Trim() ?? "",
            Categoria = dto.Categoria?.Trim() ?? "",
            Origem = dto.Area?.Trim() ?? "",
            Instrucoes = dto.Instrucoes?.Trim() ?? "",

            // Campos opcionais: se vierem vazios ou só com espaços, ficam null
            Pais = string.IsNullOrWhiteSpace(dto.Pais) ? null : dto.Pais.Trim(),
            VideoUrl = string.IsNullOrWhiteSpace(dto.VideoUrl) ? null : dto.VideoUrl.Trim(),

            // A conversão dos ingredientes continua a ser responsabilidade do IngredienteMapeador
            Ingredientes = IngredienteMapeador.Mapear(dto)
        };
    }
}