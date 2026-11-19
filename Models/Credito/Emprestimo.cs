public class Emprestimo
{
    public int Id { get; set; }
    public decimal Valor { get; set; }
    public int Prazo { get; set; }
    public decimal TaxaJuros { get; set; }
    public DateTime DataSolicitacao { get; set; }
    public DateTime DataVencimento { get; set; }
    public string Status { get; set; } = "Pendente";

    public int ClienteId { get; set; }
    public Cliente? Cliente { get; set; }

}