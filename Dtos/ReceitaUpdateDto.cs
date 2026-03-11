namespace ApiFinanceira.Dtos
{
    public class ReceitaUpdateDto
    {
        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public DateOnly DataPrevisao { get; set; }

        public DateOnly? DataRecebimento { get; set; }

        public string Categoria { get; set; }

        public string Observacao { get; set; }

        public string Situacao { get; set; }
    }
}