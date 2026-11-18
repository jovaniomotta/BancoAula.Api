using System.ComponentModel.DataAnnotations;

public class Conta{
    public int Id {get; set; }
    public int Numero {get; set;}  
    public string Tipo {get; set;} = "Corrente"; // Corrente, não existe uma conta nula.
    public decimal Saldo {get; set; }
    public bool Ativa {get; set;} = true;

     public int ClienteId {get; set;}
     public Cliente? Cliente {get; set;}
     public int AgenciaId {get; set;}
     public Agencia? Agencia {get; set;}

     public List<Transacao> Transacoes {get; set;} = new ();


}


