public class Agencia{
    public int Id {get; set; }
  
    public string Nome {get; set; } = "";
    
    public string? Cidade {get; set; }
    
    public List<Conta> Contas {get; set;} = new ();
}