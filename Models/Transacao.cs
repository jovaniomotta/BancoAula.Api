public class Transacao{
    public int Id {get; set; }
     public string Descricao {get; set; } = "";
    public DateTime Data {get; set;} = DateTime.Now;
    public decimal Valor {get; set; }
    public string Tipo {get; set;} = "Deposito"; // Deposito, Saque, Transferencia
   

     public int ContaId {get; set;}
     public Conta? Conta {get; set;}

}