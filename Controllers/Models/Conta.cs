using System.ComponentModel.DataAnnotations;

public class Conta{
    public int Id {get; set; }
    [Required]

    public int ClienteId {get; set;}
    [Required]

    public int Numero {get; set;}
    [Required]

    public string Tipo {get; set;} = "Corrente"; // Corrente, não existe uma conta nula.
    [Required]

    public decimal Saldo {get; set; }
    public bool Ativa {get; set;} = true;
}


