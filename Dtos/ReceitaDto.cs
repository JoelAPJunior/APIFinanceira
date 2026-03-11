namespace ApiFinanceira.Dtos
{
    public class ReceitaDto
    {
        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public DateOnly DataPrevisao { get; set; }

        public string Categoria { get; set; }

        public string Observacao { get; set; }
    }
}