public class Cliente{
    public int Id {get; set; }
  

    public string Nome {get; set; } = "";
    

    public string Cpf {get; set; } = "";
    
    
    public string? Email {get; set; }

     public string? Cidade {get; set; }

     public List<Conta> Contas {get; set;} = new ();
     
     public List<Emprestimo> Emprestimos {get; set;} = new ();


}