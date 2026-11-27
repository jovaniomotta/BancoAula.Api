
using System.ComponentModel.DataAnnotations;

public class RegistroDto
{   
    [Required]
    public string Nome { get; set;} = "";
    [Required, EmailAddress]
    public string Email { get; set;} = "";
    [Required]
    public string Senha { get; set;} = "";
}