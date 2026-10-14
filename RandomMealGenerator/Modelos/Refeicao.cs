namespace RandomMealGenerator.Modelos
{
    public class Refeicao
    {
        public string Nome { get; set; } = "";
        public string Categoria { get; set; } = "";
        public string Origem { get; set; } = "";
        public string? Pais { get; set; }
        public string Instrucoes { get; set; } = "";
        public string? VideoUrl { get; set; }
        public List<Ingrediente> Ingredientes { get; set; } = new();
    }
}
