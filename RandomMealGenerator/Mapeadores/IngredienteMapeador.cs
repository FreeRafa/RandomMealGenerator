using System.Text.Json;
using RandomMealGenerator.Dtos;
using RandomMealGenerator.Modelos;


namespace RandomMealGenerator.Mapeadores;

public static class IngredienteMapeador
{
    public static List<Ingrediente> Mapear(RefeicaoDto dto)
    {
        var ingredientes = new List<Ingrediente>();

        for (int i = 1; i <= 20; i++)
        {
            var nome = ObterTexto(dto.CamposExtra, $"strIngredient{i}");
            var quantidade = ObterTexto(dto.CamposExtra, $"strMeasure{i}");

            if (string.IsNullOrWhiteSpace(nome))
                continue;

            ingredientes.Add(new Ingrediente
            {
                Nome = nome.Trim(),
                Quantidade = quantidade?.Trim() ?? ""
            });
        }

        return ingredientes;
    }

    private static string? ObterTexto(Dictionary<string, JsonElement> campos, string chave)
    {
        if (!campos.TryGetValue(chave, out var valor))
            return null;

        return valor.ValueKind == JsonValueKind.String ? valor.GetString() : null;
    }
}