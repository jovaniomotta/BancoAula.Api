using System.ComponentModel.DataAnnotations;

public class ValorDto
{
    [Range(0.01, double.MaxValue)]
    public decimal Valor { get; set; }
}