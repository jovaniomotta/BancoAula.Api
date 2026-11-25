using System.ComponentModel.DataAnnotations;
public class ContaResponseDto
{
    public int Id { get; set; }
    public int Numero { get; set; }
    public string Tipo { get; set; } = "";
    public decimal Saldo { get; set; }

}