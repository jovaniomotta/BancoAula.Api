using System.ComponentModel.DataAnnotations;

public class CriarContaDto
{
    [Required]
    public int ClienteId { get; set; }
     [Range(1000, 99999999)]
    public string Numero { get; set; } = "";
    [Required]
    public string Tipo { get; set; } = "";
    [Range(0.01, double.MaxValue)]
    public decimal SaldoInicial { get; set; }


}